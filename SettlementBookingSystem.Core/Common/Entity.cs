using System;

namespace SettlementBookingSystem.Core.Common
{
    public class Entity : IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
