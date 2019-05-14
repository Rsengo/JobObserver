using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.BrandedTemplates;
using Vacancies.Db.Dto.Models.BrandedTemplates;

namespace Vacancies.Db.Dto.Profiles
{
    public class BrandedTemplateProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<BrandedTemplate, DtoBrandedTemplate>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoBrandedTemplate, BrandedTemplate>()
                .ForMember(d => d.Vacancy, o => o.Ignore());
        }
    }
}
