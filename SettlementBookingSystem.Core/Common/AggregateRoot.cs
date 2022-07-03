using System.Collections.Generic;

namespace SettlementBookingSystem.Core.Common
{
    public class AggregateRoot : Entity
    {
        private List<IDomainEvent> _events = new();
        public IEnumerable<IDomainEvent> DomainEvents => _events;

        protected void AddEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
    }
}
