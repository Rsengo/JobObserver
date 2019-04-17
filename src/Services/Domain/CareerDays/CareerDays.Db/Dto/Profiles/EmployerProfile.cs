using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models;
using CareerDays.Db.Dto.Models;

namespace CareerDays.Db.Dto.Profiles
{
    public class EmployerProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Employer, DtoEmployer>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployer, Employer>()
                .ForMember(d => d.CareerDays, o => o.Ignore());
        }
    }
}
