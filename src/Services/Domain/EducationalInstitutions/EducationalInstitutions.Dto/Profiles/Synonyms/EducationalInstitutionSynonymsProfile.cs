using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models.Synonyms;
using EducationalInstitutions.Dto.Models.Synonyms;

namespace EducationalInstitutions.Dto.Profiles.Synonyms
{
    public class EducationalInstitutionSynonymsProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EducationalInstitutionSynonyms, DtoEducationalInstitutionSynonyms>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEducationalInstitutionSynonyms, EducationalInstitutionSynonyms>()
                .ForMember(
                    d => d.EducationalInstitution,
                    o => o.Ignore());
        }
    }
}
