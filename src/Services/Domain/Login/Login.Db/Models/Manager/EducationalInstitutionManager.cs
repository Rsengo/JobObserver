using System.Collections.Generic;

namespace Login.Db.Models.Manager
{
    /// <summary>
    ///     Менеджер ОУ
    /// </summary>
    public class EducationalInstitutionManager : BaseManager
    {
        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }
    }
}