namespace EventBus
{
    using System.Threading.Tasks;

    /// <summary>
    /// DynamicIntegrationEventHandler contract
    /// </summary>
    public interface IDynamicIntegrationEventHandler
    {
        /// <summary>
        /// Handles the specified event data.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        /// <returns></returns>
        Task Handle(dynamic eventData);
    }
}
