using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Negotiations;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.EventBus.Events.Negotiations;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("responses.json")]
    public class ResponsesInitializer :
        BaseDictionaryInitializer<DtoResponse, Response>
    {
        public ResponsesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Response> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoResponse>);

            var @event = new ResponsesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}