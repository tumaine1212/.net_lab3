using PigPass.Models;

namespace PigPass.Controllers;

public static class Session
{
    public static User? CurrentUser { get; set; }
}
