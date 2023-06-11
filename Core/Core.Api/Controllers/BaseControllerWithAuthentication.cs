

using Core.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

[Authorize]
public class BaseControllerWithAuthentication : BaseController, ISender
{
    private readonly IMediator Mediator;
    // Auth Service should be inject

    public BaseControllerWithAuthentication(IMediator mediator)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(IBaseCommandWithUser<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(long id, IBaseUpdateWithUserCommand<TResponse, long> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(Guid id, IBaseUpdateWithUserCommand<TResponse, Guid> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(long id, IBaseUpdateCommand<TResponse, long> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(string id, IBaseUpdateCommand<TResponse, string> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(Guid id, IBaseUpdateCommand<TResponse, Guid> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual Task<object> Send(object request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("Stream")]
    public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("Stream2")]
    public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default) => throw new NotImplementedException();


}
