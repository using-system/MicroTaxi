namespace Trip.Api.Application.DomainEvent.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    /// <summary>
    /// TripCreatedDomain EventHandler
    /// </summary>
    /// <seealso cref="MediatR.INotificationHandler{Trip.Domain.TripCreatedDomainEvent}" />
    public class TripCreatedDomainEventHandler : INotificationHandler<Domain.TripCreatedDomainEvent>
    {
        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task Handle(Domain.TripCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
