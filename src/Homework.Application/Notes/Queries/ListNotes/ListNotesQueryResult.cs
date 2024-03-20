using Notes.Domain.Notes;

namespace Homework.Application.Notes.Queries.ListNotes;

public record ListNotesQueryResult(List<Note> Notes);