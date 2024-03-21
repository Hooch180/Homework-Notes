namespace Notes.Domain.Notes;

public class Note
{
    public required Guid Id { get; set; }
    public required string Content { get; set; }
}