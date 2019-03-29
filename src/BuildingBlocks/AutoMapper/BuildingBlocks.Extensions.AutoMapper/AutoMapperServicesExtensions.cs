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

            var assemblies = configuration.Assemblies;
            configurator.Initialize(assemblies);

            services.AddSingleton(configurator);

            return services;
        }
    }
}
