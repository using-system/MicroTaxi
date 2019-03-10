namespace Trip.Api.Application.Validators
{
    using FluentValidation;

    /// <summary>
    /// RequestTripCommand Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Trip.Api.Application.Commands.RequestTripCommand}" />
    public class RequestTripCommandValidator : AbstractValidator<Commands.RequestTripCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTripCommandValidator"/> class.
        /// </summary>
        public RequestTripCommandValidator()
        {
            this.RuleFor(command => command.PassengerID).NotEmpty().WithMessage("No passenger identifier found");
        }
    }
}
