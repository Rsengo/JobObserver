using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Certificates
{
    public class Certificate: RelationalDictionary
    {
        public virtual string Description { get; set; }

        public virtual string Url { get; set; }

        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }
    }
}
