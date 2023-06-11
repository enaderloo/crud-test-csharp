namespace Core.SharedForUI;
public record SortAndPagingInput
{
    public SortAndPagingInput()
    {
        PageSize = 10;
        PageIndex = 0;
    }
    public string? OrderBy { get; set; }
    public string? SortDirection { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}