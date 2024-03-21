using Ardalis.SmartEnum;

namespace Homework.Application.Notes.Commands.AddNote;

public sealed class AddNoteCommandErrorCode : SmartEnum<AddNoteCommandErrorCode>
{
    public static readonly AddNoteCommandErrorCode ContentTooLong = new("CONTENT_TOO_LONG", 1);

    private AddNoteCommandErrorCode(string name, int value) : base(name, value)
    {
    }
}