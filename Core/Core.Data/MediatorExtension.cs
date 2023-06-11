using MediatR;

namespace Core.Data;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, BaseDbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<BaseEntity<long>>()
            .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
           // .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
