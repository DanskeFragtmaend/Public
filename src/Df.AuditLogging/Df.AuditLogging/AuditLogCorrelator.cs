using System.Collections.Concurrent;

namespace Df.AuditLogging;

public class AuditLogCorrelator : IAuditLogCorrelator
{
    private readonly IAuditLogSource _source;
    private readonly string _groupId = Guid.NewGuid().ToString();
    private readonly ConcurrentQueue<Audit> _audits = new();

    public AuditLogCorrelator(IAuditLogSource source)
    {
        _source = source;
    }

    public void AddAudit(Audit audit)
    {
        audit.GroupId = _groupId;
        _audits.Enqueue(audit);
    }

    public void AddAudits(IReadOnlyList<Audit> audits)  
    {
        foreach (var audit in audits)
        {
            AddAudit(audit);
        }
    }

    public async Task Save()
    {
        if (_audits.Any())
            await _source.InsertAsync(_audits.ToList());
    }
}