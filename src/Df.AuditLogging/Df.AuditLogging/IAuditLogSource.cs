using System.Collections.ObjectModel;

namespace Df.AuditLogging;

/// <summary>Interface for the database layer. The implementation of this interface must be provided by the user of this package.</summary>
public interface IAuditLogSource
{
    /// <summary>Save an audit to storage</summary>
    /// <param name="audit">The audit to save</param>
    Task InsertAsync(Audit audit);
    
    /// <summary>Save audits to a storage</summary>
    /// <param name="audits">The audits to save</param>
    Task InsertAsync(IReadOnlyList<Audit> audits);
    
    /// <summary>Get all audits for a given dataId</summary>
    /// <param name="dataId">The data ID for the bindings</param>
    /// <param name="detailLevel">Get all with this level and below</param>
    /// <returns>All found audits</returns>
    Task<ReadOnlyCollection<Audit>> GetAuditsAsync(string dataId, int detailLevel);
}