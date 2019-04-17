using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Employers;
using Vacancies.Db.Dto.Models.Employers;

namespace Vacancies.Db.Dto.Profiles.Employers
{
    public class DepartmentProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Department, DtoDepartment>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoDepartment, Department>()
                .ForMember(
                    d => d.Organization, 
                    o => o.Ignore());
        }
    }
}
