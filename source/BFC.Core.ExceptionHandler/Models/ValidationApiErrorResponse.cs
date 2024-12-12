namespace ExceptionHandler.Models;

public class ValidationApiErrorResponse : ApiErrorResponse
{
    public IEnumerable<string> Errors { get; set; }
}