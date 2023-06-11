
using Mc2.CrudTest.Domain.Entities.CustomerAggregate;
using Mc2.CrudTest.Infrastructure.TypeConfigurations;
using MediatR;

namespace Mc2.CrudTest.Infrastructure
{
    public class ApplicationDbContext: BaseDbContext
    {
        public readonly IMediator _mediator;
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            DEFAULT_SCHEMA = "DEFAULT_SCHEMA";
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : this(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration(DEFAULT_SCHEMA));

            // if we have ENUM
            //modelBuilder.Entity<Enum>(ConfigureEnumuration);
        }
    }
}
