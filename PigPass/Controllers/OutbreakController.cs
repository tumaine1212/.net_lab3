using Microsoft.EntityFrameworkCore;
using PigPass.Data;
using PigPass.Models;

namespace PigPass.Controllers;

public class OutbreakController
{
    public string ConfirmOutbreak(string caseRef, string reason = "Confirmed ASF outbreak")
    {
        using var db = new AppDbContext();
        var report = db.SickReports.Include(r => r.Farm).FirstOrDefault(r => r.CaseRef == caseRef)
            ?? throw new InvalidOperationException("Case not found.");
        if (report.LabResult != "Positive")
            throw new InvalidOperationException("A positive laboratory result is required before confirmation.");

        report.Status = "Confirmed";
        report.Farm!.State = "Infected";
        var protection = Setting(db, "ProtectionRadiusKm", 3);
        var surveillance = Setting(db, "SurveillanceRadiusKm", 10);
        db.ControlZones.AddRange(
            new ControlZone { SourceFarmId = report.FarmId, ZoneType = "Protection", RadiusKm = protection, Reason = reason },
            new ControlZone { SourceFarmId = report.FarmId, ZoneType = "Surveillance", RadiusKm = surveillance, Reason = reason });
        db.AuditLogs.Add(new AuditLog { UserId = Session.CurrentUser?.UserId, Action = "Confirm outbreak", EntityName = "SickReport", Details = caseRef });
        db.SaveChanges();
        return $"Outbreak confirmed. Protection zone: {protection:0.##} km; surveillance zone: {surveillance:0.##} km.";
    }

    public List<ControlZone> GetActiveZones()
    {
        using var db = new AppDbContext();
        return db.ControlZones.Include(z => z.SourceFarm).Where(z => z.LiftedAt == null).OrderByDescending(z => z.StartedAt).ToList();
    }

    public List<Farm> GetAffectedFarms()
    {
        using var db = new AppDbContext();
        var zones = db.ControlZones.Include(z => z.SourceFarm).Where(z => z.LiftedAt == null).ToList();
        var farms = db.Farms.Where(f => f.IsActive).ToList();
        return farms.Where(f => zones.Any(z => DistanceKm(f.Latitude, f.Longitude, z.SourceFarm!.Latitude, z.SourceFarm.Longitude) <= z.RadiusKm)).ToList();
    }

    public static double DistanceKm(double latitude1, double longitude1, double latitude2, double longitude2)
    {
        const double earthRadius = 6371;
        var dLat = DegreesToRadians(latitude2 - latitude1);
        var dLon = DegreesToRadians(longitude2 - longitude1);
        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(latitude1)) * Math.Cos(DegreesToRadians(latitude2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        return earthRadius * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
    }

    private static double DegreesToRadians(double degrees) => degrees * Math.PI / 180;

    internal static double Setting(AppDbContext db, string name, double fallback)
        => double.TryParse(db.AppSettings.FirstOrDefault(x => x.Name == name)?.Value, out var value) ? value : fallback;
}
