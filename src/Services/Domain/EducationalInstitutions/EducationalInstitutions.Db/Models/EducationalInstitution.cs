using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;
using EducationalInstitutions.Db.Models.Geographic;
using EducationalInstitutions.Db.Models.Synonyms;

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
        ///     Город.
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        ///     Факультеты
        /// </summary>
        public virtual ICollection<Faculty> Faculties { get; set; }

        /// <summary>
        /// Снинонимичные названия
        /// </summary>
        public virtual ICollection<EducationalInstitutionSynonyms> Synonyms { get; set; }

        public virtual ICollection<Partners> Partners { get; set; }
    }
}