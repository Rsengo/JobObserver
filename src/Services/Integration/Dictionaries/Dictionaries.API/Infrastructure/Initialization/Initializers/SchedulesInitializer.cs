using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Schedules;
using Dictionaries.Db.Dto.Models.Schedules;
using Dictionaries.Db.Synchronization.Events.Schedules;
using System.Collections.Generic;
using System.Linq;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("schedules.json")]
    public class SchedulesInitializer :
        BaseDictionaryInitializer<DtoSchedule, Schedule>
    {
        public SchedulesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Schedule> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoSchedule>);

            var @event = new SchedulesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}