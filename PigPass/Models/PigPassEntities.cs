namespace PigPass.Models;

public class ControlZone
{
    public int ControlZoneId { get; set; }
    public int SourceFarmId { get; set; }
    public Farm? SourceFarm { get; set; }
    public string ZoneType { get; set; } = "Protection";
    public double RadiusKm { get; set; }
    public DateTime StartedAt { get; set; } = DateTime.Now;
    public DateTime? LiftedAt { get; set; }
    public string Reason { get; set; } = "ASF outbreak";
    public bool IsActive => LiftedAt == null;
}

public class Permit
{
    public int PermitId { get; set; }
    public string PermitNumber { get; set; } = "";
    public string VerificationCode { get; set; } = "";
    public int OriginFarmId { get; set; }
    public Farm? OriginFarm { get; set; }
    public string Destination { get; set; } = "";
    public string Purpose { get; set; } = "Sale";
    public string PigCategory { get; set; } = "Mixed";
    public int PigCount { get; set; }
    public DateTime IntendedDate { get; set; }
    public DateTime IssuedAt { get; set; } = DateTime.Now;
    public DateTime ValidUntil { get; set; }
    public string Status { get; set; } = "Pending";
    public string DecisionReason { get; set; } = "";
    public int? IssuingVeterinarianId { get; set; }
    public User? IssuingVeterinarian { get; set; }
    public int? ReceivedCount { get; set; }
    public DateTime? CompletedAt { get; set; }
}

public class VerificationLog
{
    public int VerificationLogId { get; set; }
    public string PermitNumber { get; set; } = "";
    public string Result { get; set; } = "";
    public string Location { get; set; } = "";
    public int? UserId { get; set; }
    public DateTime VerifiedAt { get; set; } = DateTime.Now;
}

public class Notification
{
    public int NotificationId { get; set; }
    public int? UserId { get; set; }
    public string Recipient { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsRead { get; set; }
}

public class AuditLog
{
    public int AuditLogId { get; set; }
    public int? UserId { get; set; }
    public string Action { get; set; } = "";
    public string EntityName { get; set; } = "";
    public string Details { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class AppSetting
{
    public int AppSettingId { get; set; }
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
}
