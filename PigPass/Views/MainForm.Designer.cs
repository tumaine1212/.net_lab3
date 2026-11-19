#nullable enable

namespace PigPass.Views;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.mnuFarms = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuPermits = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuOutbreak = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
        this.menuStrip1.SuspendLayout();
        this.statusStrip1.SuspendLayout();
        this.SuspendLayout();
        // menuStrip1
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuFarms, this.mnuReports, this.mnuPermits, this.mnuOutbreak, this.mnuLogout });
        this.menuStrip1.Name = "menuStrip1";
        // mnuFarms
        this.mnuFarms.Name = "mnuFarms";
        this.mnuFarms.Text = "Farms";
        this.mnuFarms.Click += this.mnuFarms_Click;
        // mnuReports
        this.mnuReports.Name = "mnuReports";
        this.mnuReports.Text = "Sick pig reports";
        this.mnuReports.Click += this.mnuReports_Click;
        // mnuPermits
        this.mnuPermits.Name = "mnuPermits";
        this.mnuPermits.Text = "Movement permits";
        this.mnuPermits.Click += this.mnuPermits_Click;
        // mnuOutbreak
        this.mnuOutbreak.Name = "mnuOutbreak";
        this.mnuOutbreak.Text = "Outbreak response";
        this.mnuOutbreak.Click += this.mnuOutbreak_Click;
        // mnuLogout
        this.mnuLogout.Name = "mnuLogout";
        this.mnuLogout.Text = "Logout";
        this.mnuLogout.Click += this.mnuLogout_Click;
        // statusStrip1
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblWelcome });
        this.statusStrip1.Name = "statusStrip1";
        // lblWelcome
        this.lblWelcome.Name = "lblWelcome";
        this.lblWelcome.Text = "";
        // MainForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 650);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.menuStrip1);
        this.IsMdiContainer = true;
        this.MainMenuStrip = this.menuStrip1;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Pig Pass";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.Load += this.MainForm_Load;
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1 = null!;
    private System.Windows.Forms.ToolStripMenuItem mnuFarms = null!;
    private System.Windows.Forms.ToolStripMenuItem mnuReports = null!;
    private System.Windows.Forms.ToolStripMenuItem mnuPermits = null!;
    private System.Windows.Forms.ToolStripMenuItem mnuOutbreak = null!;
    private System.Windows.Forms.ToolStripMenuItem mnuLogout = null!;
    private System.Windows.Forms.StatusStrip statusStrip1 = null!;
    private System.Windows.Forms.ToolStripStatusLabel lblWelcome = null!;
}
