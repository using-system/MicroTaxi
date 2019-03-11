﻿namespace EventBus
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

        /// <summary>
        /// Subscribes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;
    }
}
