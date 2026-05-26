namespace Diet.Tracking.API.Domain.Exceptions;

public class ValidationException : Exception
{
    public int ErrorCode { get; }
    public ValidationException(int errorCode, string errorMessage) : base(errorMessage)
    {
        ErrorCode = errorCode;
    }
}