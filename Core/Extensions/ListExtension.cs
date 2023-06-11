namespace Extensions;

public static class ListExtension
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int? pageSize, int? pageIndex)
    {
        if (pageSize is null)
            pageSize = 10;
        if (pageIndex is null)
            pageIndex = 0;
        if (pageSize == 0)
            return query;
        return query.Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value);
    }
}
