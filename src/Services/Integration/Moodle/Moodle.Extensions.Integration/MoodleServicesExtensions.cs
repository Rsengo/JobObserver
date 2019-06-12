using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moodle.Extensions.Integration.Builders;
using Moodle.Integration;
using Moodle.Integration.Configuration;
using Moodle.Integration.Factories;

namespace Moodle.Extensions.Integration
{
    public static class MoodleServicesExtensions
    {
        public static IServiceCollection AddMoodleIntegration<TIntegrator, TFactory>(
            this IServiceCollection services,
            Action<MoodleIntegrationBuilder> builder)
            where TIntegrator : class, IMoodleIntegrator
            where TFactory : class, IMoodleRequestFactory
        {
            var configuration = new MoodleIntegrationBuilder();
            builder(configuration);

            var moodleRequestFactoryConfig = new MoodleRequestFactoryConfiguration
            {
                RestFormat = configuration.RestFormat,
                Token = configuration.Token
            };

            var moodleIntegratorConfig = new MoodleIntegratorConfiguration
            {
                MoodleRestUrl = configuration.RestUrl
            };

            services.AddScoped(_ => moodleRequestFactoryConfig);
            services.AddScoped<IMoodleRequestFactory, TFactory>();

            services.AddScoped(_ => moodleIntegratorConfig);
            services.AddScoped<IMoodleIntegrator, MoodleIntegrator>();

            return services;
        }
        public static IServiceCollection AddMoodleIntegration(
            this IServiceCollection services,
            Action<MoodleIntegrationBuilder> builder)
        {
            return services.AddMoodleIntegration<
                MoodleIntegrator, 
                MoodleRequestFactory>(builder);
        }
    }
}
