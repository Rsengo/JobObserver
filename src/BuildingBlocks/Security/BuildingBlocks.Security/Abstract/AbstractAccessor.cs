using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Abstract
{
    public abstract class AbstractAccessor
    {
        protected const string HANDLER_METHOD_NAME = "HasPermissionAsync";

        protected readonly IServiceProvider _serviceProvider;

        protected readonly IImmutableDictionary<Type, Type> _eventHandlersDictionary;

        public AbstractAccessor(
            IServiceProvider serviceProvider,
            IImmutableDictionary<Type, Type> eventHandlersDictionary)
        {
            _serviceProvider = serviceProvider;
            _eventHandlersDictionary = eventHandlersDictionary;
        }

        public virtual async Task<bool> HasPermissionAsync<TEntity>(
            AccessEvent<TEntity> @event, 
            AccessOperation operation)
            where TEntity : class
        {
            var eventType = @event.GetType();
            var hasHandler = _eventHandlersDictionary.TryGetValue(eventType, out var handlerType);

            if (!hasHandler)
                await OnHandlerNotFound(@event, operation);

            //TODO Реализовать хэндлеры через контейнеры
            //var handler = _serviceProvider.GetService(handlerType);

            var handler = Activator.CreateInstance(handlerType);

            if (handler == null)
                await OnHandlerNotFound(@event, operation);

            var concreteType = typeof(IAccessHandler<,>).MakeGenericType(eventType, typeof(TEntity));
            var methodParams = new object[] { @event, operation };
            var result = await(Task<bool>)concreteType.GetMethod(HANDLER_METHOD_NAME).Invoke(handler, methodParams);

            return result;
        }

        protected virtual Task<bool> OnHandlerNotFound<TEntity>(
            AccessEvent<TEntity> @event,
            AccessOperation operation)
            where TEntity: class
        {
            throw new NullReferenceException($"Не зарегистрирован обработчик для " +
                    $"для сущности {typeof(TEntity).Name}");
        }
    }
}
