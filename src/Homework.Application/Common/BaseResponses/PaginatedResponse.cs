namespace Homework.Application.Common.BaseResponses;

public abstract record PaginatedResponse<TItemType>
{
    public List<TItemType> Items { get; init; }
    public int CurrentPageNumber { get; init; }
    public int MaxPageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalEntries { get; init; }
}