using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Employers;
using Vacancies.Db.Dto.Models.Employers;
using Vacancies.Db.Dto.Models.Geographic;

namespace Vacancies.Db.Dto.Profiles.Employers
{
    public class EmployerProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Employer, DtoEmployer>()
                .ForMember(
                    d => d.Area,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployer, Employer>()
                .ForMember(
                    d => d.Vacancies,
                    o => o.Ignore())
                .ForMember(
                    d => d.Area, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Departments, 
                    o => o.Ignore());
        }
    }
}
