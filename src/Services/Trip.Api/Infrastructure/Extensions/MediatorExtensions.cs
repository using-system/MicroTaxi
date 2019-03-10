namespace Trip.Api.Infrastructure.Extensions
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MediatR;

    using Trip.Domain;

    /// <summary>
    /// Mediator extensions methods
    /// </summary>
    public static class MediatorExtensions
    {
        /// <summary>
        /// Dispatches the domain events asynchronous.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
