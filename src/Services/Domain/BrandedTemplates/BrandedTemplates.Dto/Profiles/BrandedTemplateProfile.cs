using BuildingBlocks.AutoMapper;
using BrandedTemplates.Db.Models;
using BrandedTemplates.Dto.Models;

namespace BrandedTemplates.Dto.Profiles
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
