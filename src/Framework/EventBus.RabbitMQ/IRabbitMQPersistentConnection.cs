namespace EventBus.RabbitMQ
{
    using System;
    using global::RabbitMQ.Client;

    /// <summary>
    /// RabbitMQPersistentConnection contract
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        bool IsConnected { get; }

        /// <summary>
        /// Tries the connect.
        /// </summary>
        /// <returns></returns>
        bool TryConnect();

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <returns></returns>
        IModel CreateModel();
    }
}
