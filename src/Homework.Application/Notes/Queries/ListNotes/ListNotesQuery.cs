using MediatR;

namespace Homework.Application.Notes.Queries.ListNotes;

public record ListNotesQuery : IRequest<ListNotesQueryResult>;