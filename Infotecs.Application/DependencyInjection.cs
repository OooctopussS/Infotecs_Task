using FluentValidation;
using Infotecs.Application.Common.Behaviors;
using Infotecs.Application.Common.Services;
using Infotecs.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infotecs.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

           services.AddScoped<ICSVService, CSVService>();

            return services;
        }
    }
}
