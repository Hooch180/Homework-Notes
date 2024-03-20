namespace Notes.Contracts.Notes;

public record ListNotesResponse(ICollection<ListNotesResponse.Note> Notes)
{
    public record Note(Guid Id, string Content);
}