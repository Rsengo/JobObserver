using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Driving;

namespace Resumes.Db.Synchronization.Events.Driving
{
    public class DrivingLicenseTypesChanged :
        EntityChangedIntegrationEvent<DtoDrivingLicenseType>
    {
    }
}
