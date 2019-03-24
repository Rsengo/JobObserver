using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Educations;
using Dictionaries.Dto.Models.Educations;
using Dictionaries.EventBus.Events.Educations;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    public class EducationalLevelsInitializer :
        BaseDictionaryInitializer<DtoEducationalLevel, EducationalLevel>
    {
        public EducationalLevelsInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<EducationalLevel> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoEducationalLevel>);

            var @event = new EducationalLevelsChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}