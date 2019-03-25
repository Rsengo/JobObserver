using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Schedules;
using Dictionaries.Dto.Models.Schedules;

namespace Dictionaries.Dto.Profiles.Schedules
{
    public class ScheduleProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Schedule, DtoSchedule>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSchedule, Schedule>();
        }
    }
}
