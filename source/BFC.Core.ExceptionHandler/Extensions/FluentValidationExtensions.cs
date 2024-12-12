namespace ExceptionHandler.Extensions
{
    public static class FluentValidationExtensions
    {
        public static ValidationException ToException(this IList<ValidationFailure> validationFailures,
            string description = "Validation Failed")
        {
            var results = new List<ValidationExceptionResult>(
                validationFailures.Select(
                    x => new ValidationExceptionResult
                    {
                        AttemptedValue = x.AttemptedValue,
                        ErrorMessage = x.ErrorMessage,
                        PropertyName = x.PropertyName,
                    }));

            return new ValidationException("ERROR-VALIDATION", description, "Validation Error", results);
        }
    }
}
