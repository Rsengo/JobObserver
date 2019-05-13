using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Dto.Models;
using EducationalInstitutions.Db.Dto.Models.Geographic;

namespace EducationalInstitutions.Db.Dto.Profiles
{
    public class EducationalInstitutionProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EducationalInstitution, DtoEducationalInstitution>()
                .ForMember(
                    d => d.Area,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)))
                .ForMember(
                    d => d.BrandedDescription,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoBrandedTemplate>(s.BrandedDescription)))
                .ForMember(
                    d => d.Faculties,
                    o => o.Ignore());
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEducationalInstitution, EducationalInstitution>()
                .ForMember(
                    d => d.Area,
                    o => o.Ignore())
                .ForMember(
                    d => d.Faculties,
                    o => o.Ignore())
                .ForMember(
                    d => d.Synonyms,
                    o => o.Ignore())
                .ForMember(
                    d => d.BrandedDescription,
                    o => o.Ignore());
        }
    }
}
