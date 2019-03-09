namespace Trip.Domain
{
    /// <summary>
    /// Entity base class
    /// </summary>
    /// <seealso cref="Trip.Domain.IEntity" />
    public abstract class EntityBase : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }
    }
}
