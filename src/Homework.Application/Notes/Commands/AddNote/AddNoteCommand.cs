using MediatR;

namespace Homework.Application.Notes.Commands.AddNote;

public record AddNoteCommand(string Content) : IRequest<AddNoteCommandResult>;