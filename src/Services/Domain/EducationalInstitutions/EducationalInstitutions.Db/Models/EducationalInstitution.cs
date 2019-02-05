using System.Collections.Generic;

namespace EducationalInstitutions.Db.Models
{
    /// <summary>
    ///     Образовательное учреждение
    /// </summary>
    public class EducationalInstitution : BaseOrganization
    {
        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Факультеты
        /// </summary>
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}