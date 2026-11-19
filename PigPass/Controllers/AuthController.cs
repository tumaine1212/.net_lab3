using System.Security.Cryptography;
using System.Text;
using PigPass.Data;
using PigPass.Models;

namespace PigPass.Controllers;

public class AuthController
{
    public static string Hash(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }

    public User? Login(string username, string password)
    {
        using var db = new AppDbContext();
        var hash = Hash(password);
        return db.Users.FirstOrDefault(u => u.Username == username
                                         && u.PasswordHash == hash && u.IsActive);
    }
}
