using Microsoft.EntityFrameworkCore;
using PigPass.Data;
using PigPass.Models;

namespace PigPass.Controllers;

public class ReportController
{
    // Creates the report and returns the case reference number (FR-DR-04)
    public string Create(int farmId, int pigs, int days, string notes)
    {
        using var db = new AppDbContext();
        var farm = db.Farms.Find(farmId) ?? throw new Exception("Farm not found.");

        var report = new SickReport
        {
            FarmId = farmId, PigsAffected = pigs, Days = days, Notes = notes,
            ReportedAt = DateTime.Now, Status = "Reported",
            CaseRef = "CASE-" + DateTime.Now.ToString("yyyyMMdd") + "-" + Random.Shared.Next(1000, 9999)
        };
        db.SickReports.Add(report);

        if (farm.State == "Normal") farm.State = "Suspected";   // simple rule
        db.Notifications.Add(new Notification { Recipient = "Sector veterinarian", Message = $"New sick pig report {report.CaseRef} from farm {farm.FarmId} ({farm.District}, {farm.Sector})." });
        db.AuditLogs.Add(new AuditLog { UserId = Session.CurrentUser?.UserId, Action = "Create case", EntityName = "SickReport", Details = report.CaseRef });
        db.SaveChanges();
        return report.CaseRef;
    }

    public List<ReportRow> GetAll()
    {
        using var db = new AppDbContext();
        return db.SickReports.Include(r => r.Farm)
            .OrderByDescending(r => r.ReportedAt)
            .Select(r => new ReportRow
            {
                CaseRef = r.CaseRef,
                Farm = r.Farm!.OwnerName,
                Pigs = r.PigsAffected,
                Days = r.Days,
                Reported = r.ReportedAt,
                Status = r.Status
            }).ToList();
    }

    public void UpdateStatus(string caseRef, string status)
    {
        using var db = new AppDbContext();
        var r = db.SickReports.FirstOrDefault(x => x.CaseRef == caseRef);
        if (r == null) return;
        r.Status = status;
        db.SaveChanges();
    }

    public void RecordLabResult(string caseRef, string result, string visitNotes = "")
    {
        using var db = new AppDbContext();
        var report = db.SickReports.Include(r => r.Farm).FirstOrDefault(x => x.CaseRef == caseRef)
            ?? throw new InvalidOperationException("Case not found.");
        report.LabResult = result;
        report.VisitNotes = visitNotes;
        report.Status = result == "Positive" ? "Confirmed" : "Negative";
        if (result == "Negative") report.Farm!.State = "Normal";
        db.Notifications.Add(new Notification { Recipient = report.Farm!.OwnerName, Message = $"Case {caseRef} result: {result}." });
        db.AuditLogs.Add(new AuditLog { UserId = Session.CurrentUser?.UserId, Action = "Record laboratory result", EntityName = "SickReport", Details = $"{caseRef}: {result}" });
        db.SaveChanges();
    }
}
