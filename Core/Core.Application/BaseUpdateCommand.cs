namespace Core.Application;

public abstract record BaseUpdateCommand<T, PrimaryKeyType> : IBaseUpdateCommand<T, PrimaryKeyType>
{
    public PrimaryKeyType Id { get; protected set; }
    public abstract void SetId(PrimaryKeyType id);
}