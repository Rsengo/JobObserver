using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Driving;

namespace Dictionaries.Db.Synchronization.Events.Driving
{
    public class DrivingLicenseTypesChanged :
        EntityChangedIntegrationEvent<DtoDrivingLicenseType>
    {
    }
}
