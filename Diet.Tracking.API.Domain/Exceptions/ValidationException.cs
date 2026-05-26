namespace Diet.Tracking.API.Domain.Exceptions;

public class ValidationException : Exception
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public ValidationException(int errorCode, string errorMessage) : base(errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    } 
}