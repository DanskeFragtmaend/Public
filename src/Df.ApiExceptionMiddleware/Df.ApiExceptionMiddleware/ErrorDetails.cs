using System.Text.Json;

namespace Df.ApiExceptionMiddleware;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
    public int ErrorCode { get; set; }
    
    public override string ToString() 
    { 
        return JsonSerializer.Serialize(this); 
    }
}