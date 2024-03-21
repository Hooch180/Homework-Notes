namespace Homework.Application.Common.Exceptions;

public class CommandValidationException : ApplicationException
{
    public record Error(string PropertyName, string ErrorMessage, string ErrorCode);
    
    public List<Error> Errors { get; init; }

    public CommandValidationException(IEnumerable<Error> errors)
        : base("VALIDATION_ERROR")
    {
        Errors = errors.ToList();
    }
}