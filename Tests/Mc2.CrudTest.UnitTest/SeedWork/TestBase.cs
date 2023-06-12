using Core.Domain;
using Microsoft.Extensions.Internal;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using SystemClock = Core.Domain.SystemClock;

namespace Mc2.CrudTest.UnitTest.SeedWork
{
    public abstract class TestBase
    {
        public static T AssertPublishedDomainEvent<T>(BaseEntity<T> aggregate) where T : IDomainEvent
        {
            var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

            if (domainEvent == null)
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvent;
        }

        public static List<T> AssertPublishedDomainEvents<T>(BaseEntity<T> aggregate) where T : IDomainEvent
        {
            var domainEvents = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().ToList();

            if (!domainEvents.Any())
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvents;
        }

        public static void AssertBrokenRule<TRule>(TestDelegate testDelegate) where TRule : class, IBusinessRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var businessRuleValidationException = Assert.Catch<BusinessRuleValidationException>(testDelegate, message);
            if (businessRuleValidationException != null)
            {
                Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
            }
        }

        [TearDown]
        public void AfterEachTest()
        {
            SystemClock.Reset();
        }
    }
}
