namespace Trip.Api.Infrastructure.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Trip entity configuration
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Trip.Domain.Trip}" />
    public class TripEntityConfiguration : IEntityTypeConfiguration<Domain.Trip>
    {
        /// <summary>
        /// Configures the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public void Configure(EntityTypeBuilder<Domain.Trip> configuration)
        {
            configuration.ToTable("Trips", "Trip");
            configuration.HasKey(c => c.ID);
            configuration.Property(c => c.PassengerID)
                .IsRequired();
        }
    }
}
