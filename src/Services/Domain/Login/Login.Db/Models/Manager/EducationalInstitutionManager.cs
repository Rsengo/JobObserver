using System.Collections.Generic;
using Login.Db.Models.Manager;
using Login.Db.Models.Manager.Permissions;
using Login.Db.Models.Manager.Types;

namespace JobObserver.Db.Models.Users.Manager
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

        /// <summary>
        ///     Тип менеджера
        /// </summary>
        public virtual EducationalInstitutionManagerType ManagerType { get; set; }

        /// <summary>
        ///     Id Типа менеджера
        /// </summary>
        public virtual long? ManagerTypeId { get; set; }

        /// <summary>
        ///     Доп. возможности
        /// </summary>
        public virtual ICollection<EducationalInstitutionManagerPermission> Permissions { get; set; }
    }
}