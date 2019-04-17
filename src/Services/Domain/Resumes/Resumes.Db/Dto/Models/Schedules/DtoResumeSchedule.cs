using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Schedules
{
    public class DtoResumeSchedule : DtoEntity
    {
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

        [JsonProperty("schedule")]
        public virtual DtoSchedule Schedule { get; set; }

        [JsonProperty("schedule_id")]
        public virtual long ScheduleId { get; set; }
    }
}
