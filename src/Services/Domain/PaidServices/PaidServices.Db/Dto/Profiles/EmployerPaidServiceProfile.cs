using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using PaidServices.Db.Models;
using PaidServices.Db.Dto.Models;

namespace PaidServices.Db.Dto.Profiles
{
    public class EmployerPaidServiceProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EmployerPaidService, DtoEmployerPaidService>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployerPaidService, EmployerPaidService>();
        }
    }
}
