namespace Notes.Contracts.Common;

public record PaginatedResponse<TItemType>
{
    public ICollection<TItemType> Items { get; init; }
    public int CurrentPageNumber { get; init; }
    public int MaxPageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalEntries { get; init; }
}