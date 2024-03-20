using MediatR;

namespace Homework.Application.Notes.Commands.UpdateNote;

public record UpdateNoteCommand(Guid Id, string Content) : IRequest;