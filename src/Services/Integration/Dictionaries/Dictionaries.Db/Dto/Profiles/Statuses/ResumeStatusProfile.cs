using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Statuses;
using Dictionaries.Db.Dto.Models.Statuses;

namespace Dictionaries.Db.Dto.Profiles.Statuses
{
    public class DictionariestatusProfile : EntityDtoProfile
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
