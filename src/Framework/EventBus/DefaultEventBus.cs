namespace EventBus
{
    /// <summary>
    /// Default event bus
    /// </summary>
    /// <seealso cref="EventBus.IEventBus" />
    public class DefaultEventBus : IEventBus
    {
        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(IntegrationEvent @event)
        {

        }

        /// <summary>
        /// Subscribes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {

        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {

        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }
    }
}
