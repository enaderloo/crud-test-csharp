using Mc2.CrudTest.Domain.Entities.CustomerAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.TypeConfigurations
{
    public class CustomerTypeConfiguration : BaseConfiguration<Customer, long>, IEntityTypeConfiguration<Customer>
    {
        public CustomerTypeConfiguration(string defaultSchema) : base(defaultSchema) { }


        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            Configure(builder, "Customers");

            builder.HasIndex(p => new { p.Email}).IsUnique();
            builder.HasIndex(p => new { p.Firstname, p.Lastname, p.DateOfBirth }).IsUnique();

            builder.Property(p => p.Firstname)
                .HasMaxLength(1024);

            builder.Property(p => p.Lastname)
                .HasMaxLength(1024);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.BankAccountNumber)
               .HasMaxLength(16)
               .IsRequired();

            builder.Property(p => p.Email)
               .IsRequired();

            builder.Property<bool>("IsDeleted")
                .HasDefaultValue(false);
        }
    }
}
