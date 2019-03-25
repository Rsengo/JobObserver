using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Statuses;
using Dictionaries.Dto.Models.Statuses;
using Dictionaries.EventBus.Events.Statuses;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("resume_statuses.json")]
    public class ResumeStatusesInitializer :
        BaseDictionaryInitializer<DtoResumeStatus, ResumeStatus>
    {
        public ResumeStatusesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<ResumeStatus> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoResumeStatus>);

            var @event = new ResumeStatusesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}