using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Df.AuditLogging.Middleware;

public class AuditLogCorrelatorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuditLogCorrelatorOptions _options;

    public AuditLogCorrelatorMiddleware(RequestDelegate next, IOptions<AuditLogCorrelatorOptions> options)
    {
        _next = next;
        _options = options.Value;
    }

    public async Task InvokeAsync(HttpContext context, IAuditLogCorrelator auditLogCorrelator, IAuditUserProvider userProvider)
    {
        Exception? requestException = null;

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            requestException = ex;

            if (!_options.SaveOnException)
                throw;
        }

        // Run after all other middleware has executed
        try
        {
            var user = userProvider.GetAuditUser(context);
            var userAudit = new Audit
            {
                Action = context.Request.Path,
                Message = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}",
                Source = "API",
                DataId = GetDataId(context.Request),
                DetailLevel = AuditLogDetailLevels.High, // use high level because it's a system audit
                UserId = user.Id,
                UserName = user.Name,
                Version = "0.0",
                CorrelationId = GetCorrelationId(context)
            };
            auditLogCorrelator.AddAudit(userAudit);
        }
        catch (Exception)
        {
            /* ignore, nothing can be done about it */
        }

        await auditLogCorrelator.Save();

        if (requestException != null)
            throw requestException;
    }

    /// <summary>Gets the context correlation ID if it exists</summary>
    private static string GetCorrelationId(HttpContext context)
    {
        var correlationId = context.Request.Headers["X-Correlation-ID"];
        return string.IsNullOrEmpty(correlationId) ? string.Empty : correlationId.ToString();
    }

    /// <summary>This method will try to get a request ID from the query</summary>
    private static string GetDataId(HttpRequest request)
    {
        if (request.Query.ContainsKey("id"))
            return request.Query["id"];
        if (request.Query.ContainsKey("dataId"))
            return request.Query["dataId"];
        return string.Empty;
    }
}