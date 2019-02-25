using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace EducationalInstitutions.Db.Models.Synonyms
{
    public class EducationalInstitutionSynonyms: RelationalDictionary
    {
        public virtual EducationalInstitution EducationalInstitution { get; set; }

        public virtual long EducationalInstitutionId { get; set; }
    }
}
