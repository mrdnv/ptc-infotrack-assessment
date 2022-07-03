namespace SettlementBookingSystem.Core.Common
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot Get();

        void Save(TAggregateRoot aggregateRoot);
    }
}
