using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Certificates
{
    public class DtoCertificate: DtoDictionary
    {
        [JsonProperty("description")]
        public virtual string Description { get; set; }

        [JsonProperty("url")]
        public virtual string Url { get; set; }

        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }
    }
}
