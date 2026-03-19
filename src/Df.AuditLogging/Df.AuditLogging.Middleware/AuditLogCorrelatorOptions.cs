namespace Df.AuditLogging.Middleware;

public class AuditLogCorrelatorOptions
{
    /// <summary>
    /// When true, audit logs will still be saved even if the request throws an exception.
    /// Defaults to false.
    /// </summary>
    public bool SaveOnException { get; set; }
}
