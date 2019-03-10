namespace Trip.Domain
{
    using System;

    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class TripDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripDomainException"/> class.
        /// </summary>
        public TripDomainException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TripDomainException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripDomainException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public TripDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
