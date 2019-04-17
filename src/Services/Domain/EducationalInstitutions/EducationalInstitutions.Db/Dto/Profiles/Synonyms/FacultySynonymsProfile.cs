using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models.Synonyms;
using EducationalInstitutions.Db.Dto.Models.Synonyms;

namespace EducationalInstitutions.Db.Dto.Profiles.Synonyms
{
    public class FacultySynonymsProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<FacultySynonyms, DtoFacultySynonyms>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoFacultySynonyms, FacultySynonyms>()
                .ForMember(
                    d => d.Faculty,
                    o => o.Ignore());
        }
    }
}
