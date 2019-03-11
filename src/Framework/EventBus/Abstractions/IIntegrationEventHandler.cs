namespace EventBus
{
    using System.Threading.Tasks;

    /// <summary>
    /// Integration Event Handler contract
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <seealso cref="EventBus.IIntegrationEventHandler" />
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        Task Handle(TIntegrationEvent @event);
    }

    /// <summary>
    /// Integration Event Handler contract
    /// </summary>
    /// <seealso cref="EventBus.IIntegrationEventHandler" />
    public interface IIntegrationEventHandler
    {
    }
}
