using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Db.Models;
using CareerDays.Dto.Models;

namespace CareerDays.Synchronization.Events
{
    public class EducationalInstitutionsChanged : 
        EntityChangedIntegrationEvent<DtoEducationalInstitution>
    {
    }
}
