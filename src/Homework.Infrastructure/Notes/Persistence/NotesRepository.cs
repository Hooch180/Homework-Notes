using Homework.Application.Common.Interfaces.Repositories;
using Homework.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Notes.Domain.Notes;

namespace Homework.Infrastructure.Notes.Persistence;

public class NotesRepository : INotesRepository
{
    private readonly HomeworkDbContext _db;

    public NotesRepository(HomeworkDbContext dbContext)
    {
        _db = dbContext;
    }

    public Task<Note?> GetByIdAsync(Guid id)
    {
        return _db.Notes.FirstOrDefaultAsync(note => note.Id == id);
    }

    public async Task<List<Note>> ListAsync()
    {
        return await _db.Notes.ToListAsync();
    }

    public async Task AddAsync(Note note)
    {
        await _db.Notes.AddAsync(note);
    }

    public Task UpdateAsync(Note note)
    {
        _db.Notes.Update(note);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Note note)
    {
        _db.Notes.Remove(note);
        return Task.CompletedTask;
    }
}