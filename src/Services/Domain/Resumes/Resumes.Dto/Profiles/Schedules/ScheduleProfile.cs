using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Schedules;
using Resumes.Dto.Models.Schedules;

namespace Resumes.Dto.Profiles.Schedules
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
