using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using PigPass.Data;
using PigPass.Models;

namespace PigPass.Controllers;

public record PermitCheck(string Result, Permit? Permit);

public class PermitController
{
    public string Request(int originFarmId, int pigCount, string category, string purpose, string destination, DateTime intendedDate)
    {
        using var db = new AppDbContext();
        var farm = db.Farms.Find(originFarmId) ?? throw new InvalidOperationException("Origin farm not found.");
        if (pigCount <= 0) throw new InvalidOperationException("Pig count must be greater than zero.");
        var reason = RefusalReason(db, farm, destination);
        var permit = new Permit { OriginFarmId = originFarmId, PigCount = pigCount, PigCategory = category,
            Purpose = purpose, Destination = destination, IntendedDate = intendedDate, Status = reason == "" ? "Pending" : "Refused",
            DecisionReason = reason };
        db.Permits.Add(permit);
        db.AuditLogs.Add(new AuditLog { UserId = Session.CurrentUser?.UserId, Action = "Request permit", EntityName = "Permit", Details = $"Farm {originFarmId}: {reason}" });
        db.SaveChanges();
        return reason == "" ? "Permit request submitted for veterinary inspection." : $"Request refused: {reason}";
    }

    public void Approve(int permitId, int veterinarianId)
    {
        using var db = new AppDbContext();
        var permit = db.Permits.Include(p => p.OriginFarm).FirstOrDefault(p => p.PermitId == permitId) ?? throw new InvalidOperationException("Permit not found.");
        var reason = RefusalReason(db, permit.OriginFarm!, permit.Destination);
        if (reason != "") { permit.Status = "Refused"; permit.DecisionReason = reason; db.SaveChanges(); throw new InvalidOperationException(reason); }
        permit.PermitNumber = "PP-" + RandomToken(10);
        permit.VerificationCode = RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
        permit.IssuingVeterinarianId = veterinarianId;
        permit.IssuedAt = DateTime.Now;
        permit.ValidUntil = DateTime.Now.AddHours(OutbreakController.Setting(db, "PermitValidityHours", 24));
        permit.Status = "Issued";
        permit.DecisionReason = "Approved after pre-movement inspection.";
        db.AuditLogs.Add(new AuditLog { UserId = Session.CurrentUser?.UserId, Action = "Issue permit", EntityName = "Permit", Details = permit.PermitNumber });
        db.SaveChanges();
    }

    public PermitCheck Verify(string permitNumber, string verificationCode, string location = "")
    {
        using var db = new AppDbContext();
        var permit = db.Permits.Include(p => p.OriginFarm).FirstOrDefault(p => p.PermitNumber == permitNumber);
        string result;
        if (permit == null || permit.VerificationCode != verificationCode) result = "NOT FOUND/FALSE";
        else if (permit.Status == "Cancelled") result = "CANCELLED";
        else if (permit.Status == "Completed") result = "ALREADY USED";
        else if (permit.ValidUntil < DateTime.Now) result = "EXPIRED";
        else if (permit.OriginFarm!.State is "Infected" or "Suspected" || InControlZone(db, permit.OriginFarm)) result = "ORIGIN IN CONTROL ZONE";
        else if (permit.Status != "Issued") result = permit.Status.ToUpperInvariant();
        else result = "VALID";
        db.VerificationLogs.Add(new VerificationLog { PermitNumber = permitNumber, Result = result, Location = location, UserId = Session.CurrentUser?.UserId });
        db.SaveChanges();
        return new PermitCheck(result, result == "VALID" ? permit : null);
    }

    public void RecordReceipt(int permitId, int receivedCount)
    {
        using var db = new AppDbContext();
        var permit = db.Permits.Find(permitId) ?? throw new InvalidOperationException("Permit not found.");
        if (permit.Status != "Issued") throw new InvalidOperationException("Only issued permits can be received.");
        permit.ReceivedCount = receivedCount;
        permit.CompletedAt = DateTime.Now;
        permit.Status = "Completed";
        db.AuditLogs.Add(new AuditLog { UserId = Session.CurrentUser?.UserId, Action = "Record receipt", EntityName = "Permit", Details = permit.PermitNumber });
        db.SaveChanges();
    }

    public List<Permit> GetAll() { using var db = new AppDbContext(); return db.Permits.Include(p => p.OriginFarm).OrderByDescending(p => p.IssuedAt).ToList(); }

    public Permit? Get(int permitId) { using var db = new AppDbContext(); return db.Permits.FirstOrDefault(p => p.PermitId == permitId); }

    private static string RefusalReason(AppDbContext db, Farm farm, string destination)
    {
        if (farm.State is "Infected" or "Suspected") return $"Origin farm is {farm.State.ToLowerInvariant()}.";
        if (InControlZone(db, farm)) return "Origin farm is inside an active control zone.";
        return "";
    }

    private static bool InControlZone(AppDbContext db, Farm farm)
        => db.ControlZones.Include(z => z.SourceFarm).Any(z => z.LiftedAt == null &&
            OutbreakController.DistanceKm(farm.Latitude, farm.Longitude, z.SourceFarm!.Latitude, z.SourceFarm.Longitude) <= z.RadiusKm);

    private static string RandomToken(int length)
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        return string.Concat(Enumerable.Range(0, length).Select(_ => chars[RandomNumberGenerator.GetInt32(chars.Length)]));
    }
}
