// namespace Df.AuditLogging;
//
// /// <summary>Abstraction between the correlator and the database layer.</summary>
// public interface IAuditLogService
// {
//     Task Insert(Audit audit);
//     Task Insert(IList<Audit>audits);
//     Task<IList<Audit>> GetAudits(string dataId, int detailLevel);
// }