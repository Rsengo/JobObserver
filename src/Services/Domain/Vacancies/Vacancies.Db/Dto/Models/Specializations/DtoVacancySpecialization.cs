using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Vacancies.Db.Dto.Models.Specializations
{
    public class DtoVacancySpecialization : DtoEntity
    {
        [JsonProperty("vacancy_id")]
        public virtual long VacancyId { get; set; }

        [JsonProperty("specialization")]
        public virtual DtoSpecialization Specialization { get; set; }

        [JsonProperty("specialization_id")]
        public virtual long SpecializationId { get; set; }
    }
}
