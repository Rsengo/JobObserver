using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using Dictionaries.Dto.Models.Driving;

namespace Dictionaries.EventBus.Events.Driving
{
    public class DrivingLicenseTypesInserted :
        DictionaryInsertedIntegrationEvent<DtoDrivingLicenseType>
    {
        public DrivingLicenseTypesInserted(IEnumerable<DtoDrivingLicenseType> entities) :
            base(entities)
        {
        }
    }
}
