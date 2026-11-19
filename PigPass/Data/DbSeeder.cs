using PigPass.Controllers;
using PigPass.Models;

namespace PigPass.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Users.Any())
        {
            db.Users.AddRange(
                new User { Username = "admin",  FullName = "System Admin", Role = "Administrator",
                           PasswordHash = AuthController.Hash("admin123") },
                new User { Username = "vet",    FullName = "Sector Vet",   Role = "Veterinarian",
                           PasswordHash = AuthController.Hash("vet123") },
                new User { Username = "command", FullName = "Command Post Officer", Role = "Command Post Officer",
                           PasswordHash = AuthController.Hash("command123") },
                new User { Username = "receiver", FullName = "Demo Receiver", Role = "Receiver",
                           PasswordHash = AuthController.Hash("receiver123") },
                new User { Username = "police", FullName = "Demo Police Officer", Role = "Police Officer",
                           PasswordHash = AuthController.Hash("police123") },
                new User { Username = "farmer", FullName = "Demo Farmer",  Role = "Farmer",
                           PasswordHash = AuthController.Hash("farmer123") });
        }
        if (!db.Farms.Any())
        {
            db.Farms.Add(new Farm
            {
                OwnerName = "Jean Claude", Phone = "0788000001", District = "Rusizi",
                Sector = "Kamembe", Village = "Gihundwe", Latitude = -2.4846, Longitude = 28.9075,
                Sows = 3, Boars = 1, Growers = 10, Piglets = 12
            });
        }
        if (!db.AppSettings.Any())
        {
            db.AppSettings.AddRange(
                new AppSetting { Name = "ProtectionRadiusKm", Value = "3" },
                new AppSetting { Name = "SurveillanceRadiusKm", Value = "10" },
                new AppSetting { Name = "PermitValidityHours", Value = "24" },
                new AppSetting { Name = "TracingLookbackDays", Value = "28" });
        }
        db.SaveChanges();
    }
}
