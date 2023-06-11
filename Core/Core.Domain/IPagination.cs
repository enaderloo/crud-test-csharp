namespace Core.Domain;

public interface IPagination
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}
