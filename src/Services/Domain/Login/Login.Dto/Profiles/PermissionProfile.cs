using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Login.Db.Models;
using Login.Dto.Models;

namespace Login.Dto.Profiles
{
    public class PermissionProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Permission, DtoPermission>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoPermission, Permission>();
        }
    }
}
