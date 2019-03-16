using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Travel;
using Resumes.Dto.Models.Travel;

namespace Resumes.Dto.Profiles.Travel
{
    public class BusinessTripReadinessProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<BusinessTripReadiness, DtoBusinessTripReadiness>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoBusinessTripReadiness, BusinessTripReadiness>();
        }
    }
}
