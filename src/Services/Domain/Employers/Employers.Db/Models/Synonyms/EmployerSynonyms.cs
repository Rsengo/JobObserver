using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Employers.Db.Models.Synonyms
{
    public class EmployerSynonyms: RelationalDictionary
    {
        public virtual Employer Employer { get; set; }

        public virtual long EmployerId { get; set; }
    }
}
