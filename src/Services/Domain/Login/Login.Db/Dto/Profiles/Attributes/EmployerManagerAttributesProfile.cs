using BuildingBlocks.AutoMapper;
using Login.Db.Models.Attributes;
using Login.Db.Dto.Models.Attributes;

namespace Login.Db.Dto.Profiles.Attributes
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
