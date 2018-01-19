using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaAPI.Context
{
    public static class HttpHeaderKey
    {
        public static string TraceId = "x-seven-request-activity-id";

        // This header is returned from conversation api to gateway for logging and debuging.
        public static string ConversationServeInstance = "x-seven-conversation-server";

        public static string Signature = "x-seven-request-signature";

        public static string AppId = "x-seven-request-app-id";

        public static string UserId = "x-seven-request-user-id";

        public static string Timestamp = "x-seven-request-timestamp";
    }
}