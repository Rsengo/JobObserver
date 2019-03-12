using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Dto.Models.Driving
{
    public class DtoResumeDrivingLicenseType : DtoEntity
    {
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

        [JsonProperty("driving_license_type")]
        public virtual DtoDrivingLicenseType DrivingLicenseType { get; set; }

        [JsonProperty("driving_license_type_id")]
        public virtual long DrivingLicenseTypeId { get; set; }
    }
}
