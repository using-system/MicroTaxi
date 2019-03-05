namespace Trip.Api.Controllers.V1
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MediatR;

    using Trip.Api.Application.Commands;

    /// <summary>
    /// Trip Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TripController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripController" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">mediator</exception>
        public TripController()
        {
            this.mediator = null;
        }

        [Route("")]
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new RequestTripCommand(){ Name = "MyCommand" });
        }


        /// <summary>
        /// Requests the trip.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
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
