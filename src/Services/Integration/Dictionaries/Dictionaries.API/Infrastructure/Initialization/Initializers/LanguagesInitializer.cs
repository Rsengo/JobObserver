using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Languages;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.EventBus.Events.Languages;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("languages.json")]
    public class LanguagesInitializer :
        BaseDictionaryInitializer<DtoLanguage, Language>
    {
        public LanguagesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Language> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoLanguage>);

            var @event = new LanguagesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}