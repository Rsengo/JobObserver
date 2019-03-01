using BuildingBlocks.EntityFramework.Models;
using EducationalInstitutions.Db.Models.Employers;

namespace EducationalInstitutions.Db.Models
{
    public class Partners: RelationalEntity
    {
        public virtual Employer Employer { get; set; }

        public virtual long EmployerId { get; set; }

        public virtual long EducationalInstitutionId { get; set; }

        public virtual EducationalInstitution EducationalInstitution { get; set; }
    }
}
