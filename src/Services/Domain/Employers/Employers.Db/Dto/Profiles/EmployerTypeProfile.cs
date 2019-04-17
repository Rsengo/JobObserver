using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Employers.Db.Models;
using Employers.Db.Dto.Models;

namespace Employers.Db.Dto.Profiles
{
    public class EmployerTypeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EmployerType, DtoEmployerType>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployerType, EmployerType>();
        }
    }
}
