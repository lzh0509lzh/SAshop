using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaAPI.Context
{
    public static class HttpHeaderKey
    {
        public static string TraceId = "x-msxiaoice-request-activity-id";

        // This header is returned from conversation api to gateway for logging and debuging.
        public static string ConversationServeInstance = "x-msxiaoice-conversation-server";

        public static string Signature = "x-msxiaoice-request-signature";

        public static string AppId = "x-msxiaoice-request-app-id";

        public static string UserId = "x-msxiaoice-request-user-id";

        public static string Timestamp = "x-msxiaoice-request-timestamp";
    }
}