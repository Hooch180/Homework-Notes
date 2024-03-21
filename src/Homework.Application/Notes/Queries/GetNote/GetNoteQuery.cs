using MediatR;

namespace Homework.Application.Notes.Queries.GetNote;

public record GetNoteQuery(Guid Id) : IRequest<GetNoteQueryResult>;