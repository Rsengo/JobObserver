using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Statuses;
using Dictionaries.Dto.Models.Statuses;

namespace Dictionaries.Dto.Profiles.Statuses
{
    public class VacancyStatusProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<VacancyStatus, DtoVacancyStatus>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoVacancyStatus, VacancyStatus>();
        }
    }
}
