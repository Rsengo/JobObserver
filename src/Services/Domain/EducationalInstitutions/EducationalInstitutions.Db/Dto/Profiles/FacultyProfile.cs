using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Dto.Models;

namespace EducationalInstitutions.Db.Dto.Profiles
{
    public class FacultyProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Faculty, DtoFaculty>()
                .ForMember(
                    d => d.EducationalInstitution,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEducationalInstitution>(s.EducationalInstitution)))
                .ForMember(
                    d => d.BrandedDescription,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoBrandedTemplate>(s.BrandedDescription)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoFaculty, Faculty>()
                .ForMember(
                    d => d.EducationalInstitution,
                    o => o.Ignore())
                .ForMember(
                    d => d.BrandedDescription,
                    o => o.Ignore());
        }
    }
}
