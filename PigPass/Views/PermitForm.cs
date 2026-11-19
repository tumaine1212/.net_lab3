using PigPass.Controllers;
using PigPass.Data;
using PigPass.Models;

namespace PigPass.Views;

public class PermitForm : Form
{
    private readonly PermitController _permits = new();
    private readonly ComboBox _farm = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };
    private readonly NumericUpDown _count = new() { Minimum = 1, Maximum = 100000, Value = 1, Width = 90 };
    private readonly TextBox _destination = new() { Width = 220 };
    private readonly ComboBox _purpose = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 120 };
    private readonly TextBox _number = new() { Width = 150 };
    private readonly TextBox _code = new() { Width = 100 };
    private readonly TextBox _location = new() { Width = 150 };
    private readonly NumericUpDown _received = new() { Minimum = 0, Maximum = 100000, Width = 90 };
    private readonly DataGridView _grid = new() { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
    private readonly Label _message = new() { AutoSize = true, ForeColor = Color.DarkGreen };

    public PermitForm()
    {
        Text = "Pig Pass - Movement Permits"; Width = 1050; Height = 650; StartPosition = FormStartPosition.CenterParent;
        _purpose.Items.AddRange(new[] { "Sale", "Slaughter", "Breeding" }); _purpose.SelectedIndex = 0;
        var request = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 105, Padding = new Padding(10), WrapContents = true };
        request.Controls.AddRange(new Control[] { new Label { Text = "Origin farm", AutoSize = true }, _farm, new Label { Text = "Pigs", AutoSize = true }, _count, new Label { Text = "Purpose", AutoSize = true }, _purpose, new Label { Text = "Destination", AutoSize = true }, _destination });
        var requestButton = new Button { Text = "Request permit", AutoSize = true }; requestButton.Click += (_, _) => RequestPermit(); request.Controls.Add(requestButton);
        var verify = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 75, Padding = new Padding(10), WrapContents = true };
        verify.Controls.AddRange(new Control[] { new Label { Text = "Permit number", AutoSize = true }, _number, new Label { Text = "Code", AutoSize = true }, _code, new Label { Text = "Location", AutoSize = true }, _location });
        var verifyButton = new Button { Text = "Verify", AutoSize = true }; verifyButton.Click += (_, _) => Verify(); verify.Controls.Add(verifyButton);
        verify.Controls.Add(new Label { Text = "Received", AutoSize = true }); verify.Controls.Add(_received);
        var receiveButton = new Button { Text = "Record receipt for selected", AutoSize = true }; receiveButton.Click += (_, _) => Receive(); verify.Controls.Add(receiveButton);
        var approveButton = new Button { Text = "Approve selected (vet)", AutoSize = true }; approveButton.Click += (_, _) => Approve(); verify.Controls.Add(approveButton);
        Controls.Add(_grid); Controls.Add(verify); Controls.Add(request); Controls.Add(_message);
        Load += (_, _) => LoadData();
    }

    private void LoadData()
    {
        using var db = new AppDbContext();
        _farm.DataSource = db.Farms.Where(f => f.IsActive).OrderBy(f => f.FarmId).ToList(); _farm.DisplayMember = "Display"; _farm.ValueMember = "FarmId";
        _grid.DataSource = _permits.GetAll().Select(p => new { p.PermitId, p.PermitNumber, Code = p.VerificationCode, Farm = p.OriginFarm?.OwnerName, p.PigCount, p.Destination, p.Status, p.ValidUntil, p.DecisionReason }).ToList();
    }

    private void RequestPermit()
    {
        if (_farm.SelectedValue is not int farmId) { _message.Text = "Register a farm first."; return; }
        try { _message.Text = _permits.Request(farmId, (int)_count.Value, "Mixed", _purpose.Text, _destination.Text.Trim(), DateTime.Today); LoadData(); }
        catch (Exception ex) { _message.ForeColor = Color.DarkRed; _message.Text = ex.Message; }
    }

    private void Verify()
    {
        try { var result = _permits.Verify(_number.Text.Trim(), _code.Text.Trim(), _location.Text.Trim()); _message.ForeColor = result.Result == "VALID" ? Color.DarkGreen : Color.DarkRed; _message.Text = result.Permit == null ? result.Result : $"VALID: {result.Permit.PigCount} pigs to {result.Permit.Destination}"; LoadData(); }
        catch (Exception ex) { _message.ForeColor = Color.DarkRed; _message.Text = ex.Message; }
    }

    private void Receive()
    {
        if (_grid.CurrentRow?.Cells[0].Value is not int permitId) { _message.Text = "Select a permit first."; return; }
        try { _permits.RecordReceipt(permitId, (int)_received.Value); _message.ForeColor = Color.DarkGreen; _message.Text = "Receipt recorded; permit cannot be reused."; LoadData(); } catch (Exception ex) { _message.Text = ex.Message; }
    }

    private void Approve()
    {
        if (Session.CurrentUser?.Role is not ("Veterinarian" or "Administrator")) { _message.Text = "Only a veterinarian or administrator can approve permits."; return; }
        if (_grid.CurrentRow?.Cells[0].Value is not int permitId) { _message.Text = "Select a permit first."; return; }
        try { _permits.Approve(permitId, Session.CurrentUser.UserId); _message.ForeColor = Color.DarkGreen; _message.Text = "Permit issued. Copy its number and verification code from the database or permit record."; LoadData(); }
        catch (Exception ex) { _message.ForeColor = Color.DarkRed; _message.Text = ex.Message; }
    }
}
