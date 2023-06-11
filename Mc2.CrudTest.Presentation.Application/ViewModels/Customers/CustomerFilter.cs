

using Core.Domain;

namespace Mc2.CrudTest.Application.ViewModels.Customers
{
    public record CustomerFilter : ISortAndPagination
    {
        public string? OrderBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? SortDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PageSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PageIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
