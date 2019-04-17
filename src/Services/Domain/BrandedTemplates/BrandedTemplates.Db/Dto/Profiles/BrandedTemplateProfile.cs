using BuildingBlocks.AutoMapper;
using BrandedTemplates.Db.Models;
using BrandedTemplates.Db.Dto.Models;

namespace BrandedTemplates.Db.Dto.Profiles
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
