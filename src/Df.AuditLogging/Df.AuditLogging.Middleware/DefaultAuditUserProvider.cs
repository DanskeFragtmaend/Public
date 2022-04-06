using Microsoft.AspNetCore.Http;

namespace Df.AuditLogging.Middleware;

/// <summary>A default implementation of a user provider. Takes the ID from 'sub' claim and name from 'name' claim.</summary>
public class DefaultAuditUserProvider : IAuditUserProvider
{
    public AuditUser GetAuditUser(HttpContext context)
    {
        var user = context.User;
        if (user == null)
        {
            return new AuditUser();
        }

        return new AuditUser
        {
            Id = user.Claims.First(x => x.Type == "sub").Value,
            Name = user.Claims.First(x => x.Type == "name").Value
        };
    }
}