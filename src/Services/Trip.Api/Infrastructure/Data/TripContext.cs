namespace Trip.Api.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Trip Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class TripContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {

        }

    }
}
