namespace Homework.Application.Common.Exceptions;

public class ApplicationException : Exception
{
    public string Code { get; init; }
    
    public ApplicationException(string code)
    {
        Code = code;
    }
}