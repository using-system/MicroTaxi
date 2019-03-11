namespace Trip.Api.Application.IntegrationEvents
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.Extensions.Logging;

    using EventBus;

    /// <summary>
    /// TripIntegrationEvent Service
    /// </summary>
    /// <seealso cref="Trip.Api.Application.IntegrationEvents.ITripIntegrationEventService" />
    public class TripIntegrationEventService : ITripIntegrationEventService
    {
        private ILogger logger;

        private IEventBus eventBus;

        private static List<IntegrationEvent> events = new List<IntegrationEvent>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TripIntegrationEventService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public TripIntegrationEventService(IEventBus eventBus, ILogger<TripIntegrationEventService> logger)
        {
            this.logger = logger;
            this.eventBus = eventBus;
        }


        /// <summary>
        /// Adds the and save event asynchronous.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public Task AddAndSaveEventAsync(IntegrationEvent @event)
        {
            this.logger.LogInformation("----- Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", @event.ID, @event);

            events.Add(@event);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Publishes the events through event bus asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task PublishEventsThroughEventBusAsync()
        {
            foreach(var @event in events)
            {
                this.eventBus.Publish(@event);
            }

            return Task.CompletedTask;
        }
    }
}
