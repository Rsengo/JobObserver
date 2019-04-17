using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Employers.Db.Models;
using Employers.Db.Dto.Models;

namespace Employers.Db.Dto.Profiles
{
    public class PartnersProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Partners, DtoPartners>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoPartners, Partners>()
                .ForMember(
                    d => d.Employer,
                    o => o.Ignore());
        }
    }
}
