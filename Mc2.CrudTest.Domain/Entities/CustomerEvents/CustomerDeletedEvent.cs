
namespace Mc2.CrudTest.Domain.Entities.CustomerEvents
{
    public class CustomerDeletedEvent : BaseDomainEvent
    {
        public bool IsDeleted { get; private set; }
        public CustomerDeletedEvent(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
    }
}
