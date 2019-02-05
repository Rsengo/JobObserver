using System.Collections.Generic;
using Login.Db.Models.Manager.Permissions;

namespace Login.Db.Models.Manager.Types
{
    /// <summary>
    ///     Тип менеджера ОУ
    /// </summary>
    public class EducationalInstitutionManagerType : BaseManagerType
    {
        /// <summary>
        ///     Возможности, привилегии
        /// </summary>
        public virtual ICollection<EducationalInstitutionManagerPermission> AvailablePermissions { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }
    }
}