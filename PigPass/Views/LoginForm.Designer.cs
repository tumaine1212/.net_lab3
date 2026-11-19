#nullable enable

namespace PigPass.Views;

partial class LoginForm
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
        this.lblTitle = new Label();
        this.lblUser = new Label();
        this.txtUsername = new TextBox();
        this.lblPass = new Label();
        this.txtPassword = new TextBox();
        this.btnLogin = new Button();
        this.lblMessage = new Label();
        this.lblHint = new Label();
        this.SuspendLayout();
        // lblTitle
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Text = "Pig Pass Login";
        this.lblTitle.Location = new System.Drawing.Point(30, 20);
        this.lblTitle.Size = new System.Drawing.Size(300, 32);
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.TabIndex = 0;
        // lblUser
        this.lblUser.Name = "lblUser";
        this.lblUser.Text = "Username";
        this.lblUser.Location = new System.Drawing.Point(30, 73);
        this.lblUser.Size = new System.Drawing.Size(80, 20);
        this.lblUser.AutoSize = false;
        this.lblUser.TabIndex = 1;
        // txtUsername
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Location = new System.Drawing.Point(120, 70);
        this.txtUsername.Size = new System.Drawing.Size(200, 23);
        this.txtUsername.TabIndex = 2;
        // lblPass
        this.lblPass.Name = "lblPass";
        this.lblPass.Text = "Password";
        this.lblPass.Location = new System.Drawing.Point(30, 108);
        this.lblPass.Size = new System.Drawing.Size(80, 20);
        this.lblPass.AutoSize = false;
        this.lblPass.TabIndex = 3;
        // txtPassword
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Location = new System.Drawing.Point(120, 105);
        this.txtPassword.Size = new System.Drawing.Size(200, 23);
        this.txtPassword.UseSystemPasswordChar = true;
        this.txtPassword.TabIndex = 4;
        // btnLogin
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Text = "Login";
        this.btnLogin.Location = new System.Drawing.Point(120, 145);
        this.btnLogin.Size = new System.Drawing.Size(100, 30);
        this.btnLogin.UseVisualStyleBackColor = true;
        this.btnLogin.Click += this.btnLogin_Click;
        this.btnLogin.TabIndex = 5;
        // lblMessage
        this.lblMessage.Name = "lblMessage";
        this.lblMessage.Location = new System.Drawing.Point(30, 190);
        this.lblMessage.Size = new System.Drawing.Size(300, 36);
        this.lblMessage.AutoSize = false;
        this.lblMessage.ForeColor = System.Drawing.Color.Red;
        this.lblMessage.TabIndex = 6;
        // lblHint
        this.lblHint.Name = "lblHint";
        this.lblHint.Text = "Demo: admin/admin123, vet/vet123, farmer/farmer123";
        this.lblHint.Location = new System.Drawing.Point(30, 230);
        this.lblHint.Size = new System.Drawing.Size(320, 20);
        this.lblHint.AutoSize = false;
        this.lblHint.ForeColor = System.Drawing.Color.Gray;
        this.lblHint.TabIndex = 7;
        // LoginForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Pig Pass - Login";
        this.ClientSize = new System.Drawing.Size(360, 270);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.AcceptButton = this.btnLogin;
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblUser);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblPass);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.lblMessage);
        this.Controls.Add(this.lblHint);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblTitle = null!;
    private Label lblUser = null!;
    private TextBox txtUsername = null!;
    private Label lblPass = null!;
    private TextBox txtPassword = null!;
    private Button btnLogin = null!;
    private Label lblMessage = null!;
    private Label lblHint = null!;
}
