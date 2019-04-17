using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Educations;

namespace Resumes.Db.Synchronization.Events.Educations
{
    public class EducationalLevelsChanged : 
        EntityChangedIntegrationEvent<DtoEducationalLevel>
    {
    }
}
