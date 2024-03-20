using Homework.Application.Common.Interfaces;
using Homework.Application.Common.Interfaces.Repositories;
using MediatR;

namespace Homework.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly INotesRepository _notesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNoteCommandHandler(
        INotesRepository notesRepository, 
        IUnitOfWork unitOfWork)
    {
        _notesRepository = notesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _notesRepository.GetByIdAsync(request.Id);
        if (note is null)
        {
            return; // Deletion of non-existing note is not an error
        }
        
        await _notesRepository.RemoveAsync(note);
        await _unitOfWork.CommitChangesAsync();
    }
}