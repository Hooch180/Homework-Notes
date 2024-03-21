using Notes.Contracts.Common;

namespace Notes.Contracts.Notes;

public record ListNotesResponse() : PaginatedResponse<Note>;