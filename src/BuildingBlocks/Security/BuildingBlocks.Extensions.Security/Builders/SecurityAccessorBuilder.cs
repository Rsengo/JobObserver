using BuildingBlocks.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace BuildingBlocks.Extensions.Security.Builders
{
    public class SecurityAccessorBuilder
    {
        internal Type EventFactory { get; private set; }

        internal Type AccessorFactory { get; private set; }

        internal ICollection<AccessorBuilder> AccessorBuilders { get; }

        public SecurityAccessorBuilder()
        {
            AccessorBuilders = new List<AccessorBuilder>();
        }

        public SecurityAccessorBuilder UseAccessorFactory<TAccessorFactory>()
            where TAccessorFactory : IAccessorFactory
        {
            AccessorFactory = typeof(TAccessorFactory);
            return this;
        }

        public SecurityAccessorBuilder UseAccessEventFactory<TAccessEventFactory>()
            where TAccessEventFactory : IAccessEventFactory
        {
            EventFactory = typeof(TAccessEventFactory);
            return this;
        }

        public SecurityAccessorBuilder AddAccessor<TAccessor>(
            Action<SecurityConfigurationBuilder> accessorConfigBuilder, 
            Func<IServiceProvider, IImmutableDictionary<Type, Type>, AbstractAccessor> accessorBuilder)
            where TAccessor : AbstractAccessor
        {
            var type = typeof(TAccessor);

            var configuration = new SecurityConfigurationBuilder();
            accessorConfigBuilder(configuration);

            var handlers = configuration.Build();

            var accessorInfo = new AccessorBuilder
            {
                AccessorType = type,
                HandlersDictionary = handlers,
                BuildFunction = accessorBuilder
            };

            AccessorBuilders.Add(accessorInfo);

            return this;
        }


        internal class AccessorBuilder
        {
            public Type AccessorType { get; set; }

            public IImmutableDictionary<Type, Type> HandlersDictionary { get; set; }

            public IEnumerable<Type> HandlerTypes => HandlersDictionary.Values;

            public Func<IServiceProvider, IImmutableDictionary<Type, Type>, AbstractAccessor> BuildFunction { get; set; }

            public AbstractAccessor BuildAccessor(IServiceProvider serviceProvider)
            {
                return BuildFunction(serviceProvider, HandlersDictionary);
            }
        }
    }
}
