namespace Core.Application;

public abstract record BaseCommandWithUser<T> : IBaseCommandWithUser<T>
{    
    public Guid CurrentUserId { get; private set; }
    public void SetUser(Guid currentUserId)
    {
        CurrentUserId = currentUserId;
    }
}
