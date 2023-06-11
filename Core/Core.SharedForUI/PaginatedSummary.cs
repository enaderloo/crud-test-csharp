namespace Core.SharedForUI;
public record PaginatedSummary<T>
{
    public T[] Data { get; set; }
    public int AllDataCount { get; set; }
}
