using MediatR;

namespace Core.Application;

public abstract class Request<TResult> : IRequest<TResult> where TResult : Result
{

}