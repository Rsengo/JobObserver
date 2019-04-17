using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Employer;
using Dictionaries.Db.Dto.Models.Employer;
using Dictionaries.Db.Synchronization.Events.Employer;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("employer_types.json")]
    public class EmployerTypesInitializer :
        BaseDictionaryInitializer<DtoEmployerType, EmployerType>
    {
        public EmployerTypesInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<EmployerType> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoEmployerType>);

            var @event = new EmployerTypesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}