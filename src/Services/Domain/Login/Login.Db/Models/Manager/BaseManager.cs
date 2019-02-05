namespace Login.Db.Models.Manager
{
    /// <summary>
    ///     Менеджер (базовый)
    /// </summary>
    /// <typeparam name="TOrganization">Тип организации</typeparam>
    public abstract class BaseManager : BaseUser
    {
        /// <summary>
        ///     Должность
        /// </summary>
        public virtual string Position { get; set; }
    }
}