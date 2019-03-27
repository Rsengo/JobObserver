using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Specializations;
using Dictionaries.Dto.Models.Specializations;
using Dictionaries.EventBus.Events.Specializations;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("specializations.json")]
    public class SpecializationsInitializer :
        BaseDictionaryInitializer<DtoSpecializationSync, Specialization>
    {
        public SpecializationsInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Specialization> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoSpecializationSync>);

            var @event = new SpecializationsChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}