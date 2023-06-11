namespace Core.Domain;

public abstract class BaseEntityWithCreatorInfo<PrimaryKeyType> : BaseEntityWithDateInfo<PrimaryKeyType>
{
    public BaseEntityWithCreatorInfo(Guid creatorUserId) : base()
    {
        CreatorUserId = creatorUserId;
    }
    public void Update(Guid lastUpdateUserId, DateTime? lastUpdateDate=null)
    {
        LastUpdateUserId = lastUpdateUserId;
        base.Update(lastUpdateDate);
    }

    public Guid CreatorUserId { get; private set; }

    public Guid? LastUpdateUserId { get; private set; }
}