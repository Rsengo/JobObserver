namespace Login.Db.Models.Manager
{
    /// <summary>
    ///     Менеджер (базовый)
    /// </summary>
    public abstract class BaseManager : BaseUser
    {
        /// <summary>
        ///     Должность
        /// </summary>
        public virtual string Position { get; set; }
    }
}