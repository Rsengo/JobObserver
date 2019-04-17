using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Statuses;
using Vacancies.Db.Dto.Models.Statuses;

namespace Vacancies.Db.Dto.Profiles.Statuses
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
