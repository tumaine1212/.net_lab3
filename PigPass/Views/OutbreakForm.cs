using Microsoft.EntityFrameworkCore;
using PigPass.Controllers;
using PigPass.Data;

namespace PigPass.Views;

public class OutbreakForm : Form
{
    private readonly ReportController _reports = new();
    private readonly OutbreakController _outbreaks = new();
    private readonly ComboBox _case = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };
    private readonly ComboBox _result = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 100 };
    private readonly TextBox _notes = new() { Width = 240 };
    private readonly DataGridView _cases = new() { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
    private readonly DataGridView _zones = new() { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
    private readonly Label _message = new() { AutoSize = true, ForeColor = Color.DarkGreen };

    public OutbreakForm()
    {
        Text = "Pig Pass - Outbreak Response"; Width = 1100; Height = 650; StartPosition = FormStartPosition.CenterParent;
        _result.Items.AddRange(new[] { "Positive", "Negative" }); _result.SelectedIndex = 0;
        var actions = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 95, Padding = new Padding(10), WrapContents = true };
        actions.Controls.AddRange(new Control[] { new Label { Text = "Case", AutoSize = true }, _case, new Label { Text = "Lab result", AutoSize = true }, _result, new Label { Text = "Visit notes", AutoSize = true }, _notes });
        var resultButton = new Button { Text = "Save result", AutoSize = true }; resultButton.Click += (_, _) => SaveResult(); actions.Controls.Add(resultButton);
        var confirmButton = new Button { Text = "Confirm outbreak and create zones", AutoSize = true }; confirmButton.Click += (_, _) => Confirm(); actions.Controls.Add(confirmButton);
        var tabs = new TabControl { Dock = DockStyle.Fill };
        var casePage = new TabPage("Cases"); casePage.Controls.Add(_cases); var zonePage = new TabPage("Active zones and affected farms"); zonePage.Controls.Add(_zones); tabs.TabPages.Add(casePage); tabs.TabPages.Add(zonePage);
        Controls.Add(tabs); Controls.Add(actions); Controls.Add(_message);
        Load += (_, _) => LoadData();
    }

    private void LoadData()
    {
        using var db = new AppDbContext();
        var reports = db.SickReports.Include(r => r.Farm).OrderByDescending(r => r.ReportedAt).ToList();
        _case.DataSource = reports; _case.DisplayMember = "CaseRef"; _case.ValueMember = "CaseRef";
        _cases.DataSource = reports.Select(r => new { r.CaseRef, Farm = r.Farm!.OwnerName, r.PigsAffected, r.Status, r.LabResult, r.ReportedAt }).ToList();
        _zones.DataSource = _outbreaks.GetActiveZones().Select(z => new { z.ZoneType, RadiusKm = z.RadiusKm.ToString("0.##"), Farm = z.SourceFarm!.OwnerName, z.StartedAt, AffectedFarms = _outbreaks.GetAffectedFarms().Count }).ToList();
    }

    private void SaveResult()
    {
        if (_case.SelectedValue is not string caseRef) return;
        try { _reports.RecordLabResult(caseRef, _result.Text, _notes.Text.Trim()); _message.ForeColor = Color.DarkGreen; _message.Text = "Laboratory result saved."; LoadData(); }
        catch (Exception ex) { _message.ForeColor = Color.DarkRed; _message.Text = ex.Message; }
    }

    private void Confirm()
    {
        if (_case.SelectedValue is not string caseRef) return;
        try { _message.ForeColor = Color.DarkGreen; _message.Text = _outbreaks.ConfirmOutbreak(caseRef); LoadData(); }
        catch (Exception ex) { _message.ForeColor = Color.DarkRed; _message.Text = ex.Message; }
    }
}
