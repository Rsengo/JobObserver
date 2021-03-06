﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuildingBlocks.EventBus;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.RabbitMQ;
using BuildingBlocks.Extensions.EventBus.RabbitMQ.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace BuildingBlocks.Extensions.EventBus.RabbitMQ
{
    public static class EventBusRabbitMQServicesExtensions
    {
        public static IServiceCollection AddEventBusRabbitMQ(
            this IServiceCollection services,
            Action<EventBusRabbitMQConfigurationBuilder> builder)
        {
            var configuration = new EventBusRabbitMQConfigurationBuilder();
            builder(configuration);

            foreach (var handler in configuration.EventHandlers)
            {
                services.AddScoped(handler);
            }

            var retryCount = configuration.RetryCount;

            if (configuration.SubscriptionManager == null)
            {
                services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            }
            else
            {
                services.AddSingleton(configuration.SubscriptionManager);
            }

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                var factory = new ConnectionFactory();
                configuration.ConfigureConnectionFactory?.Invoke(factory);

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                var EventBusSubscriptionClientName = configuration.SubscriptionClientName;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, sp, eventBusSubscriptionsManager, EventBusSubscriptionClientName, retryCount);
            });

            return services;
        }
    }
}
