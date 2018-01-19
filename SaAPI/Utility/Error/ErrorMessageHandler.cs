using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SaAPI.Utility.Error
{
    public class ErrorMessageHandler
    {
        //private static readonly ITraceableLog Logger = CustomLogManager.GetTraceableLog(MethodBase.GetCurrentMethod().DeclaringType);

        public static HttpErrorResponse CreateResponseFromException(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var aggregatedException = exception as AggregateException;
            if (aggregatedException != null)
            {
                exception = ConvertAggregatedExceptionToGatewayException(aggregatedException);
            }

            HttpStatusCode statusCode;
            ErrorResponse errorOuput;
            NameValueCollection errorHeaders = null;

            if (exception.Handled(ex => (ex is TaskCanceledException || ex is TimeoutException)))
            {
                statusCode = HttpStatusCode.RequestTimeout;
                errorOuput = new ErrorResponse(
                    new Error
                    {
                        Code = ErrorCode.RequestTimeout,
                        Message = ErrorMessage.RequestTimeout
                    });
            }
            else
            {
                statusCode = GenerateHttpStatusCode(exception);
                errorHeaders = GenerateHttpHeaders(exception);
                errorOuput = GenerateErrorOutputFromException(exception);
            }

            //Logger.ErrorFormat("Status code = {0}, error message = {1}", statusCode, errorOuput?.Error == null ? "<null>" : errorOuput.Error.Message);

            return new HttpErrorResponse
            {
                ErrorOutput = errorOuput,
                HttpStatusCode = statusCode,
                Headers = errorHeaders
            };
        }

        private static Exception ConvertAggregatedExceptionToGatewayException(AggregateException aggregatedException)
        {
            if (aggregatedException == null)
            {
                throw new ArgumentNullException(nameof(aggregatedException));
            }

            var flatternedException = aggregatedException.Flatten();

            IEnumerable<HttpStatusCode> httpStatusCodes = flatternedException
                .InnerExceptions
                .OfType<FrontendHttpException>()
                .Select(innerException => innerException.HttpStatusCode)
                .ToArray();

            if (httpStatusCodes.Any() && httpStatusCodes.Count() == flatternedException.InnerExceptions.Count)
            {
                var httpStatusCode = httpStatusCodes.GetMax(code => (int)code, c => (HttpStatusCode)c);

                return new FrontendHttpException(
                    ErrorCode.MultipleErrorsOccurred,
                    httpStatusCode,
                    ErrorMessage.MultipleErrorsOccurred,
                    flatternedException);
            }

            return aggregatedException;
        }

        private static HttpStatusCode GenerateHttpStatusCode(Exception exception)
        {
            var frontendException = exception as FrontendHttpException;

            if (frontendException != null)
            {
                return frontendException.HttpStatusCode;
            }

            return HttpStatusCode.InternalServerError;
        }

        private static NameValueCollection GenerateHttpHeaders(Exception exception)
        {
            var frontendException = exception as FrontendHttpException;

            return frontendException?.Headers;
        }

        private static ErrorResponse GenerateErrorOutputFromException(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var frontendException = exception as FrontendHttpException;
            if (frontendException != null)
            {
                return new ErrorResponse(
                    new Error
                    {
                        Code = string.IsNullOrWhiteSpace(frontendException.ErrorCode) ? ErrorCode.InternalServerError : frontendException.ErrorCode,
                        Message = string.IsNullOrWhiteSpace(frontendException.Message) ? ErrorMessage.InternalServerError : frontendException.Message,
                    });
            }

            return new ErrorResponse
                (
                new Error
                {
                    Code = ErrorCode.InternalServerError,
                    Message = ErrorMessage.InternalServerError
                });
        }
    }
}