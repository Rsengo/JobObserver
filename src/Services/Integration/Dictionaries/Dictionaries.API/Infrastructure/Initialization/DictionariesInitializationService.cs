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
        private readonly IInitializersFactory _factory;
        private readonly ILogger<DictionariesInitializationService> _logger;

        public DictionariesInitializationService(
            IInitializersFactory factory,
            ILogger<DictionariesInitializationService> logger)
        {
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
        }
    }
}
