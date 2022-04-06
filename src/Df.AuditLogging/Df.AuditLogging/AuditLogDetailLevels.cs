namespace Df.AuditLogging;

public static class AuditLogDetailLevels
{
    /// <summary>Everyone can see this.</summary>
    public static int Low = 0;
    /// <summary>Everyone can see this if they request it.</summary>
    public static int Medium = 50;
    /// <summary>Only admin can see this.</summary>
    public static int High = 100;
}