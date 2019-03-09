namespace Trip.Api.Application.Model
{
    /// <summary>
    /// Trip api model
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Gets or sets the trip identifier.
        /// </summary>
        /// <value>
        /// The trip identifier.
        /// </value>
        public int TripID { get; set; }

        /// <summary>
        /// Gets or sets the passenger identifier.
        /// </summary>
        /// <value>
        /// The passenger identifier.
        /// </value>
        public int PassengerID { get; set; }
    }
}
