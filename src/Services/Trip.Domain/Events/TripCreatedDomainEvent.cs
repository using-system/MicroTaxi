namespace Trip.Domain
{
    using MediatR;

    /// <summary>
    /// Trip Created Domain Event
    /// </summary>
    public class TripCreatedDomainEvent : INotification
    {
        /// <summary>
        /// Gets the trip.
        /// </summary>
        /// <value>
        /// The trip.
        /// </value>
        public Trip Trip { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripCreatedDomainEvent"/> class.
        /// </summary>
        /// <param name="trip">The trip.</param>
        public TripCreatedDomainEvent(Trip trip)
        {
            this.Trip = trip;
        }
    }
}
