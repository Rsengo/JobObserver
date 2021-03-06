﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Salaries;
using Vacancies.Db.Dto.Models.Salaries;

namespace Vacancies.Db.Dto.Profiles.Salaries
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
                    d => d.Currency,
                    o => o.Ignore());
        }
    }
}
