namespace Trip.Domain
{
    /// <summary>
    /// Trip entity
    /// </summary>
    /// <seealso cref="Trip.Domain.EntityBase" />
    public class Trip : EntityBase
    {
        /// <summary>
        /// Gets or sets the passenger identifier.
        /// </summary>
        /// <value>
        /// The passenger identifier.
        /// </value>
        public int PassengerID { get; set; }

        public static Trip New(int passengerID)
        {
            Trip trip = new Trip()
            {
                PassengerID = passengerID
            };

            trip.AddDomainEvent(new TripCreatedDomainEvent(trip));

            return trip;
        }
    }
}
