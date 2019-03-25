using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Negotiations;
using Dictionaries.Dto.Models.Negotiations;

namespace Dictionaries.Dto.Profiles.Negotiations
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
