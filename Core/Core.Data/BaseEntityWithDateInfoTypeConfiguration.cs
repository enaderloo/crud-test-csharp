using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data;

public class BaseEntityWithDateInfoTypeConfiguration<T, K> : BaseConfiguration<T, K> where T : BaseEntityWithDateInfo<K>
{
    public void Configure(EntityTypeBuilder<T> builder, string tableName)
    {
        base.Configure(builder, tableName);
        builder.Property(p => p.CreatedDate).IsRequired();

        builder.Property(p => p.LastUpdateDate).IsRequired();

    }
    public BaseEntityWithDateInfoTypeConfiguration(string defaultSchema) : base(defaultSchema) { }
}