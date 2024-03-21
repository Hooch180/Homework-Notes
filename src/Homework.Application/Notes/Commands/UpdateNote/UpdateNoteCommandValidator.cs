using FluentValidation;

namespace Homework.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
{
    public UpdateNoteCommandValidator()
    {
        RuleFor(c => c.Content)
            .MaximumLength(1000)
            .WithErrorCode("CONTENT_TOO_LONG");
    }
}