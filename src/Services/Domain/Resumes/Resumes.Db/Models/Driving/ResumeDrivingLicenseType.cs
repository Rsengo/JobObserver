using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Driving
{
    public class ResumeDrivingLicenseType : RelationalEntity
    {
        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }

        public virtual DrivingLicenseType DrivingLicenseType { get; set; }

        public virtual long DrivingLicenseTypeId { get; set; }
    }
}
