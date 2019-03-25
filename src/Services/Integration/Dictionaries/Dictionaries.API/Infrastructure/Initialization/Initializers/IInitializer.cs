using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    public interface IInitializer
    {
        Type EntityType { get; }
        Task Initialize();
    }
}
