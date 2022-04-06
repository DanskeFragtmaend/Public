namespace Df.AuditLogging;

public static class AuditActions
{
    public const string Create = "Create";
    public const string Update = "Update";
    public const string Delete = "Delete";
    public const string Edit = "Edit";
    public const string Read = "Read";
    public const string Send = "Send";
    public const string Received = "Received";
    public const string Rejected = "Rejected";
    public const string Accepted = "Accepted";
    /// <summary>If the audit var generated automatically by an API and not connected to a specific user event</summary>
    public const string Api = "API";
}