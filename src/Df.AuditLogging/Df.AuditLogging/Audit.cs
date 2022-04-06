namespace Df.AuditLogging;

/// <summary>The audit log entry.</summary>
public class Audit
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string GroupId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>The type of action performed on the data, <see cref="AuditActions"/></summary>
    public string Action { get; set; } = string.Empty;
    /// <summary>The type of the data that the audit is created for</summary>
    public string DataType { get; set; } = string.Empty;
    /// <summary>ID of the data this audit is about</summary>
    public string DataId { get; set; } = string.Empty;
    /// <summary>A sub ID can be provided if needed</summary>
    public string DataSubId { get; set; } = string.Empty;
    /// <summary>The ID of the user who caused the audit</summary>
    public string UserId { get; set; } = string.Empty;
    /// <summary>The name of the user who caused the audit</summary>
    public string UserName { get; set; } = string.Empty;
    /// <summary>Timestamp of the audit in UTC</summary>
    public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    /// <summary>If a data field has been changed, provide the name of the field here</summary>
    public string DataFieldName { get; set; } = string.Empty;
    /// <summary>If a data field has been changed, provide the field type here</summary>
    public string DataFieldType { get; set; } = string.Empty;
    /// <summary>If a data field has been changed, provide the old value here</summary>
    public string DataOldValue { get; set; } = string.Empty;
    /// <summary>If a data field has been changed, provide the new value here</summary>
    public string DataNewValue { get; set; } = string.Empty;
    /// <summary>What was the source of the audit, ie. an application name</summary>
    public string Source { get; set; } = string.Empty;
    /// <summary>A description of the audit</summary>
    public string Message { get; set; } = string.Empty;
    /// <summary>A version of the changed data</summary>
    public string Version { get; set; } = string.Empty;
    /// <summary>A detail level of the audit, a value between 0 and 100, the higher the more detailed</summary>
    public int DetailLevel { get; set; }
    /// <summary>An ID to correlate between API calls (X-Correlation-ID)</summary>
    public string CorrelationId { get; set; } = string.Empty;
}