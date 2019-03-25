using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Travel;
using Dictionaries.Dto.Models.Travel;
using Dictionaries.EventBus.Events.Travel;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("travel_times.json")]
    public class TravelTimesInitializer :
        BaseDictionaryInitializer<DtoTravelTime, TravelTime>
    {
        public TravelTimesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<TravelTime> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoTravelTime>);

            var @event = new TravelTimesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}