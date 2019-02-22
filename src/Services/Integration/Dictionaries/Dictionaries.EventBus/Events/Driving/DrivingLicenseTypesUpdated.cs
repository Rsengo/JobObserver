using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using Dictionaries.Dto.Models.Driving;

namespace Dictionaries.EventBus.Events.Driving
{
    public class DrivingLicenseTypesUpdated : 
        DictionaryUpdatedIntegrationEvent<DtoDrivingLicenseType>
    {
        public DrivingLicenseTypesUpdated(IEnumerable<DtoDrivingLicenseType> entities) : base(entities)
        {
        }
    }
}
