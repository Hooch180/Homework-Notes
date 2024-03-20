using Homework.Application.Common.Interfaces.Repositories;
using Notes.Domain.Notes;

namespace Homework.Infrastructure.Notes.Persistence;

public class NotesRepository : INotesRepository
{
    public Task<Note?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Note>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddNoteAsync(Note note)
    {
        throw new NotImplementedException();
    }

    public Task UpdateNoteAsync(Note note)
    {
        throw new NotImplementedException();
    }

    public Task RemoveNoteAsync(Note note)
    {
        throw new NotImplementedException();
    }
}