namespace BuildingBlocks.EntityFramework.Models
{
    /// <summary>
    ///     Интерфейс сущности БД
    /// </summary>
    public abstract class RelationalEntity
    {
        public virtual long Id { get; set; }
    }
}