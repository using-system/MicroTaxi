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
        private Domain.ITripRepository tripRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTripCommandHandler"/> class.
        /// </summary>
        /// <param name="tripRepository">The trip repository.</param>
        public RequestTripCommandHandler(Domain.ITripRepository tripRepository)
        {
            this.tripRepository = tripRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> Handle(RequestTripCommand request, CancellationToken cancellationToken)
        {
            this.tripRepository.Add(new Domain.Trip()
            {
                PassengerID = request.PassengerID
            });

            return await this.tripRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
