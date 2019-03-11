namespace Trip.Api.Application.IntegrationEvents
{
    /// <summary>
    /// TripRequested Integration Event
    /// </summary>
    /// <seealso cref="EventBus.IntegrationEvent" />
    public class TripRequestedIntegrationEvent : EventBus.IntegrationEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripRequestedIntegrationEvent"/> class.
        /// </summary>
        /// <param name="passengerID">The passenger identifier.</param>
        public TripRequestedIntegrationEvent(int passengerID)
        {
            this.PassengerID = passengerID;
        }

        /// <summary>
        /// Gets or sets the passenger identifier.
        /// </summary>
        /// <value>
        /// The passenger identifier.
        /// </value>
        public int PassengerID { get; set; }
    }
}
