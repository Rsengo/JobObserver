using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Employers.Db.Models;
using Employers.Db.Dto.Models;

namespace Employers.Db.Dto.Profiles
{
    public class EmployerProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Employer, DtoEmployer>()
                .ForMember(
                    d => d.Type,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEmployerType>(s.Type)))
                .ForMember(
                    d => d.Area,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEmployerType>(s.Area)))
                .ForMember(
                    d => d.BrandedDescription,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoBrandedTemplate>(s.BrandedDescription)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployer, Employer>()
                .ForMember(
                    d => d.Partners,
                    o => o.Ignore())
                .ForMember(
                    d => d.Departments,
                    o => o.Ignore())
                .ForMember(
                    d => d.Synonyms,
                    o => o.Ignore())
                .ForMember(
                    d => d.Type,
                    o => o.Ignore())
                .ForMember(
                    d => d.Area,
                    o => o.Ignore())
                .ForMember(
                    d => d.BrandedDescription,
                    o => o.Ignore());
        }
    }
}
