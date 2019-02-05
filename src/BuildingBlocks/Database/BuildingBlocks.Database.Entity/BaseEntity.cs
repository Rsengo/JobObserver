namespace BuildingBlocks.Database.Entity
{
    public abstract class BaseEntity<TEntityId> 
        where TEntityId : struct
    {
        /// <summary>
        ///     ID сущности
        /// </summary>
        public virtual TEntityId Id { get; set; }
    }
}
