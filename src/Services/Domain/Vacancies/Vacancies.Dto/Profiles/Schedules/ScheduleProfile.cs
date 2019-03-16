using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Schedules;
using Vacancies.Dto.Models.Schedules;

namespace Vacancies.Dto.Profiles.Schedules
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
