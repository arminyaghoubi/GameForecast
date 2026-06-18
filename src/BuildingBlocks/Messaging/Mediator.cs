using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Messaging;

public class Mediator(IServiceProvider serviceProvider)
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellation = default)
    {
        var type = typeof(IHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic handler = serviceProvider.GetRequiredService(type);
        return handler.Handle(request, cancellation);
    }
}