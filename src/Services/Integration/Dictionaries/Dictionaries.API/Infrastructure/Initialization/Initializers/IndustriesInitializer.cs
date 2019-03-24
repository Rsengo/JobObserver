using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Industries;
using Dictionaries.Dto.Models.Industries;
using Dictionaries.EventBus.Events.Industries;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
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
            var dtoData = eventData.Select(Mapper.Map<DtoIndustry>);

            var @event = new IndustriesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}