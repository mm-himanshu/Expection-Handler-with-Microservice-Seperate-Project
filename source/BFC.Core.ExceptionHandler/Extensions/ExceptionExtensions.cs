namespace ExceptionHandler.Extensions
{
    public static class ExceptionExtensions
    {
        public static void HandleException(this Exception exception, ILogger logger)
        {
            logger.LogError(exception, exception.Message);
        }

        public static async Task HandleAPIException(this Exception exception, ILogger logger, HttpContext context)
        {
            logger.LogError(exception, exception.Message);

            HttpStatusCode statusCode;
            ApiErrorResponse apiErrorResponse;
            
           if (exception.GetType() == typeof(ValidationException))
            {
                var validationEx = (ValidationException)exception;
                statusCode = HttpStatusCode.BadRequest;
                apiErrorResponse = validationEx.ToErrorResponse();
            }
            else if(exception.GetType() == typeof(BaseException) || exception.GetType().BaseType == typeof(BaseException))
            {
                var baseEx = (BaseException)exception;
                statusCode = baseEx.StatusCode;
                apiErrorResponse = baseEx.ToErrorResponse();
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                apiErrorResponse = exception.ToErrorResponse();
            }
            
            
            var result = apiErrorResponse.ToString();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(result);
        }


        private static ApiErrorResponse ToErrorResponse(this BaseException e)
        {
            return new ApiErrorResponse
            {
                StatusCode = (int)e.StatusCode,
                ErrorCode = e.ErrorCode,
                Description = e.Description
            };
        }

        private static ApiErrorResponse ToErrorResponse(this Exception e)
        {
            return new ApiErrorResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ErrorCode =  "ERROR",//TODO: Needs to be centralized
                Description = "Due to technical error, this action could not proceed further, please try again after some time."//TODO: Needs to be centralized
            };
        }

        private static ApiErrorResponse ToErrorResponse(this ValidationException e)
        {
            return new ValidationApiErrorResponse
            {
                StatusCode = (int)e.StatusCode,
                ErrorCode = e.ErrorCode,
                Description = e.Description,
                Errors = e.ValidationResults.Select(_ => _.ErrorMessage)
            };
        }
    }
}
