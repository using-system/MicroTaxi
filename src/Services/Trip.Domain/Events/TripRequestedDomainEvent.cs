namespace Trip.Domain
{
    using MediatR;

    /// <summary>
    /// Trip Requested Domain Event
    /// </summary>
    public class TripRequestedDomainEvent : INotification
    {
        /// <summary>
        /// Gets the trip.
        /// </summary>
        /// <value>
        /// The trip.
        /// </value>
        public Trip Trip { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripRequestedDomainEvent"/> class.
        /// </summary>
        /// <param name="trip">The trip.</param>
        public TripRequestedDomainEvent(Trip trip)
        {
            this.Trip = trip;
        }
    }
}
