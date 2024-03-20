using Homework.Application.Common.Interfaces.Repositories;
using MediatR;

namespace Homework.Application.Notes.Queries.ListNotes;

public class ListNotesQueryHandler : IRequestHandler<ListNotesQuery, ListNotesQueryResult>
{
    private readonly INotesRepository _notesRepository;

    public ListNotesQueryHandler(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }

    public async Task<ListNotesQueryResult> Handle(ListNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _notesRepository.ListAsync();
        return new ListNotesQueryResult(notes);
    }
}