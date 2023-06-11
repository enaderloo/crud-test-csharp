namespace Core.Domain;

public abstract class BaseEntityWithDateInfo<PrimaryKeyType> : BaseEntity<PrimaryKeyType>
{
    public BaseEntityWithDateInfo()
    {
        CreatedDate = DateTime.UtcNow;
    }
    public void Update(DateTime? lastUpdateDate = null)
    {
        LastUpdateDate = (lastUpdateDate is null) ? DateTime.UtcNow : lastUpdateDate.Value;
    }
    public DateTime CreatedDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
}