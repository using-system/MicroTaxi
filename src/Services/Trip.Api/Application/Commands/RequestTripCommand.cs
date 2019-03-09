namespace Trip.Api.Application.Commands
{
    using MediatR;

    /// <summary>
    /// Request Trip Command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Boolean}" />
    public class RequestTripCommand : IRequest<bool>
    {
        public int PassengerID { get; set; }
    }
}
