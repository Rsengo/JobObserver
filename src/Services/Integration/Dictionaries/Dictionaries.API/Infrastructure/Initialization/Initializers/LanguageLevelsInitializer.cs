using System;
using System.Collections.Generic;
using System.Linq;
using Dictionaries.API.Infrastructure.Initialization.Attributes;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Languages;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.EventBus.Events.Languages;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("language_levels.json")]
    public class LanguageLevelsInitializer :
        BaseDictionaryInitializer<DtoLanguageLevel, LanguageLevel>
    {
        public LanguageLevelsInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<LanguageLevel> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoLanguageLevel>);

            var @event = new LanguageLevelsChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}