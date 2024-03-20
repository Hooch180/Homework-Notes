using MediatR;

namespace Homework.Application.Notes.Commands.AddNote;

public record AddNoteCommand : IRequest
{
    public string Content { get; init; }
}