using Homework.Application.Common.Exceptions;
using Homework.Application.Common.Interfaces;
using Homework.Application.Common.Interfaces.Repositories;
using MediatR;

namespace Homework.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
{
    private readonly INotesRepository _notesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNoteCommandHandler(
        INotesRepository notesRepository, 
        IUnitOfWork unitOfWork)
    {
        _notesRepository = notesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _notesRepository.GetByIdAsync(request.Id);
        if (note is null)
        {
            throw new NotFoundException();
        }
        
        note.Content = request.Content;
        
        await _notesRepository.UpdateAsync(note);
        await _unitOfWork.CommitChangesAsync();
    }
}