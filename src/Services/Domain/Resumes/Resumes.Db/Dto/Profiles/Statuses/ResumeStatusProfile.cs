using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Statuses;
using Resumes.Db.Dto.Models.Statuses;

namespace Resumes.Db.Dto.Profiles.Statuses
{
    public class ResumeStatusProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeStatus, DtoResumeStatus>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeStatus, ResumeStatus>();
        }
    }
}
