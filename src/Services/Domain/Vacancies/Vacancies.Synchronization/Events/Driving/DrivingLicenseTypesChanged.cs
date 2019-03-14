using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Driving;

namespace Vacancies.Synchronization.Events.Driving
{
    public class DrivingLicenseTypesChanged :
        EntityChangedIntegrationEvent<DtoDrivingLicenseType>
    {
    }
}
