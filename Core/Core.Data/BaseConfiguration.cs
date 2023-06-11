using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data;

public class BaseConfiguration<T, K> where T : BaseEntity<K>
{
    public virtual void Configure(EntityTypeBuilder<T> builder, string tableName)
    {
        builder.ToTable(tableName, _defaultSchema);
        builder.Ignore(b => b.DomainEvents);
        builder.HasKey(field => field.Id);
        builder.Property("Id").ValueGeneratedOnAdd().IsRequired();
    }
    public BaseConfiguration(string defaultSchema) => _defaultSchema = defaultSchema;

    protected readonly string _defaultSchema;
}