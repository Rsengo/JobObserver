using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace Vacancies.Dto.Models.Driving
{
    public class DtoVacancyDrivingLicenseType : DtoEntity
    {
        [JsonProperty("vacancy_id")]
        public virtual long VacancyId { get; set; }

        [JsonProperty("driving_license_type")]
        public virtual DtoDrivingLicenseType DrivingLicenseType { get; set; }

        [JsonProperty("driving_license_type_id")]
        public virtual long DrivingLicenseTypeId { get; set; }
    }
}
