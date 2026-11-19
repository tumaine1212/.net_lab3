namespace PigPass.Models;

public class SickReport
{
    public int SickReportId { get; set; }
    public string CaseRef { get; set; } = "";
    public int FarmId { get; set; }
    public Farm? Farm { get; set; }
    public int PigsAffected { get; set; }
    public int Days { get; set; }
    public string Notes { get; set; } = "";
    public DateTime ReportedAt { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Reported";
    public string LabResult { get; set; } = "Pending";
    public DateTime? AcknowledgedAt { get; set; }
    public string VisitNotes { get; set; } = "";
}
