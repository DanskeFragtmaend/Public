namespace Df.AuditLogging;

/// <summary>Collect all audits for a session and save them at the end.</summary>
public interface IAuditLogCorrelator
{
    /// <summary>Adds an audit to the session.</summary>
    /// <param name="audit">The audit to add</param>
    void AddAudit(Audit audit);
    
    /// <summary>Adds multiple audits to the session.</summary>
    /// <param name="audits">The audits to add</param>
    void AddAudits(IEnumerable<Audit> audits);
    
    /// <summary>Called when the session is ending.</summary>
    /// <returns>Task for async/await</returns>
    Task Save();
}