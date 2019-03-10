namespace Trip.Domain
{
    using System.Collections.Generic;

    using MediatR;

    /// <summary>
    /// Entity base class
    /// </summary>
    /// <seealso cref="Trip.Domain.IEntity" />
    public abstract class EntityBase : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        private List<INotification> _domainEvents;

        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>
        /// The domain events.
        /// </value>
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        /// <summary>
        /// Adds the domain event.
        /// </summary>
        /// <param name="eventItem">The event item.</param>
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Removes the domain event.
        /// </summary>
        /// <param name="eventItem">The event item.</param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// Clears the domain events.
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
