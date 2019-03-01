using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using BuildingBlocks.Extensions.AutoMapper.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Extensions.AutoMapper
{
    public static class AutoMapperServicesExtensions
    {
        public static IServiceCollection AddAutoMapper(
            this IServiceCollection services, 
            Action<AutoMapperConfigurationBuilder> builder)
        {
            var configurator = AutoMapperConfigurator.Instance;

            var configuration = new AutoMapperConfigurationBuilder();
            builder(configuration);

            var rootAssembly = configuration.RootAssembly;
            configurator.Initialize(rootAssembly);

            services.AddSingleton(_ => configurator);

            return services;
        }
    }
}
