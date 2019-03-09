namespace Trip.Api.Application.Queries
{
    using System.Threading.Tasks;

    /// <summary>
    /// Trip queries contract
    /// </summary>
    public interface ITripQueries
    {
        /// <summary>
        /// Gets the trip asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Model.Trip> GetTripAsync(int id);
    }
}
