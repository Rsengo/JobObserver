using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Statuses;
using Dictionaries.Db.Dto.Models.Statuses;
using Dictionaries.Db.Synchronization.Events.Statuses;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("vacancy_statuses.json")]
    public class VacancyStatusesInitializer :
        BaseDictionaryInitializer<DtoVacancyStatus, VacancyStatus>
    {
        public VacancyStatusesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<VacancyStatus> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoVacancyStatus>);

            var @event = new VacancyStatusesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}