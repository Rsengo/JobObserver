using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Travel.Relocation;
using Dictionaries.Db.Dto.Models.Travel.Relocation;
using Dictionaries.Db.Synchronization.Events.Travel.Relocation;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("relocation_types.json")]
    public class RelocationTypesInitializer :
        BaseDictionaryInitializer<DtoRelocationType, RelocationType>
    {
        public RelocationTypesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<RelocationType> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoRelocationType>);

            var @event = new RelocationTypesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}