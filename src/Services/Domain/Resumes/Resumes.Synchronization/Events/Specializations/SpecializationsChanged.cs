using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Languages;
using Resumes.Dto.Models.Negotiations;
using Resumes.Dto.Models.Specializations;

namespace V.Synchronization.Events.Specializations
{
    public class SpecializationsChanged : 
        EntityChangedIntegrationEvent<DtoSpecialization>
    {
    }
}
