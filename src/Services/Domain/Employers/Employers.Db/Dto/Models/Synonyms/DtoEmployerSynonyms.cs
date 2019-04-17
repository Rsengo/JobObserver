using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace Employers.Db.Dto.Models.Synonyms
{
    public class DtoEmployerSynonyms: RelationalDictionary
    {
        [JsonProperty("employer_id")]
        public virtual long EmployerId { get; set; }
    }
}
