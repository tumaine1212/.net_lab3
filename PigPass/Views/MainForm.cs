using PigPass.Controllers;

namespace PigPass.Views;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        var u = Session.CurrentUser!;
        lblWelcome.Text = $"Logged in as {u.FullName} ({u.Role})";
        mnuOutbreak.Visible = u.Role is "Veterinarian" or "Command Post Officer" or "Administrator";
        mnuPermits.Visible = true;
    }

    private void mnuPermits_Click(object? sender, EventArgs e)
    {
        var f = new PermitForm { MdiParent = this };
        f.Show();
    }

    private void mnuOutbreak_Click(object? sender, EventArgs e)
    {
        var f = new OutbreakForm { MdiParent = this };
        f.Show();
    }

    private void mnuFarms_Click(object? sender, EventArgs e)
    {
        var f = new FarmForm { MdiParent = this };
        f.Show();
    }

    private void mnuReports_Click(object? sender, EventArgs e)
    {
        var f = new ReportForm { MdiParent = this };
        f.Show();
    }

    private void mnuLogout_Click(object? sender, EventArgs e)
    {
        Session.CurrentUser = null;
        Close();
    }
}
