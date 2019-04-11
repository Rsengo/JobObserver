using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moodle.Extensions.Integration.Builders;
using Moodle.Integration;
using Moodle.Integration.Factories;

namespace Moodle.Extensions.Integration
{
    public static class MoodleServicesExtensions
    {
        public static IServiceCollection AddMoodleIntegration(
            this IServiceCollection services, 
            Action<MoodleIntegrationBuilder> builder)
        {
            var configuration = new MoodleIntegrationBuilder();
            builder(configuration);

            services.AddScoped<IMoodleRequestFactory>(_ =>
            {
                var factory = new MoodleRequestFactory(configuration.Token, configuration.RestFormat);
                return factory;
            });

            
            services.AddScoped<IMoodleIntegrator>(sp =>
            {
                var factory = sp.GetRequiredService<IMoodleRequestFactory>();
                var logger = sp.GetRequiredService<ILogger<IMoodleIntegrator>>();
                var integrator = new MoodleIntegrator(factory, logger, configuration.RestUrl);

                return integrator;
            });

            return services;
        }
    }
}
