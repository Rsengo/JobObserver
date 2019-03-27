using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Geographic;
using Dictionaries.Dto.Models.Geographic;
using Dictionaries.EventBus.Events.Geographic;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("areas.json")]
    public class AreasInitializer :
        BaseDictionaryInitializer<DtoAreaSync, Area>
    {
        public AreasInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Area> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoAreaSync>);

            var @event = new AreasChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }

        protected override Task<IEnumerable<Area>> SaveDataAsync(
            IEnumerable<Area> dataFromJson)
        {
            var flatData = GetFlatData(dataFromJson);
            return base.SaveDataAsync(flatData);
        }

        private IEnumerable<Area> GetFlatData(IEnumerable<Area> data)
        {
            var result = new List<Area>();
            result.AddRange(data);

            foreach (var datum in data)
            {
                var children = datum.Areas;
                datum.Areas = null;

                if (children == null || !children.Any())
                    continue;
                
                var childrenFlat = GetFlatData(children);
                result.AddRange(childrenFlat);
            }

            return result;
        }
    }
}