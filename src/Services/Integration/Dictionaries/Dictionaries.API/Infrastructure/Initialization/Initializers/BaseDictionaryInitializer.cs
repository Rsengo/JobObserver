using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db;
using Dictionaries.Db.Models.Geographic;
using Dictionaries.Dto.Models.Geographic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    public abstract class BaseDictionaryInitializer<TDtoEntity, TEntity> : IInitializer
        where TEntity: RelationalDictionary
        where TDtoEntity: DtoDictionary
    {
        protected readonly string _jsonPath;
        protected readonly DictionariesDbContext _context;
        protected readonly IEventBus _eventBus;

        public Type EntityType => typeof(TEntity);

        protected BaseDictionaryInitializer(
            string jsonPath, 
            DictionariesDbContext context,
            IEventBus eventBus)
        {
            _jsonPath = jsonPath;
            _context = context;
            _eventBus = eventBus;
        }

        public async Task Initialize()
        {
            var data = await ReadDataAsync();
            var savedData = await SaveDataAsync(data);
            ProduceEvent(savedData);
        }

        protected virtual async Task<IEnumerable<TEntity>> SaveDataAsync(
            IEnumerable<TEntity> dataFromJson)
        {
            await _context.BulkInsertAsync(
                dataFromJson,
                opt =>
                {
                    opt.InsertIfNotExists = true;
                    opt.ColumnPrimaryKeyExpression = x => x.Name;
                });

            return dataFromJson;
        }

        protected abstract void ProduceEvent(IEnumerable<TEntity> eventData);

        protected virtual async Task<IEnumerable<TEntity>> ReadDataAsync()
        {
            var jsonData = await ReadJsonDataAsync();
            var dtoData = JsonConvert.DeserializeObject<IEnumerable<TDtoEntity>>(jsonData);
            var data = dtoData.Select(Mapper.Map<TEntity>);

            return data;
        }

        protected virtual async Task<string> ReadJsonDataAsync()
        {
            using (var reader = new StreamReader(_jsonPath))
            {
                var jsonString = await reader.ReadToEndAsync();
                return jsonString;
            }
        }
    }
}
