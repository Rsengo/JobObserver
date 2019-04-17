using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.API.Infrastructure.Initialization.Attributes;
using Dictionaries.Db;
using Dictionaries.Db.Models.Travel;
using Dictionaries.Db.Dto.Models.Travel;
using Dictionaries.Db.Synchronization.Events.Travel;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("business_trip_readiness.json")]
    public class BusinessTripReadinessInitializer :
        BaseDictionaryInitializer<DtoBusinessTripReadiness, BusinessTripReadiness>
    {
        public BusinessTripReadinessInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<BusinessTripReadiness> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoBusinessTripReadiness>);

            var @event = new BusinessTripReadinessChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}