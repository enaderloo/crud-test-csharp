using Core.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

public class BaseControllerWitoutAuthentication : BaseController
{
    internal readonly IMediator Mediator;

    public BaseControllerWitoutAuthentication(IMediator mediator)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(IBaseCommandWithUser<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public Task<TResponse> Send<TResponse>(long id, IBaseUpdateCommand<TResponse, long> request, CancellationToken cancellationToken = default)
    {
        request.SetId(id);
        return Mediator.Send(request, cancellationToken);
    }
}


