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
        var (notes, totalCount) = await _notesRepository.GetPageAsync(request.PageNumber, request.PageSize);
        
        return new ListNotesQueryResult()
        {
            Items = notes,
            PageSize = request.PageSize,
            CurrentPageNumber= request.PageNumber,
            TotalEntries = totalCount,
            MaxPageNumber = (int)Math.Ceiling((double)totalCount / request.PageSize)
        };
    }
}