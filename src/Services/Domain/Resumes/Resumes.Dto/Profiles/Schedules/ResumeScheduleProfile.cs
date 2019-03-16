using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Schedules;
using Resumes.Dto.Models.Schedules;

namespace Resumes.Dto.Profiles.Schedules
{
    public class ResumeScheduleProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeSchedule, DtoResumeSchedule>()
                .ForMember(
                    d => d.Schedule,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSchedule>(s.Schedule)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeSchedule, ResumeSchedule>()
                .ForMember(
                    d => d.Schedule,
                    o => o.Ignore())
                .ForMember(
                    d => d.Resume,
                    o => o.Ignore());
        }
    }
}
