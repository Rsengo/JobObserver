using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
