using System;
using System.Collections.Generic;
using System.IO.Compression;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using System.IO;
using System.Linq;
using System.Reflection;
using Dictionaries.API.Infrastructure.Initialization.Attributes;
using Dictionaries.API.Infrastructure.Initialization.Initializers;

namespace Dictionaries.API.Infrastructure.Initialization
{
    using System.Threading.Tasks;

    using BuildingBlocks.EntityFramework.Models;

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

        public Task InitializeAsync()
        {
            var initializers = GetInitializers();
            return InitializeAsync(initializers);
        }

        public Task InitializeAsync(params Type[] entityTypes)
        {
            var initializers = GetInitializers();
            var filtered = initializers.Where(x => entityTypes.Contains(x.EntityType));
            return InitializeAsync(filtered);
        }

        public Task InitializeAsync<TEntity>() where TEntity: RelationalEntity
        {
            var types = new Type[1] { typeof(TEntity) };
            return InitializeAsync(types);
        }

        //TODO
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

        private async Task InitializeAsync(IEnumerable<IInitializer> initializers)
        {
            ZipFile.ExtractToDirectory(_zip, _folder);

            foreach (var initializer in initializers)
            {
                await initializer.Initialize();
            }

            var directory = new DirectoryInfo(_folder);
            var files = directory.GetFiles().Where(x => x.Name != _zip);

            foreach (var file in files)
            {
                file.Delete();;
            }
        }
    }
}
