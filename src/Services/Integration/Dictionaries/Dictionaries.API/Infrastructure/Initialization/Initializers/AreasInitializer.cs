using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}