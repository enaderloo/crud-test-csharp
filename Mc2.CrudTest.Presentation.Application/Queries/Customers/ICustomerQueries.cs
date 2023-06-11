
using Mc2.CrudTest.Application.ViewModels.Customers;

namespace Mc2.CrudTest.Application.Queries.Customers
{
    public interface ICustomerQueries
    {
        Task<PaginatedCustomerSummary> GetsAsync(CustomerFilter filter);
    }
}
