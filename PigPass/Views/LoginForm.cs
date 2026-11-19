using PigPass.Controllers;

namespace PigPass.Views;

public partial class LoginForm : Form
{
    private readonly AuthController _auth = new();

    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        var user = _auth.Login(txtUsername.Text.Trim(), txtPassword.Text);
        if (user == null)
        {
            lblMessage.Text = "Wrong username or password.";
            return;
        }

        Session.CurrentUser = user;
        lblMessage.Text = "";
        txtPassword.Clear();

        var main = new MainForm();
        main.FormClosed += (s, args) => Show();   // back to login after logout
        Hide();
        main.Show();
    }
}
