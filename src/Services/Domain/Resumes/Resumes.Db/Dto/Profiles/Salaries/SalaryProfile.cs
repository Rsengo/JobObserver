using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Dto.Models.Salaries;

namespace Resumes.Db.Dto.Profiles.Salaries
{
    public class SalaryProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Salary, DtoSalary>()
                .ForMember(
                    d => d.Currency,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoCurrency>(s.Currency)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSalary, Salary>()
                .ForMember(
                    d => d.From,
                    o => o.MapFrom(
                        s => s.From.Value))
                                .ForMember(
                    d => d.To,
                    o => o.MapFrom(
                        s => s.To.Value))
                .ForMember(
                    d => d.Resume,
                    o => o.Ignore())
                .ForMember(
                    d => d.Currency,
                    o => o.Ignore());
        }
    }
}
