using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data;

public class BaseEntityWithCreatorInfoTypeConfiguration<T, K> : BaseConfiguration<T, K> where T : BaseEntityWithCreatorInfo<K>
{
    public void Configure(EntityTypeBuilder<T> builder, string tableName)
    {
        base.Configure(builder, tableName);
        builder.Property(p => p.CreatedDate).IsRequired();
        builder.Property(p => p.CreatorUserId).IsRequired();


        builder.Property(p => p.LastUpdateDate).IsRequired();
        builder.Property(p => p.LastUpdateUserId).IsRequired();

    }
    public BaseEntityWithCreatorInfoTypeConfiguration(string defaultSchema) : base(defaultSchema) { }
}