using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionaries.API.Infrastructure.Initialization.Attributes;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Industries;
using Dictionaries.Dto.Models.Industries;
using Dictionaries.EventBus.Events.Industries;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("industries.json")]
    public class IndustriesInitializer :
        BaseDictionaryInitializer<DtoIndustry, Industry>
    {
        public IndustriesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Industry> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoIndustrySync>);

            var @event = new IndustriesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
        protected override Task<IEnumerable<Industry>> SaveDataAsync(
            IEnumerable<Industry> dataFromJson)
        {
            var flatData = GetFlatData(dataFromJson);
            return base.SaveDataAsync(flatData);
        }

        private IEnumerable<Industry> GetFlatData(IEnumerable<Industry> data)
        {
            var result = new List<Industry>();
            result.AddRange(data);

            foreach (var datum in data)
            {
                var children = datum.Industries;
                datum.Industries = null;

                if (children == null || !children.Any())
                    continue;

                var childrenFlat = GetFlatData(children);
                result.AddRange(childrenFlat);
            }

            return result;
        }
    }
}