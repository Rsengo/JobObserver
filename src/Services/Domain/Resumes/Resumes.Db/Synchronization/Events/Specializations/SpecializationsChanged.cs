using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Specializations;

namespace Resumes.Db.Synchronization.Events.Specializations
{
    public class SpecializationsChanged : 
        EntityChangedIntegrationEvent<DtoSpecialization>
    {
    }
}
