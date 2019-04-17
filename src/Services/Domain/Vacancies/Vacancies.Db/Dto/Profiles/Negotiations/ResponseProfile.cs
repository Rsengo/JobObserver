using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Negotiations;
using Vacancies.Db.Dto.Models.Negotiations;

namespace Vacancies.Db.Dto.Profiles.Negotiations
{
    public class ResponseProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Response, DtoResponse>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResponse, Response>();
        }
    }
}
