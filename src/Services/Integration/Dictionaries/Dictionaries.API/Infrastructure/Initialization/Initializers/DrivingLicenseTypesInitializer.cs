using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Driving;
using Dictionaries.Db.Dto.Models.Driving;
using Dictionaries.Db.Synchronization.Events.Driving;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("driving_license_types.json")]
    public class DrivingLicenseTypesInitializer : 
        BaseDictionaryInitializer<DtoDrivingLicenseType, DrivingLicenseType>
    {
        public DrivingLicenseTypesInitializer(
            string jsonPath, 
            DictionariesDbContext context, 
            IEventBus eventBus) : 
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<DrivingLicenseType> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoDrivingLicenseType>);

            var @event = new DrivingLicenseTypesChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}
