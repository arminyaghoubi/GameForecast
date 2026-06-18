namespace BuildingBlocks.Messaging;

public interface IHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellation = default);
}
