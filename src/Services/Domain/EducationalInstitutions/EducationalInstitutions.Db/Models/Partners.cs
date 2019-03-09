using BuildingBlocks.EntityFramework.Models;

namespace EducationalInstitutions.Db.Models
{
    public class Partners: RelationalEntity
    {
        public virtual long EmployerId { get; set; }

        public virtual long EducationalInstitutionId { get; set; }

        public virtual EducationalInstitution EducationalInstitution { get; set; }
    }
}
