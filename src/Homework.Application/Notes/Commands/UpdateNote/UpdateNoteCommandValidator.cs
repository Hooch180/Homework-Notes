using FluentValidation;
using Homework.Application.Notes.Commands.AddNote;

namespace Homework.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandValidator : AbstractValidator<AddNoteCommand>
{
    public UpdateNoteCommandValidator()
    {
        RuleFor(c => c.Content)
            .MaximumLength(3)
            .WithErrorCode(AddNoteCommandErrorCode.ContentTooLong.Name);
    }
}