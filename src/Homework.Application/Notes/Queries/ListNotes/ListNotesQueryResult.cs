using Homework.Application.Common.BaseResponses;
using Notes.Domain.Notes;

namespace Homework.Application.Notes.Queries.ListNotes;

public record ListNotesQueryResult() : PaginatedResponse<Note>;