using Mc2.CrudTest.Application.ViewModels.Customers;
using Mc2.CrudTest.Domain.IRepository;

namespace Mc2.CrudTest.Application.Queries.Customers
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly ICustomerRepository _repository;

        public CustomerQueries(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<PaginatedCustomerSummary> GetsAsync(CustomerFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
