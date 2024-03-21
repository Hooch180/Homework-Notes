namespace Homework.Application.Common.BaseQueries;

public abstract record PaginatedQuery(int PageNumber, int PageSize) { }