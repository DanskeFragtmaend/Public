# A framework to handle audit logging in a more consistent way

There are two packages for this purpose:
- [Df.AuditLogging](https://www.nuget.org/packages/Df.AuditLogging) - for logging for correlating the audits for a request .
- [Df.AuditLogging.Middleware](https://www.nuget.org/packages/Df.AuditLogging.Middleware) - for hooking into the pipeline and logging the request and response.

## Usage
Call `pp.UseAuditLogCorrelator();` in your startup.cs or program.cs file.

And by getting the `IAuditLogCorrelator` from the DI container where ever you need to audit log and calling `AddAudit()` and `AddAudits()`.

## Source code
https://github.com/DanskeFragtmaend/Public/tree/master/src/Df.AuditLogging

## Correlation
All audits in a request are put into a group with a unique ID (GUID). This ID should be saved with the audit.

`X-Correlation-Id` from the HTTP header is also retrieved and saved to the last audit.

## IAuditUserProvider
The `IAuditUserProvider` interface is used to get the user ID for the current request. This is used to save the user ID with the audit.
A default implementation is provided with `DefaultAuditUserProvider`, otherwise implement your own.

## IAuditLogSource
The `IAuditLogSource` interface is used to save the audits to a storage.
An implementation of this interface is provided by the consumer of this framework.

### Saving the audits
`IAuditLogSource.InsertAsync` is called automatically when the request is finished. This is done by the `AuditLogCorrelatorMiddleware`.