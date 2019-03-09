namespace Trip.Api.Controllers.V1
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Trip.Api.Application.Commands;
    using Trip.Api.Application.Queries;
    using Trip.Api.Application.Model;

    /// <summary>
    /// Trip Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TripController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly ITripQueries tripQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="tripQueries">The trip queries.</param>
        /// <exception cref="ArgumentNullException">mediator</exception>
        public TripController(IMediator mediator, ITripQueries tripQueries)
        {
            this.mediator = mediator;
            this.tripQueries = tripQueries;
        }

        [Route("{tripId:int}")]
        [HttpGet()]
        [ProducesResponseType(typeof(Trip), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetTripAsync(int tripId)
        {
            try
            {
                var trip = await this.tripQueries.GetTripAsync(tripId);

                return Ok(trip);
            }
            catch(Exception exc)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Requests the trip.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [Route("request")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RequestTrip([FromBody] RequestTripCommand command)
        {
            var commandResult = await mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
