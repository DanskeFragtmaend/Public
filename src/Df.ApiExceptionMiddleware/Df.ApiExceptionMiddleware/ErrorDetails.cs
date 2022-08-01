using System.Text.Json;

namespace Df.ApiExceptionMiddleware;

/// <summary>Contains the data sent back by the API when an error occurs.</summary>
public class ErrorDetails
{
    /// <summary>The HTTP status code.</summary>
    public int StatusCode { get; set; }
    
    /// <summary>An error message.</summary>
    public string Message { get; set; } = "";
    
    /// <summary>The generated error code. Can be used to track down the error in the logs.</summary>
    public int ErrorCode { get; set; }
    
    public override string ToString() 
    { 
        return JsonSerializer.Serialize(this); 
    }
}