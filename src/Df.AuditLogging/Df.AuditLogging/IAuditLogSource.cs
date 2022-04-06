namespace Df.AuditLogging;

/// <summary>Interface for the database layer. The implementation of this interface must be provided by the user of this package.</summary>
public interface IAuditLogSource
{
    Task InsertAsync(Audit audit);
    Task InsertAsync(IReadOnlyList<Audit> audits);
    Task<IList<Audit>> GetAuditsAsync(string dataId, int detailLevel);
}