using SaAPI.Context;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;


namespace SaAPI.Common
{
    public class RequestContext
    {
        /// <summary>
        /// 请求方式
        /// </summary>
        public HttpVerb HttpVerb { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        public ResourcePath ResourcePath { get; set; }


        public long ContentLength { get; set; }

        /// <summary>
        /// 请求内容
        /// </summary>
        public byte[] RequestContent { get; set; }

        public Uri Uri { get; set; }

        public NameValueCollection Headers { get; set; }

        public HttpCookieCollection Cookies { get; set; }

        public string ClientIpAddress { get; set; }

        public string RequestAppId { get; set; }

        public string RequestUserId { get; set; }

        public string RequestSignature { get; set; }

        public long RequestTimestamp { get; set; }

        public string TraceId { get; set; }

        public static RequestContext Get(HttpContext httpContext)
        {
            return httpContext.Items["RequestContext"] as RequestContext;
        }

        public void Set(HttpContext httpContext)
        {
            httpContext.Items["RequestContext"] = this;
        }
    }
}