using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Educations;

namespace Resumes.Synchronization.Events.Educations
{
    public class EducationalLevelsChanged : 
        EntityChangedIntegrationEvent<DtoEducationalLevel>
    {
    }
}
