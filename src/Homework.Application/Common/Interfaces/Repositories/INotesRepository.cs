using Notes.Domain.Notes;

namespace Homework.Application.Common.Interfaces.Repositories;

public interface INotesRepository
{
    Task<Note?> GetByIdAsync(Guid id);
    Task<IList<Note>> ListAsync();
    Task AddNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task RemoveNoteAsync(Note note);
}