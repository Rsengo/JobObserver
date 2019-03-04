using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using Resumes.Db.Models.Geographic;

namespace Resumes.Db.Models.ResumeAreas
{
    public abstract class BaseResumeArea: RelationalEntity
    {
        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }

        public virtual Area Area { get; set; }

        public virtual long AreaId { get; set; }
    }
}
