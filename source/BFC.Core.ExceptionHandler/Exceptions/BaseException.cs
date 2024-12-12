namespace ExceptionHandler.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BaseException : Exception
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        public BaseException()
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
            this.ErrorCode = "ERROR"; //TODO: Needs to be centralized
            this.Description = "Due to technical error, this action could not proceed further, please try again after some time."; //TODO: Needs to be centralized
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public BaseException(string errorCode, string description, string message)
            : base(message)
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
            this.ErrorCode = errorCode;
            this.Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public BaseException(string errorCode, string description, string message, Exception inner)
            : base(message, inner)
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
            this.ErrorCode = errorCode;
            this.Description = description;
        }
    }
}
