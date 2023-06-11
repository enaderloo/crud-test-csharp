namespace Core.Application;

public interface IBaseUpdateWithUserCommand<T, PrimaryKeyType> : IBaseUpdateCommand<T, PrimaryKeyType>
{
    Guid CurrentUserId { get; }
    void SetUser(Guid currentUserId);
}