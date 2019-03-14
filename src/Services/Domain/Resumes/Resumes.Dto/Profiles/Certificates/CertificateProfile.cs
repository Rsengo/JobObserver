using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Certificates;
using Resumes.Dto.Models.Certificates;

namespace Resumes.Dto.Profiles.Certificates
{
    public class CertificateProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Certificate, DtoCertificate>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCertificate, Certificate>()
                .ForMember(
                    d => d.Resume, 
                    o => o.Ignore());
        }
    }
}
