namespace EventBus
{
    /// <summary>
    /// Event bus service contract
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        void Publish(IntegrationEvent @event);
    }
}
