using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaAPI.Utility.Error
{
    /// <summary>
    /// TODO: These messages are user visible, we should refine them and move it resource file.
    /// </summary>
    public class ErrorMessage
    {
        public static string MultipleErrorsOccurred = "One or more errors occurred.";

        public static string RequestTimeout = "The request is timed out.";

        public static string InternalServerError = "Internal server error occurred, please contact the support if it happens consistently.";

        public static string RequestBodyNotSupported = "The request body is not supported.";

        public static string UnauthenticatedWithInvalidHeader =
            "The request is unauthenticated, please check the header {0} are present correctly.";

        public static string UnauthenticatedWithInvalidSignature = "The signature cannot be verified.";

        public static string RequestPathNotFound = "The request path is not found.";

        public static string RequestRejected = "The request is rejected by policy.";

        public static string BadRequestBody = "The request body is invalid, please check the required fields are provided properly.";

        public static string ClientCertificateNotPresent = "The request is unauthorized because no client certificate is present.";

        public static string UnauthorizedClientCertificate = "The request is rejected because client certificate is unauthorized.";

        public static string MethodNotAllowed = "The request method is not allowed.";

        public static string QuotaCheckUserError = "Failed to check the quota due to user error.";

        public static string QuotaCheckInternalError = "Failed to check the quota due to internal error.";

        public static string QuotaNotEnough = "There is no enough quota.";

        public static string QPSExceed = "Failed to check the quota due to QPS Exceed.";

        public static string QPSCheckInternalError = "Failed to check the QPS due to internal error.";

        public static string ConcurrentExceed = "Failed to check the quota due to Concurrent Exceed.";

        public static string ConcourrentCheckInternalError = "Failed to check the Concurrent due to internal error.";

        public static string AuthorizationCheckUserError = "Failed to check the authorization due to user error.";

        public static string AuthorizationCheckInternalError = "Failed to check the authorization due to internal error.";

        #region IKB

        public static string DomainNotFound = "The request domain is not found.";

        public static string IntentionNotFound = "The request intention is not found.";

        #endregion

        #region Conversation

        public static string UnsupportedConversationContentType = "The content type {0} is unsupported.";

        #endregion
    }
}