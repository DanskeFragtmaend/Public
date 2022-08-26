namespace Df.AuditLogging;

/// <summary>Interface for the database layer. The implementation of this interface must be provided by the user of this package.</summary>
public interface IAuditLogSource
{
    /// <summary>Save audits to a storage</summary>
    /// <param name="audits">The audits to save</param>
    Task InsertAsync(IReadOnlyList<Audit> audits);
}