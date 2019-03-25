using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Users;
using Dictionaries.Dto.Models.Users;
using Dictionaries.EventBus.Events.Users;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("genders.json")]
    public class GendersInitializer :
        BaseDictionaryInitializer<DtoGender, Gender>
    {
        public GendersInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Gender> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoGender>);

            var @event = new GendersChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}