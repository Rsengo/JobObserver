using System;
using System.Collections.Generic;
using System.IO.Compression;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;

namespace Dictionaries.API.Infrastructure.Initialization
{
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Dictionaries.API.Infrastructure.Initialization.Attributes;
    using Dictionaries.API.Infrastructure.Initialization.Initializers;

    public class DictionariesInitializationService
    {
        private readonly string _zip;
        private readonly string _folder;
        private readonly DictionariesDbContext _context;
        private readonly IEventBus _eventBus;

        public DictionariesInitializationService(
            string folder, 
            string zip, 
            DictionariesDbContext context,
            IEventBus eventBus)
        {
            _zip = zip;
            _folder = folder;
            _context = context;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            ZipFile.ExtractToDirectory(_zip, _folder);
        }

        public IEnumerable<IInitializer> GetInitializers()
        {
            var jsonPath = GetJsonPath(typeof(BusinessTripReadinessInitializer));
            var initializer2 = new BusinessTripReadinessInitializer(jsonPath, _context, _eventBus);
            yield return initializer2;
        }

        private string GetJsonPath(Type initializerType)
        {
            var jsonFileNameAttr = (JsonFileNameAttribute) initializerType.GetCustomAttributes()
                .SingleOrDefault(x => x is JsonFileNameAttribute);
            var jsonName = jsonFileNameAttr.Name;
            var jsonPath = Path.Combine(_folder, jsonName);

            return jsonPath;
        }
    }
}
