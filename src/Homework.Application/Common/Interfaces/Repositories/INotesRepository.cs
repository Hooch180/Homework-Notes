using Notes.Domain.Notes;

namespace Homework.Application.Common.Interfaces.Repositories;

public interface INotesRepository
{
    Task<Note?> GetByIdAsync(Guid id);
    Task<List<Note>> ListAsync();
    Task AddAsync(Note note);
    Task UpdateAsync(Note note);
    Task RemoveAsync(Note note);
}