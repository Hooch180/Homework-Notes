namespace Homework.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}