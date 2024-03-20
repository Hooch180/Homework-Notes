using Homework.Application.Common.Interfaces;
using Homework.Application.Common.Interfaces.Repositories;
using MediatR;
using Notes.Domain.Notes;

namespace Homework.Application.Notes.Commands.AddNote;

public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand>
{
    private readonly INotesRepository _notesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddNoteCommandHandler(
        INotesRepository notesRepository, 
        IUnitOfWork unitOfWork)
    {
        _notesRepository = notesRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            Content = request.Content,
        };

        await _notesRepository.AddAsync(note);
        await _unitOfWork.CommitChangesAsync();
    }
}