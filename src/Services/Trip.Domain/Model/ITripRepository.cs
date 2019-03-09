namespace Trip.Domain
{
    /// <summary>
    /// Trip repository contract
    /// </summary>
    public interface ITripRepository : IRepository<Trip>
    {
        /// <summary>
        /// Adds the specified trip.
        /// </summary>
        /// <param name="trip">The trip.</param>
        /// <returns></returns>
        Trip Add(Trip trip);
    }
}
