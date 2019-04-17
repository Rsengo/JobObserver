using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Employers.Db.Models;
using Employers.Db.Dto.Models;

namespace Employers.Db.Dto.Profiles
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
