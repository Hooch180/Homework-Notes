using Homework.Application.Common.Exceptions;
using Homework.Application.Common.Interfaces.Repositories;
using MediatR;

namespace Homework.Application.Notes.Queries.GetNote;

public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, GetNoteQueryResult>
{
    private readonly INotesRepository _noteRepository;

    public GetNoteQueryHandler(INotesRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<GetNoteQueryResult> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetByIdAsync(request.Id);
        if (note is null)
            throw new NotFoundException();
        
        return new GetNoteQueryResult(note);
    }
}