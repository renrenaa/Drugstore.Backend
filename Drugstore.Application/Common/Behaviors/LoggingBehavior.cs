using Drugstore.Application.Interfaces;
using MediatR;
using Serilog;

namespace Drugstore.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        ICurrentUserService _currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(
            TRequest request, CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            var userId = _currentUserService.UserId;
            var requestName = typeof(TRequest).Name;

            Log.Information("Drugs request: {Name} {@UserId} {@Request}", 
                requestName, userId, request);

            var response = await next();

            return response;
        }
    }
}
