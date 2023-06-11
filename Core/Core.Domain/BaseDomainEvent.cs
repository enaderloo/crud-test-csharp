
namespace Core.Domain
{
    public class BaseDomainEvent : IDomainEvent
    {
        public BaseDomainEvent()
        {
            OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
