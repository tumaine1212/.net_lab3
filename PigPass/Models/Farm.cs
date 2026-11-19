using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPass.Models;

public class Farm
{
    public int FarmId { get; set; }
    public string OwnerName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string District { get; set; } = "";
    public string Sector { get; set; } = "";
    public string Village { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Sows { get; set; }
    public int Boars { get; set; }
    public int Growers { get; set; }
    public int Piglets { get; set; }
    public string State { get; set; } = "Normal";   // Normal, Suspected, Infected
    public string BiosecurityStatus { get; set; } = "Needs improvement";
    public bool IsActive { get; set; } = true;
    public DateTime RegisteredAt { get; set; } = DateTime.Now;

    [Browsable(false)]
    public List<SickReport> Reports { get; set; } = new();

    [NotMapped, Browsable(false)]
    public string Display => $"{FarmId} - {OwnerName} ({Sector})";
}
