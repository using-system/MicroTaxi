namespace Trip.Api.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Trip Repository
    /// </summary>
    /// <seealso cref="Trip.Domain.ITripRepository" />
    public class TripRepository : Domain.ITripRepository
    {
        private readonly TripContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TripRepository(TripContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public Domain.IUnitOfWork UnitOfWork => this.context;

        /// <summary>
        /// Adds the specified trip.
        /// </summary>
        /// <param name="trip">The trip.</param>
        /// <returns></returns>
        public Domain.Trip Add(Domain.Trip trip)
        {
            return this.context.Add(trip).Entity;
        }
    }
}
