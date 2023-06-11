namespace Core.Domain;

public record PaginatedRecord<TSummaryRecord>
{
    public List<TSummaryRecord> Data { get; set; }
    public int AllDataCount { get; init; }
}
