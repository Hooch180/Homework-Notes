namespace Homework.Application.Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException() : base("NOT_FOUND")
    {
        
    }
}