using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Driving;

namespace Resumes.Synchronization.Events.Driving
{
    public class DrivingLicenseTypesChanged :
        EntityChangedIntegrationEvent<DtoDrivingLicenseType>
    {
    }
}
