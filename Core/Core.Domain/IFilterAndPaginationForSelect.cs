namespace Core.Domain;

public interface IFilterAndPaginationForSelect : IPagination
{
    public string? SearchTerm { get; set; }
}
