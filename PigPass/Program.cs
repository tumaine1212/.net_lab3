using PigPass.Data;
using PigPass.Views;

namespace PigPass;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();   // creates pigpass.db and the tables if missing
            DbSeeder.Seed(db);             // adds demo users and a sample farm once
        }

        Application.Run(new LoginForm());
    }
}
