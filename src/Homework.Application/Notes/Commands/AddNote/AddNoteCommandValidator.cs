using FluentValidation;

namespace Homework.Application.Notes.Commands.AddNote;

public class AddNoteCommandValidator : AbstractValidator<AddNoteCommand>
{
    public AddNoteCommandValidator()
    {
        RuleFor(c => c.Content)
            .MaximumLength(3)
            .WithErrorCode(AddNoteCommandErrorCode.ContentTooLong.Name);
    }
}