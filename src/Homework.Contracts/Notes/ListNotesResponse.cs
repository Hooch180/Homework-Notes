namespace Notes.Contracts.Notes;

public record ListNotesResponse(ICollection<Note> Notes);