using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.API.Infrastructure.Initialization.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class JsonFileNameAttribute : Attribute
    {
        private const string JSON_EXTENSION = ".json";

        public string Name { get; }

        public JsonFileNameAttribute(string name)
        {
            if (name.EndsWith(JSON_EXTENSION))
            {
                Name = name;
                return;
            }

            Name = $"{name}{JSON_EXTENSION}";
        }
    }
}
