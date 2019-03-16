using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Travel;
using Resumes.Dto.Models.Travel;

namespace Resumes.Dto.Profiles.Travel
{
    public class TravelTimeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<TravelTime, DtoTravelTime>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoTravelTime, TravelTime>();
        }
    }
}
