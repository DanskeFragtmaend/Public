// namespace Df.AuditLogging;
//
// public class AuditLogService : IAuditLogService
// {
//     private readonly IAuditLogSource _source;
//
//     public AuditLogService(IAuditLogSource source)
//     {
//         _source = source;
//     }
//
//     public async Task Insert(Audit audit)
//     {
//         if (string.IsNullOrWhiteSpace(audit.GroupId))
//             audit.GroupId = Guid.NewGuid().ToString();
//         await _source.InsertAsync(audit);
//     }
//
//     public async Task Insert(IList<Audit> audits)
//     {
//         foreach (var audit in audits.Where(a => string.IsNullOrWhiteSpace(a.GroupId)))
//             audit.GroupId = Guid.NewGuid().ToString();
//         await _source.InsertAsync(audits);
//     }
//
//     public async Task<IList<Audit>> GetAudits(string dataId, int detailLevel)
//     {
//         return await _source.GetAuditsAsync(dataId, detailLevel);
//     }
// }