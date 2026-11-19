#nullable enable

namespace PigPass.Views;

partial class ReportForm
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
        this.lblFarm = new Label();
        this.cmbFarm = new ComboBox();
        this.lblPigs = new Label();
        this.numPigs = new NumericUpDown();
        this.lblDays = new Label();
        this.numDays = new NumericUpDown();
        this.lblNotes = new Label();
        this.txtNotes = new TextBox();
        this.btnSubmit = new Button();
        this.lblCase = new Label();
        this.dgvReports = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.numPigs)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
        this.SuspendLayout();
        // lblFarm
        this.lblFarm.Name = "lblFarm";
        this.lblFarm.Text = "Farm";
        this.lblFarm.Location = new System.Drawing.Point(20, 23);
        this.lblFarm.Size = new System.Drawing.Size(90, 20);
        this.lblFarm.AutoSize = false;
        this.lblFarm.TabIndex = 0;
        // cmbFarm
        this.cmbFarm.Name = "cmbFarm";
        this.cmbFarm.Location = new System.Drawing.Point(115, 20);
        this.cmbFarm.Size = new System.Drawing.Size(320, 23);
        this.cmbFarm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbFarm.TabIndex = 1;
        // lblPigs
        this.lblPigs.Name = "lblPigs";
        this.lblPigs.Text = "Pigs affected";
        this.lblPigs.Location = new System.Drawing.Point(20, 58);
        this.lblPigs.Size = new System.Drawing.Size(90, 20);
        this.lblPigs.AutoSize = false;
        this.lblPigs.TabIndex = 2;
        // numPigs
        this.numPigs.Name = "numPigs";
        this.numPigs.Location = new System.Drawing.Point(115, 55);
        this.numPigs.Size = new System.Drawing.Size(90, 23);
        this.numPigs.Maximum = 100000;
        this.numPigs.Minimum = 1;
        this.numPigs.TabIndex = 3;
        // lblDays
        this.lblDays.Name = "lblDays";
        this.lblDays.Text = "Days sick";
        this.lblDays.Location = new System.Drawing.Point(230, 58);
        this.lblDays.Size = new System.Drawing.Size(70, 20);
        this.lblDays.AutoSize = false;
        this.lblDays.TabIndex = 4;
        // numDays
        this.numDays.Name = "numDays";
        this.numDays.Location = new System.Drawing.Point(305, 55);
        this.numDays.Size = new System.Drawing.Size(80, 23);
        this.numDays.Maximum = 365;
        this.numDays.Minimum = 0;
        this.numDays.TabIndex = 5;
        // lblNotes
        this.lblNotes.Name = "lblNotes";
        this.lblNotes.Text = "Notes";
        this.lblNotes.Location = new System.Drawing.Point(20, 93);
        this.lblNotes.Size = new System.Drawing.Size(90, 20);
        this.lblNotes.AutoSize = false;
        this.lblNotes.TabIndex = 6;
        // txtNotes
        this.txtNotes.Name = "txtNotes";
        this.txtNotes.Location = new System.Drawing.Point(115, 90);
        this.txtNotes.Size = new System.Drawing.Size(320, 60);
        this.txtNotes.Multiline = true;
        this.txtNotes.TabIndex = 7;
        // btnSubmit
        this.btnSubmit.Name = "btnSubmit";
        this.btnSubmit.Text = "Submit report";
        this.btnSubmit.Location = new System.Drawing.Point(460, 20);
        this.btnSubmit.Size = new System.Drawing.Size(140, 32);
        this.btnSubmit.UseVisualStyleBackColor = true;
        this.btnSubmit.Click += this.btnSubmit_Click;
        this.btnSubmit.TabIndex = 8;
        // lblCase
        this.lblCase.Name = "lblCase";
        this.lblCase.Location = new System.Drawing.Point(460, 65);
        this.lblCase.Size = new System.Drawing.Size(480, 28);
        this.lblCase.AutoSize = false;
        this.lblCase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblCase.ForeColor = System.Drawing.Color.DarkGreen;
        this.lblCase.TabIndex = 9;
        // dgvReports
        this.dgvReports.Name = "dgvReports";
        this.dgvReports.Location = new System.Drawing.Point(20, 175);
        this.dgvReports.Size = new System.Drawing.Size(920, 365);
        this.dgvReports.ReadOnly = true;
        this.dgvReports.AllowUserToAddRows = false;
        this.dgvReports.AllowUserToDeleteRows = false;
        this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvReports.MultiSelect = false;
        this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvReports.RowHeadersVisible = false;
        this.dgvReports.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.dgvReports.TabIndex = 10;
        // ReportForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Report Sick or Dead Pigs";
        this.ClientSize = new System.Drawing.Size(960, 560);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Controls.Add(this.lblFarm);
        this.Controls.Add(this.cmbFarm);
        this.Controls.Add(this.lblPigs);
        this.Controls.Add(this.numPigs);
        this.Controls.Add(this.lblDays);
        this.Controls.Add(this.numDays);
        this.Controls.Add(this.lblNotes);
        this.Controls.Add(this.txtNotes);
        this.Controls.Add(this.btnSubmit);
        this.Controls.Add(this.lblCase);
        this.Controls.Add(this.dgvReports);
        this.Load += this.ReportForm_Load;
        ((System.ComponentModel.ISupportInitialize)(this.numPigs)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblFarm = null!;
    private ComboBox cmbFarm = null!;
    private Label lblPigs = null!;
    private NumericUpDown numPigs = null!;
    private Label lblDays = null!;
    private NumericUpDown numDays = null!;
    private Label lblNotes = null!;
    private TextBox txtNotes = null!;
    private Button btnSubmit = null!;
    private Label lblCase = null!;
    private DataGridView dgvReports = null!;
}
