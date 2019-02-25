using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace EducationalInstitutions.Db.Models.Synonyms
{
    public class FacultySynonyms : RelationalDictionary
    {
        public virtual Faculty Faculty { get; set; }

        public virtual long FacultyId { get; set; }
    }
}
