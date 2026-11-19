namespace PigPass.Models;

// Flat row used to show reports in a DataGridView
public class ReportRow
{
    public string CaseRef { get; set; } = "";
    public string Farm { get; set; } = "";
    public int Pigs { get; set; }
    public int Days { get; set; }
    public DateTime Reported { get; set; }
    public string Status { get; set; } = "";
}
