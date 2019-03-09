using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Employers.Db.Models.Synonyms;
using Employers.Dto.Models.Synonyms;

namespace Employers.Dto.Profiles.Synonyms
{
    public class EmployerSynonymsProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EmployerSynonyms, DtoEmployerSynonyms>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployerSynonyms, EmployerSynonyms>()
                .ForMember(
                    d => d.Employer,
                    o => o.Ignore());
        }
    }
}
