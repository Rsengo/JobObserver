using BuildingBlocks.AutoMapper;
using Employers.Db.Models;
using Employers.Db.Dto.Models;

namespace Employers.Db.Dto.Profiles
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
