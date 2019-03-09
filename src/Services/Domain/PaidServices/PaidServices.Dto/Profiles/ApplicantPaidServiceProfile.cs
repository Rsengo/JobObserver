using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using PaidServices.Db.Models;
using PaidServices.Dto.Models;

namespace PaidServices.Dto.Profiles
{
    public class ApplicantPaidServiceProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ApplicantPaidService, DtoApplicantPaidService>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoApplicantPaidService, ApplicantPaidService>();
        }
    }
}
