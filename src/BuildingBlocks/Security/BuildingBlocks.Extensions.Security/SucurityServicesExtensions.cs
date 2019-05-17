using BuildingBlocks.Extensions.Security.Builders;
using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Extensions.Security
{
    public static class SucurityServicesExtensions
    {
        public static IServiceCollection AddAccessControl<TSecurityManager>(
            this IServiceCollection services,
            Action<SecurityAccessorBuilder> builder)
            where TSecurityManager : class, ISecurityManager
        {
            var configuration = new SecurityAccessorBuilder();
            builder(configuration);

            if (configuration.AccessorFactory == null)
            {
                throw new NullReferenceException("Не задана фабрика аксессоров доступа");
            }

            if (configuration.EventFactory == null)
            {
                throw new NullReferenceException("Не задана фабрика эвентов проверки прав");
            }

            services.AddScoped(typeof(IAccessorFactory), configuration.AccessorFactory);
            services.AddScoped(typeof(IAccessEventFactory), configuration.EventFactory);

            services.AddScoped<ISecurityManager, TSecurityManager>();

            var accessorBuilders = configuration.AccessorBuilders;

            //TODO Реализовать хэндлеры через контейнеры

            foreach (var accessorBuilder in accessorBuilders)
            {
                services.AddTransient(accessorBuilder.AccessorType, accessorBuilder.BuildAccessor);
            }

            return services;
        }

        public static IServiceCollection AddAccessControl(
            this IServiceCollection services,
            Action<SecurityAccessorBuilder> builder)
        {
            return services.AddAccessControl<SecurityManager>(builder);
        }
    }
}
