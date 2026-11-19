namespace PigPass.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Role { get; set; } = "Farmer";   // Farmer, Veterinarian, Administrator...
    public bool IsActive { get; set; } = true;
}
