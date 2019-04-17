using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace EducationalInstitutions.Db.Dto.Models.Synonyms
{
    public class DtoFacultySynonyms : RelationalDictionary
    {
        [JsonProperty("faculty_id")]
        public virtual long FacultyId { get; set; }
    }
}
