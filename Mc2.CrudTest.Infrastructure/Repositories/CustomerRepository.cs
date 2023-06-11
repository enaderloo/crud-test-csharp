
using Mc2.CrudTest.Domain.Entities.CustomerAggregate;
using Mc2.CrudTest.Domain.IRepository;

namespace Mc2.CrudTest.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, long>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Customer?> GetAsync(long id)
            => await _context.Set<Customer>()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
