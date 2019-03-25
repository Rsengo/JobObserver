using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionaries.API.Infrastructure.Initialization.Initializers;

namespace Dictionaries.API.Infrastructure.Initialization.Factories
{
    public interface IInitializersFactory
    {
        IEnumerable<IInitializer> Create();
    }
}
