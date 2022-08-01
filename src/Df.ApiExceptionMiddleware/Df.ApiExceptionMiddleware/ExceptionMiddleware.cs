﻿using System.Net;
using Df.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Df.ApiExceptionMiddleware;

/// <summary>
/// A middleware for handling exceptions in your API.
/// The returned StatusCode is determined by the <see cref="ExceptionHandler"/>.
/// The returned ErrorCode is a deterministic hash generated from the stacktrace of the exception.
/// The ErrorCode logged together with the exception.
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    
    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var errorCode = ex.GenerateId();
            _logger.LogError(ex, "ErrorCode: {ErrorCode}, Message: {Message}", errorCode.ToString(), ex.Message);
            await HandleExceptionAsync(context, ex, errorCode);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception, int errorCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var message = exception switch
        {
            AccessViolationException =>  "Access violation error.",
            _ => "Internal Server Error."
        };

        await context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = message,
            ErrorCode = errorCode
        }.ToString());
    }
}