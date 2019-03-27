using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using Dictionaries.API.Infrastructure.Initialization.Factories;
using Dictionaries.API.Infrastructure.Initialization.Initializers;

namespace Dictionaries.API.Infrastructure.Initialization
{
    using System.Threading.Tasks;

    using BuildingBlocks.EntityFramework.Models;

    public class DictionariesInitializationService
    {
        private readonly string _zip;
        private readonly string _folder;
        private readonly IInitializersFactory _factory;

        public DictionariesInitializationService(
            string folder, 
            string zip, 
            IInitializersFactory factory)
        {
            _zip = zip;
            _folder = folder;
            _factory = factory;
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
                await initializer.Initialize();
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
