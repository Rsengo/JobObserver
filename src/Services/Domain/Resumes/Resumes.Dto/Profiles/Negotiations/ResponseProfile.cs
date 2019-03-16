﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Negotiations;
using Resumes.Dto.Models.Negotiations;

namespace Resumes.Dto.Profiles.Negotiations
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
