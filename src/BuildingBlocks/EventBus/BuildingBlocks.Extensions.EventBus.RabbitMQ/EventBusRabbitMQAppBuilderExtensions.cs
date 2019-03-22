using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace BuildingBlocks.Extensions.EventBus.RabbitMQ
{
    public static class EventBusRabbitMQAppBuilderExtensions
    {
        public static IApplicationBuilder UseEventBusRabbitMQ(
            this IApplicationBuilder app,
            Action<IEventBus> eventBusConfiguration)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBusConfiguration(eventBus);

            return app;
        }
    }
}
