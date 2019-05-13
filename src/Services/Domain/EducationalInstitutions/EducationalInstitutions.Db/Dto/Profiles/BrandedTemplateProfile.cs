using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Dto.Models;

namespace EducationalInstitutions.Db.Dto.Profiles
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
