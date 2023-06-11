
using Mc2.CrudTest.Domain.Entities.CustomerAggregate;

namespace Mc2.CrudTest.Domain.IRepository
{
    public interface ICustomerRepository : IEntityRepository<Customer, long>
    {
    }
}
