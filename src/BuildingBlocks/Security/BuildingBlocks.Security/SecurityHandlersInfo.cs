using BuildingBlocks.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace BuildingBlocks.Security
{
    public class SecurityHandlersInfo<TAccessor>
        where TAccessor : AbstractAccessor
    {
        private IImmutableDictionary<Type, Type> _dictionary;

        public SecurityHandlersInfo(IImmutableDictionary<Type, Type> handlers)
        {
            _dictionary = handlers;
        }

        public Type this[Type t] => GetValueOrDefault(t);

        public bool TryGetValue(Type key, out Type value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public Type GetValueOrDefault(Type key)
        {
            return _dictionary.GetValueOrDefault(key);
        }
    }
}
