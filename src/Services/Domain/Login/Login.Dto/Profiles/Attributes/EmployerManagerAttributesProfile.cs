using BuildingBlocks.AutoMapper;
using Login.Db.Models.Attributes;
using Login.Dto.Models.Attributes;

namespace Login.Dto.Profiles.Attributes
{
    public class EmployerManagerAttributesProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EmployerManagerAttributes, DtoEmployerManagerAttributes>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployerManagerAttributes, EmployerManagerAttributes>();
        }
    }
}
