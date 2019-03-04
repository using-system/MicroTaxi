namespace Trip.Api.Application.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    /// <summary>
    /// Request Trip Command Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Trip.Api.Application.Commands.RequestTripCommand, System.Boolean}" />
    public class RequestTripCommandHandler : IRequestHandler<RequestTripCommand, bool>
    {
        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<bool> Handle(RequestTripCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
