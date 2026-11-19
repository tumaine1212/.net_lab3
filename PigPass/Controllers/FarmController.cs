using PigPass.Data;
using PigPass.Models;

namespace PigPass.Controllers;

public class FarmController
{
    // Returns an error message, or "" when the farm data is OK
    public string Validate(Farm f, bool isNew)
    {
        if (string.IsNullOrWhiteSpace(f.OwnerName)) return "Farmer name is required.";
        if (string.IsNullOrWhiteSpace(f.Phone))     return "Phone number is required.";
        if (string.IsNullOrWhiteSpace(f.District))  return "District is required.";
        if (string.IsNullOrWhiteSpace(f.Sector))    return "Sector is required.";
        if (f.Latitude < -90 || f.Latitude > 90)     return "Latitude must be between -90 and 90.";
        if (f.Longitude < -180 || f.Longitude > 180) return "Longitude must be between -180 and 180.";

        if (isNew)   // FR-FR-03: prevent duplicates by phone + location
        {
            using var db = new AppDbContext();
            bool dup = db.Farms.Any(x => x.IsActive && x.Phone == f.Phone && x.Sector == f.Sector);
            if (dup) return "A farm with this phone number and sector is already registered.";
        }
        return "";
    }

    public List<Farm> GetAll()
    {
        using var db = new AppDbContext();
        return db.Farms.Where(f => f.IsActive).OrderBy(f => f.FarmId).ToList();
    }

    public List<Farm> Search(string term)
    {
        using var db = new AppDbContext();
        term = term.Trim();
        return db.Farms.Where(f => f.IsActive &&
                   (f.OwnerName.Contains(term) || f.Phone.Contains(term) ||
                    f.Sector.Contains(term) || f.State.Contains(term) ||
                    f.FarmId.ToString() == term))
                   .OrderBy(f => f.FarmId).ToList();
    }

    public void Add(Farm f)
    {
        using var db = new AppDbContext();
        db.Farms.Add(f);
        db.SaveChanges();
    }

    public void Update(Farm f)
    {
        using var db = new AppDbContext();
        var existing = db.Farms.Find(f.FarmId);
        if (existing == null) return;

        existing.OwnerName = f.OwnerName;
        existing.Phone = f.Phone;
        existing.District = f.District;
        existing.Sector = f.Sector;
        existing.Village = f.Village;
        existing.Latitude = f.Latitude;
        existing.Longitude = f.Longitude;
        existing.Sows = f.Sows;
        existing.Boars = f.Boars;
        existing.Growers = f.Growers;
        existing.Piglets = f.Piglets;
        existing.State = f.State;
        db.SaveChanges();
    }

    // Soft delete (deactivate), as in FR-FR-07
    public void Delete(int farmId)
    {
        using var db = new AppDbContext();
        var f = db.Farms.Find(farmId);
        if (f == null) return;
        f.IsActive = false;
        db.SaveChanges();
    }
}
