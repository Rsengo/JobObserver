using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using Dictionaries.API.Infrastructure.Initialization.Factories;
using System.Threading.Tasks;
using BuildingBlocks.EntityFramework.Models;
using Microsoft.Extensions.Logging;
using Dictionaries.API.Infrastructure.Initialization.Initializers;

namespace Dictionaries.API.Infrastructure.Initialization
{
    public class DictionariesInitializationService
    {
        private readonly string _zip;
        private readonly string _folder;
        private readonly IInitializersFactory _factory;
        private readonly ILogger<DictionariesInitializationService> _logger;

        public DictionariesInitializationService(
            string folder, 
            string zip, 
            IInitializersFactory factory,
            ILogger<DictionariesInitializationService> logger)
        {
            _zip = zip;
            _folder = folder;
            _factory = factory;
            _logger = logger;
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

        public IEnumerable<IInitializer> GetInitializers()
        {
            return _factory.Create();
        }

        private async Task InitializeAsync(IEnumerable<IInitializer> initializers)
        {
            ZipFile.ExtractToDirectory(_zip, _folder);

            foreach (var initializer in initializers)
            {
                try
                {
                    await initializer.Initialize();
                    _logger.LogInformation("Dictionary initialized for type: {type}",
                        initializer.EntityType.ToString());
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Failed to initialize dictionary for type {type}; Error: {error}",
                        initializer.EntityType.ToString(),
                        ex.Message);
                }
            }

            var directory = new DirectoryInfo(_folder);
            var files = directory.GetFiles().Where(x => x.FullName != _zip);

            foreach (var file in files)
            {
                file.Delete();;
            }
        }
    }
}
