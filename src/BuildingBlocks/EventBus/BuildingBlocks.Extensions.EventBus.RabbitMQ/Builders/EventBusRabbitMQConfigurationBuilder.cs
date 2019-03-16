using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus;
using BuildingBlocks.EventBus.Abstractions;
using RabbitMQ.Client;

namespace BuildingBlocks.Extensions.EventBus.RabbitMQ.Builders
{
    public class EventBusRabbitMQConfigurationBuilder
    {
        public int RetryCount { get; set; }

        public string SubscriptionClientName { get; set; }

        internal ICollection<Type> EventHandlers { get; }

        internal IEventBusSubscriptionsManager SubscriptionManager { get; private set; }

        internal Action<ConnectionFactory> ConfigureConnectionFactory { get; private set; }

        public EventBusRabbitMQConfigurationBuilder()
        {
            RetryCount = 5;
            EventHandlers = new List<Type>();
        }

        public void ConfigureConnection(Action<ConnectionFactory> action)
        {
            ConfigureConnectionFactory = action;
        }

        public void RegisterEventHandler<THandler>() 
            where THandler : IIntegrationEventHandler
        {
            var type = typeof(THandler);
            EventHandlers.Add(type);
        }

        public void UseSubscriptionManager<TSubscriptionManager>()
            where TSubscriptionManager : IEventBusSubscriptionsManager
        {
            var type = typeof(TSubscriptionManager);
            var instance = Activator.CreateInstance<TSubscriptionManager>();
            SubscriptionManager = instance;
        }
    }
}
