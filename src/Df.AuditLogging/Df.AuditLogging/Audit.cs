namespace Df.AuditLogging;

/// <summary>The audit log entry.</summary>
public class Audit
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string GroupId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>The type of action performed on the data, <see cref="AuditActions"/></summary>
    public string Action { get; set; } = string.Empty;
    /// <summary>The type of the data that the audit is created for.</summary>
    public string DataType { get; set; } = string.Empty;
    public string DataId { get; set; } = string.Empty;
    public string DataSubId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    public string DataFieldName { get; set; } = string.Empty;
    public string DataFieldType { get; set; } = string.Empty;
    public string DataOldValue { get; set; } = string.Empty;
    public string DataNewValue { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public int DetailLevel { get; set; }
}