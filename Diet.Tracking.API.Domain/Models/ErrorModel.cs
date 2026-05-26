namespace Diet.Tracking.API.Domain.Models;

public class ErrorModel
{
    public int ErroCode  { get; set; }
    public string Message { get; set; }

    public ErrorModel(int erroCode, string message)
    {
        ErroCode = erroCode;
        Message = message;
    }
}