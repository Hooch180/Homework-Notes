namespace Notes.Contracts.Common;

public record PaginatedResponse<TItemType>
{
    public required ICollection<TItemType> Items { get; init; }
    public required int CurrentPageNumber { get; init; }
    public required int MaxPageNumber { get; init; }
    public required int PageSize { get; init; }
    public required int TotalEntries { get; init; }
}