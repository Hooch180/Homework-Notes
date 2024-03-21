using Homework.Application.Common.BaseQueries;
using MediatR;

namespace Homework.Application.Notes.Queries.ListNotes;

public record ListNotesQuery(int PageNumber, int PageSize) : PaginatedQuery(PageNumber, PageSize), IRequest<ListNotesQueryResult>;