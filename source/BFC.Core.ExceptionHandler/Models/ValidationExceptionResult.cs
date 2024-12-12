namespace ExceptionHandler.Models
{
    public class ValidationExceptionResult
    {
        /// <summary>
        ///     Gets or sets the attempted value.
        /// </summary>
        public object AttemptedValue { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets or sets the property name.
        /// </summary>
        public string PropertyName { get; set; }
    }
}