using PigPass.Controllers;

namespace PigPass.Views;

public partial class ReportForm : Form
{
    private readonly FarmController _farms = new();
    private readonly ReportController _reports = new();

    public ReportForm()
    {
        InitializeComponent();
    }

    private void ReportForm_Load(object? sender, EventArgs e)
    {
        cmbFarm.DataSource = _farms.GetAll();
        cmbFarm.DisplayMember = "Display";
        cmbFarm.ValueMember = "FarmId";
        LoadGrid();
    }

    private void LoadGrid() => dgvReports.DataSource = _reports.GetAll();

    private void btnSubmit_Click(object? sender, EventArgs e)
    {
        if (cmbFarm.SelectedValue == null)
        {
            MessageBox.Show("Register a farm first.");
            return;
        }

        int farmId = (int)cmbFarm.SelectedValue;
        string caseRef = _reports.Create(farmId, (int)numPigs.Value, (int)numDays.Value, txtNotes.Text.Trim());

        lblCase.Text = "Case reference: " + caseRef;
        txtNotes.Clear();
        LoadGrid();
    }
}
