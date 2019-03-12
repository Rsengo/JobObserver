using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace Vacancies.Dto.Models.Employers
{
    public class DtoDepartment : DtoDictionary
    {
        /// <summary>
        ///     Id Организации
        /// </summary>
        [JsonProperty("organization_id")]
        public virtual long OrganizationId { get; set; }
    }
}
