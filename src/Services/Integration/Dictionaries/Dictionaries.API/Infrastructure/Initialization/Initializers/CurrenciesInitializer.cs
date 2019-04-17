using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Salaries;
using Dictionaries.Db.Dto.Models.Salaries;
using Dictionaries.Db.Synchronization.Events.Salaries;
using System.Collections.Generic;
using System.Linq;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("currencies.json")]
    public class CurrenciesInitializer :
        BaseDictionaryInitializer<DtoCurrency, Currency>
    {
        public CurrenciesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Currency> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoCurrency>);

            var @event = new CurrenciesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}