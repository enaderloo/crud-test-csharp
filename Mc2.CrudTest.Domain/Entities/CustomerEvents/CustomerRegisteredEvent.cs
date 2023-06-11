
namespace Mc2.CrudTest.Domain.Entities.CustomerEvents
{
    public class CustomerRegisteredEvent : BaseDomainEvent
    {
        public long CustomerId { get; }

        public CustomerRegisteredEvent(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
