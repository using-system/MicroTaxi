namespace Trip.Api.Infrastructure.Data
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MediatR;

    using Extensions;

    /// <summary>
    /// Trip Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class TripContext : DbContext, Domain.IUnitOfWork
    {
        private readonly IMediator mediator;

        public DbSet<Domain.Trip> Trips { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mediator">The mediator.</param>
        public TripContext(DbContextOptions<TripContext> options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityConfigurations.TripEntityConfiguration());
        }

        /// <summary>
        /// Saves the entities asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.mediator.DispatchDomainEventsAsync(this);

            await base.SaveChangesAsync();

            return true;
        }
    }
}
