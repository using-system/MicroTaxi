namespace Trip.Api.Infrastructure.DependencyModules
{
    using System.Reflection;

    using Autofac;

    /// <summary>
    /// Application autfac Module
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ApplicationModule : Autofac.Module
    {
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationModule"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ApplicationModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new Application.Queries.TripQueries(this.connectionString))
                .As<Application.Queries.ITripQueries>()
                .InstancePerLifetimeScope();

            //Register all repositories
            builder.RegisterAssemblyTypes(typeof(Infrastructure.EntityFramework.Repositories.TripRepository).GetTypeInfo().Assembly)
             .AsClosedTypesOf(typeof(Domain.IRepository<>));
        }
    }
}
