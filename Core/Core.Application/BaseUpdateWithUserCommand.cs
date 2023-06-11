using Core.Domain;

namespace Core.Application;

public abstract record BaseUpdateWithUserCommand<T, PrimaryKeyType> : BaseUpdateCommand<T, PrimaryKeyType>, IBaseUpdateWithUserCommand<T, PrimaryKeyType>
{
    public Guid CurrentUserId { get; private set; }
    public void SetUser(Guid currentUserId)
    => CurrentUserId = currentUserId == Guid.Empty ?
            throw new DomainException("CurrentUserIsNotSet")
            : currentUserId;
}
