using Microsoft.EntityFrameworkCore;
using PigPass.Models;

namespace PigPass.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Farm> Farms => Set<Farm>();
    public DbSet<SickReport> SickReports => Set<SickReport>();
    public DbSet<ControlZone> ControlZones => Set<ControlZone>();
    public DbSet<Permit> Permits => Set<Permit>();
    public DbSet<VerificationLog> VerificationLogs => Set<VerificationLog>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<AppSetting> AppSettings => Set<AppSetting>();

    // The database file lives next to the .exe
    private static readonly string DbPath =
        Path.Combine(AppContext.BaseDirectory, "pigpass.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<User>().HasIndex(u => u.Username).IsUnique();
        b.Entity<Permit>().HasIndex(p => p.PermitNumber).IsUnique();
        b.Entity<Permit>().HasIndex(p => p.VerificationCode);
        b.Entity<AppSetting>().HasIndex(s => s.Name).IsUnique();
        b.Entity<ControlZone>().HasOne(z => z.SourceFarm).WithMany()
            .HasForeignKey(z => z.SourceFarmId).OnDelete(DeleteBehavior.Restrict);
        b.Entity<Permit>().HasOne(p => p.OriginFarm).WithMany()
            .HasForeignKey(p => p.OriginFarmId).OnDelete(DeleteBehavior.Restrict);
        b.Entity<Permit>().HasOne(p => p.IssuingVeterinarian).WithMany()
            .HasForeignKey(p => p.IssuingVeterinarianId).OnDelete(DeleteBehavior.SetNull);
    }
}
