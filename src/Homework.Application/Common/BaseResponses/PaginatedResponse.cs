namespace Homework.Application.Common.BaseResponses;

public abstract record PaginatedResponse<TItemType>
{
    public required List<TItemType> Items { get; init; }
    public required int CurrentPageNumber { get; init; }
    public required int MaxPageNumber { get; init; }
    public required int PageSize { get; init; }
    public required int TotalEntries { get; init; }
}