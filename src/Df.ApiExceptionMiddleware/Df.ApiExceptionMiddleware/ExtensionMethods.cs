namespace Df.ApiExceptionMiddleware;

public static class ExtensionMethods
{
    /// <summary>Custom implementation of GetHashCode that is deterministic.</summary>
    /// <remarks>This is because GetHashCode in .NET Core only is deterministic within same scope.</remarks>
    public static int GetDeterministicHashCode(this string str)
    {
        unchecked
        {
            var hash1 = (5381 << 16) + 5381;
            var hash2 = hash1;

            for (var i = 0; i < str.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return Math.Abs(hash1 + hash2 * 1566083941);
        }
    }
    
    /// <summary>Generates a deterministic ID based on the stack trace of the exception.</summary>
    public static int GenerateId(this Exception ex)
    {
        return $"{ex.GetType().Name}{ex.StackTrace}".GetDeterministicHashCode();
    }
}
