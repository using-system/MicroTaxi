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
    }
}
