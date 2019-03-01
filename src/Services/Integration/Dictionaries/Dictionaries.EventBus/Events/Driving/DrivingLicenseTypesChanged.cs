using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Driving;

namespace Dictionaries.EventBus.Events.Driving
{
    public class DrivingLicenseTypesChanged :
        EntityChangedIntegrationEvent<DtoDrivingLicenseType>
    {
    }
}
