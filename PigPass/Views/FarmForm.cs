using PigPass.Controllers;
using PigPass.Models;

namespace PigPass.Views;

public partial class FarmForm : Form
{
    private readonly FarmController _ctrl = new();
    private int _selectedId = 0;

    public FarmForm()
    {
        InitializeComponent();
        BackColor = Color.Honeydew;
        dgvFarms.BackgroundColor = Color.White;
        dgvFarms.GridColor = Color.LightGreen;
        btnAdd.BackColor = Color.SeaGreen;
        btnAdd.ForeColor = Color.White;
        btnUpdate.BackColor = Color.SteelBlue;
        btnUpdate.ForeColor = Color.White;
        btnDelete.BackColor = Color.IndianRed;
        btnDelete.ForeColor = Color.White;
        btnClear.BackColor = Color.DarkGray;
        btnClear.ForeColor = Color.White;
    }

    private void FarmForm_Load(object? sender, EventArgs e)
    {
        cmbState.Items.AddRange(new object[] { "Normal", "Suspected", "Infected" });
        cmbState.SelectedIndex = 0;
        if (Session.CurrentUser?.Role == "Farmer")
            btnDelete.Enabled = false;
        LoadGrid();
    }

    private void LoadGrid(string term = "")
    {
        dgvFarms.DataSource = string.IsNullOrWhiteSpace(term) ? _ctrl.GetAll() : _ctrl.Search(term);
    }

    private Farm ReadForm()
    {
        double.TryParse(txtLat.Text, out double lat);
        double.TryParse(txtLon.Text, out double lon);
        return new Farm
        {
            FarmId = _selectedId,
            OwnerName = txtOwner.Text.Trim(),
            Phone = txtPhone.Text.Trim(),
            District = txtDistrict.Text.Trim(),
            Sector = txtSector.Text.Trim(),
            Village = txtVillage.Text.Trim(),
            Latitude = lat,
            Longitude = lon,
            Sows = (int)numSows.Value,
            Boars = (int)numBoars.Value,
            Growers = (int)numGrowers.Value,
            Piglets = (int)numPiglets.Value,
            State = cmbState.SelectedItem?.ToString() ?? "Normal"
        };
    }

    private void ClearForm()
    {
        _selectedId = 0;
        txtOwner.Clear(); txtPhone.Clear(); txtDistrict.Clear(); txtSector.Clear();
        txtVillage.Clear(); txtLat.Clear(); txtLon.Clear();
        numSows.Value = 0; numBoars.Value = 0; numGrowers.Value = 0; numPiglets.Value = 0;
        cmbState.SelectedIndex = 0;
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        var farm = ReadForm();
        farm.FarmId = 0;
        string error = _ctrl.Validate(farm, true);
        if (error != "") { MessageBox.Show(error, "Check input"); return; }

        _ctrl.Add(farm);
        MessageBox.Show("Farm registered. Farm ID: " + farm.FarmId);
        ClearForm();
        LoadGrid();
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedId == 0) { MessageBox.Show("Select a farm in the table first."); return; }

        var farm = ReadForm();
        string error = _ctrl.Validate(farm, false);
        if (error != "") { MessageBox.Show(error, "Check input"); return; }

        _ctrl.Update(farm);
        MessageBox.Show("Farm updated.");
        ClearForm();
        LoadGrid();
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (_selectedId == 0) { MessageBox.Show("Select a farm in the table first."); return; }
        if (MessageBox.Show("Deactivate this farm?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        _ctrl.Delete(_selectedId);
        ClearForm();
        LoadGrid();
    }

    private void btnSearch_Click(object? sender, EventArgs e) => LoadGrid(txtSearch.Text);

    private void btnClear_Click(object? sender, EventArgs e)
    {
        ClearForm();
        txtSearch.Clear();
        LoadGrid();
    }

    private void dgvFarms_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var f = (Farm)dgvFarms.Rows[e.RowIndex].DataBoundItem!;

        _selectedId = f.FarmId;
        txtOwner.Text = f.OwnerName;
        txtPhone.Text = f.Phone;
        txtDistrict.Text = f.District;
        txtSector.Text = f.Sector;
        txtVillage.Text = f.Village;
        txtLat.Text = f.Latitude.ToString();
        txtLon.Text = f.Longitude.ToString();
        numSows.Value = f.Sows;
        numBoars.Value = f.Boars;
        numGrowers.Value = f.Growers;
        numPiglets.Value = f.Piglets;
        cmbState.SelectedItem = f.State;
    }
}
