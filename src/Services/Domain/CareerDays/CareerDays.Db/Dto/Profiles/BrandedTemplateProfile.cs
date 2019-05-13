using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models;
using CareerDays.Db.Dto.Models;

namespace CareerDays.Db.Dto.Profiles
{
    public class BrandedTemplateProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<BrandedTemplate, DtoBrandedTemplate>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoBrandedTemplate, BrandedTemplate>();
        }
    }
}
