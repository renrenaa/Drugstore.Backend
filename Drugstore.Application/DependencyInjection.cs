using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Drugstore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
