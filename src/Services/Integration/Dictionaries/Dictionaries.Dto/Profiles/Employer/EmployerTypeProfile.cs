using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models;
using Dictionaries.Db.Models.Employer;
using Dictionaries.Dto.Models;
using Dictionaries.Dto.Models.Employer;

namespace Dictionaries.Dto.Profiles.Employer
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
