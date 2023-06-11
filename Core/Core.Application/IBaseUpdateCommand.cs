using MediatR;

namespace Core.Application;

public interface IBaseUpdateCommand<T, PrimaryKeyType> : IRequest<T>
{
    PrimaryKeyType Id { get; }
    void SetId(PrimaryKeyType id);
}
