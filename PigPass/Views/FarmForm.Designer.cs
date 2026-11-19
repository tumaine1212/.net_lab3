#nullable enable

namespace PigPass.Views;

partial class FarmForm
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
        this.lblOwner = new Label();
        this.txtOwner = new TextBox();
        this.lblPhone = new Label();
        this.txtPhone = new TextBox();
        this.lblDistrict = new Label();
        this.txtDistrict = new TextBox();
        this.lblSector = new Label();
        this.txtSector = new TextBox();
        this.lblVillage = new Label();
        this.txtVillage = new TextBox();
        this.lblLat = new Label();
        this.txtLat = new TextBox();
        this.lblLon = new Label();
        this.txtLon = new TextBox();
        this.lblSows = new Label();
        this.numSows = new NumericUpDown();
        this.lblBoars = new Label();
        this.numBoars = new NumericUpDown();
        this.lblGrowers = new Label();
        this.numGrowers = new NumericUpDown();
        this.lblPiglets = new Label();
        this.numPiglets = new NumericUpDown();
        this.lblState = new Label();
        this.cmbState = new ComboBox();
        this.btnAdd = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnClear = new Button();
        this.lblSearch = new Label();
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.dgvFarms = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.numSows)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numBoars)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numGrowers)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numPiglets)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvFarms)).BeginInit();
        this.SuspendLayout();
        // lblOwner
        this.lblOwner.Name = "lblOwner";
        this.lblOwner.Text = "Farmer name";
        this.lblOwner.Location = new System.Drawing.Point(20, 23);
        this.lblOwner.Size = new System.Drawing.Size(90, 20);
        this.lblOwner.AutoSize = false;
        this.lblOwner.TabIndex = 0;
        // txtOwner
        this.txtOwner.Name = "txtOwner";
        this.txtOwner.Location = new System.Drawing.Point(115, 20);
        this.txtOwner.Size = new System.Drawing.Size(170, 23);
        this.txtOwner.TabIndex = 1;
        // lblPhone
        this.lblPhone.Name = "lblPhone";
        this.lblPhone.Text = "Phone";
        this.lblPhone.Location = new System.Drawing.Point(20, 53);
        this.lblPhone.Size = new System.Drawing.Size(90, 20);
        this.lblPhone.AutoSize = false;
        this.lblPhone.TabIndex = 2;
        // txtPhone
        this.txtPhone.Name = "txtPhone";
        this.txtPhone.Location = new System.Drawing.Point(115, 50);
        this.txtPhone.Size = new System.Drawing.Size(170, 23);
        this.txtPhone.TabIndex = 3;
        // lblDistrict
        this.lblDistrict.Name = "lblDistrict";
        this.lblDistrict.Text = "District";
        this.lblDistrict.Location = new System.Drawing.Point(20, 83);
        this.lblDistrict.Size = new System.Drawing.Size(90, 20);
        this.lblDistrict.AutoSize = false;
        this.lblDistrict.TabIndex = 4;
        // txtDistrict
        this.txtDistrict.Name = "txtDistrict";
        this.txtDistrict.Location = new System.Drawing.Point(115, 80);
        this.txtDistrict.Size = new System.Drawing.Size(170, 23);
        this.txtDistrict.TabIndex = 5;
        // lblSector
        this.lblSector.Name = "lblSector";
        this.lblSector.Text = "Sector";
        this.lblSector.Location = new System.Drawing.Point(20, 113);
        this.lblSector.Size = new System.Drawing.Size(90, 20);
        this.lblSector.AutoSize = false;
        this.lblSector.TabIndex = 6;
        // txtSector
        this.txtSector.Name = "txtSector";
        this.txtSector.Location = new System.Drawing.Point(115, 110);
        this.txtSector.Size = new System.Drawing.Size(170, 23);
        this.txtSector.TabIndex = 7;
        // lblVillage
        this.lblVillage.Name = "lblVillage";
        this.lblVillage.Text = "Village";
        this.lblVillage.Location = new System.Drawing.Point(20, 143);
        this.lblVillage.Size = new System.Drawing.Size(90, 20);
        this.lblVillage.AutoSize = false;
        this.lblVillage.TabIndex = 8;
        // txtVillage
        this.txtVillage.Name = "txtVillage";
        this.txtVillage.Location = new System.Drawing.Point(115, 140);
        this.txtVillage.Size = new System.Drawing.Size(170, 23);
        this.txtVillage.TabIndex = 9;
        // lblLat
        this.lblLat.Name = "lblLat";
        this.lblLat.Text = "Latitude";
        this.lblLat.Location = new System.Drawing.Point(310, 23);
        this.lblLat.Size = new System.Drawing.Size(80, 20);
        this.lblLat.AutoSize = false;
        this.lblLat.TabIndex = 10;
        // txtLat
        this.txtLat.Name = "txtLat";
        this.txtLat.Location = new System.Drawing.Point(395, 20);
        this.txtLat.Size = new System.Drawing.Size(120, 23);
        this.txtLat.TabIndex = 11;
        // lblLon
        this.lblLon.Name = "lblLon";
        this.lblLon.Text = "Longitude";
        this.lblLon.Location = new System.Drawing.Point(310, 53);
        this.lblLon.Size = new System.Drawing.Size(80, 20);
        this.lblLon.AutoSize = false;
        this.lblLon.TabIndex = 12;
        // txtLon
        this.txtLon.Name = "txtLon";
        this.txtLon.Location = new System.Drawing.Point(395, 50);
        this.txtLon.Size = new System.Drawing.Size(120, 23);
        this.txtLon.TabIndex = 13;
        // lblSows
        this.lblSows.Name = "lblSows";
        this.lblSows.Text = "Sows";
        this.lblSows.Location = new System.Drawing.Point(310, 83);
        this.lblSows.Size = new System.Drawing.Size(80, 20);
        this.lblSows.AutoSize = false;
        this.lblSows.TabIndex = 14;
        // numSows
        this.numSows.Name = "numSows";
        this.numSows.Location = new System.Drawing.Point(395, 80);
        this.numSows.Size = new System.Drawing.Size(120, 23);
        this.numSows.Maximum = 100000;
        this.numSows.Minimum = 0;
        this.numSows.TabIndex = 15;
        // lblBoars
        this.lblBoars.Name = "lblBoars";
        this.lblBoars.Text = "Boars";
        this.lblBoars.Location = new System.Drawing.Point(310, 113);
        this.lblBoars.Size = new System.Drawing.Size(80, 20);
        this.lblBoars.AutoSize = false;
        this.lblBoars.TabIndex = 16;
        // numBoars
        this.numBoars.Name = "numBoars";
        this.numBoars.Location = new System.Drawing.Point(395, 110);
        this.numBoars.Size = new System.Drawing.Size(120, 23);
        this.numBoars.Maximum = 100000;
        this.numBoars.Minimum = 0;
        this.numBoars.TabIndex = 17;
        // lblGrowers
        this.lblGrowers.Name = "lblGrowers";
        this.lblGrowers.Text = "Growers";
        this.lblGrowers.Location = new System.Drawing.Point(310, 143);
        this.lblGrowers.Size = new System.Drawing.Size(80, 20);
        this.lblGrowers.AutoSize = false;
        this.lblGrowers.TabIndex = 18;
        // numGrowers
        this.numGrowers.Name = "numGrowers";
        this.numGrowers.Location = new System.Drawing.Point(395, 140);
        this.numGrowers.Size = new System.Drawing.Size(120, 23);
        this.numGrowers.Maximum = 100000;
        this.numGrowers.Minimum = 0;
        this.numGrowers.TabIndex = 19;
        // lblPiglets
        this.lblPiglets.Name = "lblPiglets";
        this.lblPiglets.Text = "Piglets";
        this.lblPiglets.Location = new System.Drawing.Point(545, 23);
        this.lblPiglets.Size = new System.Drawing.Size(70, 20);
        this.lblPiglets.AutoSize = false;
        this.lblPiglets.TabIndex = 20;
        // numPiglets
        this.numPiglets.Name = "numPiglets";
        this.numPiglets.Location = new System.Drawing.Point(620, 20);
        this.numPiglets.Size = new System.Drawing.Size(120, 23);
        this.numPiglets.Maximum = 100000;
        this.numPiglets.Minimum = 0;
        this.numPiglets.TabIndex = 21;
        // lblState
        this.lblState.Name = "lblState";
        this.lblState.Text = "Status";
        this.lblState.Location = new System.Drawing.Point(545, 53);
        this.lblState.Size = new System.Drawing.Size(70, 20);
        this.lblState.AutoSize = false;
        this.lblState.TabIndex = 22;
        // cmbState
        this.cmbState.Name = "cmbState";
        this.cmbState.Location = new System.Drawing.Point(620, 50);
        this.cmbState.Size = new System.Drawing.Size(120, 23);
        this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbState.TabIndex = 23;
        // btnAdd
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Text = "Add";
        this.btnAdd.Location = new System.Drawing.Point(545, 95);
        this.btnAdd.Size = new System.Drawing.Size(90, 28);
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += this.btnAdd_Click;
        this.btnAdd.TabIndex = 24;
        // btnUpdate
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Text = "Update";
        this.btnUpdate.Location = new System.Drawing.Point(645, 95);
        this.btnUpdate.Size = new System.Drawing.Size(90, 28);
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += this.btnUpdate_Click;
        this.btnUpdate.TabIndex = 25;
        // btnDelete
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Text = "Delete";
        this.btnDelete.Location = new System.Drawing.Point(745, 95);
        this.btnDelete.Size = new System.Drawing.Size(90, 28);
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += this.btnDelete_Click;
        this.btnDelete.TabIndex = 26;
        // btnClear
        this.btnClear.Name = "btnClear";
        this.btnClear.Text = "Clear";
        this.btnClear.Location = new System.Drawing.Point(845, 95);
        this.btnClear.Size = new System.Drawing.Size(90, 28);
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += this.btnClear_Click;
        this.btnClear.TabIndex = 27;
        // lblSearch
        this.lblSearch.Name = "lblSearch";
        this.lblSearch.Text = "Search";
        this.lblSearch.Location = new System.Drawing.Point(20, 183);
        this.lblSearch.Size = new System.Drawing.Size(90, 20);
        this.lblSearch.AutoSize = false;
        this.lblSearch.TabIndex = 28;
        // txtSearch
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Location = new System.Drawing.Point(115, 180);
        this.txtSearch.Size = new System.Drawing.Size(300, 23);
        this.txtSearch.TabIndex = 29;
        // btnSearch
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Text = "Search";
        this.btnSearch.Location = new System.Drawing.Point(425, 178);
        this.btnSearch.Size = new System.Drawing.Size(90, 28);
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Click += this.btnSearch_Click;
        this.btnSearch.TabIndex = 30;
        // dgvFarms
        this.dgvFarms.Name = "dgvFarms";
        this.dgvFarms.Location = new System.Drawing.Point(20, 215);
        this.dgvFarms.Size = new System.Drawing.Size(920, 385);
        this.dgvFarms.ReadOnly = true;
        this.dgvFarms.AllowUserToAddRows = false;
        this.dgvFarms.AllowUserToDeleteRows = false;
        this.dgvFarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvFarms.MultiSelect = false;
        this.dgvFarms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvFarms.RowHeadersVisible = false;
        this.dgvFarms.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.dgvFarms.CellClick += this.dgvFarms_CellClick;
        this.dgvFarms.TabIndex = 31;
        // FarmForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Farm Registry";
        this.ClientSize = new System.Drawing.Size(960, 620);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Controls.Add(this.lblOwner);
        this.Controls.Add(this.txtOwner);
        this.Controls.Add(this.lblPhone);
        this.Controls.Add(this.txtPhone);
        this.Controls.Add(this.lblDistrict);
        this.Controls.Add(this.txtDistrict);
        this.Controls.Add(this.lblSector);
        this.Controls.Add(this.txtSector);
        this.Controls.Add(this.lblVillage);
        this.Controls.Add(this.txtVillage);
        this.Controls.Add(this.lblLat);
        this.Controls.Add(this.txtLat);
        this.Controls.Add(this.lblLon);
        this.Controls.Add(this.txtLon);
        this.Controls.Add(this.lblSows);
        this.Controls.Add(this.numSows);
        this.Controls.Add(this.lblBoars);
        this.Controls.Add(this.numBoars);
        this.Controls.Add(this.lblGrowers);
        this.Controls.Add(this.numGrowers);
        this.Controls.Add(this.lblPiglets);
        this.Controls.Add(this.numPiglets);
        this.Controls.Add(this.lblState);
        this.Controls.Add(this.cmbState);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnClear);
        this.Controls.Add(this.lblSearch);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.dgvFarms);
        this.Load += this.FarmForm_Load;
        ((System.ComponentModel.ISupportInitialize)(this.numSows)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numBoars)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numGrowers)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numPiglets)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvFarms)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblOwner = null!;
    private TextBox txtOwner = null!;
    private Label lblPhone = null!;
    private TextBox txtPhone = null!;
    private Label lblDistrict = null!;
    private TextBox txtDistrict = null!;
    private Label lblSector = null!;
    private TextBox txtSector = null!;
    private Label lblVillage = null!;
    private TextBox txtVillage = null!;
    private Label lblLat = null!;
    private TextBox txtLat = null!;
    private Label lblLon = null!;
    private TextBox txtLon = null!;
    private Label lblSows = null!;
    private NumericUpDown numSows = null!;
    private Label lblBoars = null!;
    private NumericUpDown numBoars = null!;
    private Label lblGrowers = null!;
    private NumericUpDown numGrowers = null!;
    private Label lblPiglets = null!;
    private NumericUpDown numPiglets = null!;
    private Label lblState = null!;
    private ComboBox cmbState = null!;
    private Button btnAdd = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private Button btnClear = null!;
    private Label lblSearch = null!;
    private TextBox txtSearch = null!;
    private Button btnSearch = null!;
    private DataGridView dgvFarms = null!;
}
