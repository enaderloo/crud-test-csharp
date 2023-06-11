namespace Core.Domain;

public interface ISortAndPagination : IPagination
{
    public string? OrderBy { get; set; }
    public string? SortDirection { get; set; }
}
