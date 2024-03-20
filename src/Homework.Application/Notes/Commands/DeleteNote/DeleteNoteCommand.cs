using MediatR;

namespace Homework.Application.Notes.Commands.DeleteNote;

public record DeleteNoteCommand(Guid Id) : IRequest;