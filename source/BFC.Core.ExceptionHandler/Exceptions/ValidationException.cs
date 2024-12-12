namespace ExceptionHandler.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ValidationException : BaseException
    {

        /// <summary>
        ///     Gets the <see cref="ValidationExceptionResult"/>.
        /// </summary>
        public List<ValidationExceptionResult> ValidationResults { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ValidationException(string errorCode, string description, string message, List<ValidationExceptionResult> validationResults)
            : base(errorCode, description, message)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.ValidationResults = validationResults;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public ValidationException(string errorCode, string description, string message, List<ValidationExceptionResult> validationResults, Exception inner)
            : base(errorCode, description, message, inner)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.ValidationResults = validationResults;
        }
    }
}
