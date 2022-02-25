using LimaShop.Customer.Application.Commands.InputModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LimaShop.Customer.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCustomer)); // ele vai conseguir adicionar todos os outros input models e handler, atraves do assembly;
            return services;
        }
    }
}
