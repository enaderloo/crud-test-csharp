
using Core.Domain;
using System.Collections;
using System.Reflection;

namespace Mc2.CrudTest.UnitTest.SeedWork
{
    public class DomainEventsTestHelper
    {
        public static List<IDomainEvent> GetAllDomainEvents<T>(BaseEntity<T> aggregate)
        {
            List<IDomainEvent> domainEvents = new();

            if (aggregate.DomainEvents != null)
            {
                domainEvents.AddRange((IEnumerable<IDomainEvent>)aggregate.DomainEvents);
            }

            var fields = aggregate.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(aggregate.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

            foreach (var field in fields)
            {
                var isEntity = field.FieldType.IsAssignableFrom(typeof(BaseEntity<T>));

                if (isEntity)
                {
                    var entity = field.GetValue(aggregate) as BaseEntity<T>;
                    domainEvents.AddRange(GetAllDomainEvents(entity).ToList());
                }

                if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    if (field.GetValue(aggregate) is IEnumerable enumerable)
                    {
                        foreach (var en in enumerable)
                        {
                            if (en is BaseEntity<T> entityItem)
                            {
                                domainEvents.AddRange(GetAllDomainEvents(entityItem));
                            }
                        }
                    }
                }
            }

            return domainEvents;
        }

        public static void ClearAllDomainEvents<T>(BaseEntity<T> aggregate)
        {
            aggregate.ClearDomainEvents();

            var fields = aggregate.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(aggregate.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

            foreach (var field in fields)
            {
                var isEntity = field.FieldType.IsAssignableFrom(typeof(BaseEntity<T>));

                if (isEntity)
                {
                    var entity = field.GetValue(aggregate) as BaseEntity<T>;
                    ClearAllDomainEvents(entity);
                }

                if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    if (field.GetValue(aggregate) is IEnumerable enumerable)
                    {
                        foreach (var en in enumerable)
                        {
                            if (en is BaseEntity<T> entityItem)
                            {
                                ClearAllDomainEvents(entityItem);
                            }
                        }
                    }
                }
            }
        }
    }
}
