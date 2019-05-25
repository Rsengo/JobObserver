using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace BuildingBlocks.Extensions.Security.Builders
{
    public class SecurityConfigurationBuilder
    {
        private readonly IDictionary<Type, Type> _eventHandlersDictionary;

        public SecurityConfigurationBuilder()
        {
            _eventHandlersDictionary = new Dictionary<Type, Type>();
        }

        public SecurityConfigurationBuilder RegisterHandler<TEvent, THandler, TEntity>()
            where TEvent : AccessEvent<TEntity>
            where THandler : IAccessHandler<TEvent, TEntity>
            where TEntity : class
        {
            var eventType = typeof(TEvent);
            var handlerType = typeof(THandler);

            _eventHandlersDictionary.Add(eventType, handlerType);

            return this;
        }

        public IImmutableDictionary<Type, Type> Build()
        {
            return _eventHandlersDictionary.ToImmutableDictionary();
        }
    }
}
