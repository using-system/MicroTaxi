namespace Trip.Api.Application.IntegrationEvents
{
    using System.Threading.Tasks;

    using EventBus;

    /// <summary>
    /// TripIntegrationEventService contract
    /// </summary>
    public interface ITripIntegrationEventService
    {
        /// <summary>
        /// Publishes the events through event bus asynchronous.
        /// </summary>
        /// <returns></returns>
        Task PublishEventsThroughEventBusAsync();

        /// <summary>
        /// Adds the and save event asynchronous.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        Task AddAndSaveEventAsync(IntegrationEvent @event);
    }
}
