using BuildingBlocks.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Extensions.Security.Builders
{
    public class SecurityConfigurationBuilder
    {
        internal Type EventFactory { get; private set; }

        internal Type AccessorFactory { get; private set; }

        internal IDictionary<Type, Func<IServiceProvider, Func<SecurityAccessorBuilder, AbstractAccessor>>> AccessorBuilders { get; }

        public SecurityConfigurationBuilder UseAccessorFactory<TAccessorFactory>()
            where TAccessorFactory : IAccessorFactory
        {
            AccessorFactory = typeof(TAccessorFactory);
            return this;
        }

        public SecurityConfigurationBuilder UseAccessEventFactory<TAccessEventFactory>()
            where TAccessEventFactory : IAccessEventFactory
        {
            EventFactory = typeof(TAccessEventFactory);
            return this;
        }

        public SecurityConfigurationBuilder AddAccessor<TAccessor>(
            Func<IServiceProvider, Func<SecurityAccessorBuilder, AbstractAccessor>> builder)
            where TAccessor : AbstractAccessor
        {
            AccessorBuilders.Add(typeof(TAccessor), builder);
            return this;
        }
    }
}
