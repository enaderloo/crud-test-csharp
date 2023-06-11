
using MediatR;

namespace Core.Application;

public interface IBaseCommandWithUser<T> : IRequest<T>
{
    Guid CurrentUserId { get; }
    void SetUser(Guid currentUserId);
}