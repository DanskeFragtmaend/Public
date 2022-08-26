# Middleware to handle exceptions thrown in the pipeline

## Usage
Call `app.UseApiExceptionMiddleware` in your startup.cs or program.cs file.

This hooks into the pipeline and will catch any unhandled exceptions and return an error code to the caller.

### Returned object is the ErrorDetails with this signature
```csharp
public class ErrorDetails
{
    /// <summary>The HTTP status code.</summary>
    public int StatusCode { get; set; }
    
    /// <summary>An error message.</summary>
    public string Message { get; set; } = "";
    
    /// <summary>The generated error code. Can be used to track down the error in the logs.</summary>
    public int ErrorCode { get; set; }
}
```

When using this middleware, don't catch exceptions in your controllers (or mappers if using minimal API).

## ErrorCode
The ErrorCode is a deterministic hash generated from the stacktrace of the thrown exception. If the stacktrace differs in any way the ErrorCode will be different.

## Source code
https://www.nuget.org/packages/Df.ApiExceptionMiddleware