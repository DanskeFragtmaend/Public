using Microsoft.AspNetCore.Http;

namespace Df.AuditLogging.Middleware;

/// <summary>A user provider</summary>
public interface IAuditUserProvider
{
    AuditUser GetAuditUser(HttpContext context);
}