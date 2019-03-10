namespace Trip.Api.Application.DomainEvent.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    /// <summary>
    /// TripRequestedDomainEvent Handler
    /// </summary>
    /// <seealso cref="MediatR.INotificationHandler{Trip.Domain.TripRequestedDomainEvent}" />
    public class TripRequestedDomainEventHandler : INotificationHandler<Domain.TripRequestedDomainEvent>
    {
        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task Handle(Domain.TripRequestedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
