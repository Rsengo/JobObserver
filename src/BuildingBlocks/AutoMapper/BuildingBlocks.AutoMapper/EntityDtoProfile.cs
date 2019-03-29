namespace BuildingBlocks.AutoMapper
{
    using global::AutoMapper;

    public abstract class EntityDtoProfile: Profile
    {
        protected EntityDtoProfile()
        {
            Entity2Dto();
            Dto2Entity();
        }

        public abstract void Entity2Dto();
        public abstract void Dto2Entity();
    }
}
