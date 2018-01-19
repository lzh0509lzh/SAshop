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
        /// Url相关参数类
        /// </summary>
        public ResourcePath ResourcePath { get; set; }

        /// <summary>
        /// message-body长度
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// 请求内容
        /// </summary>
        public byte[] RequestContent { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Request Headers
        /// </summary>
        public NameValueCollection Headers { get; set; }


        /// <summary>
        /// Request Cookies
        /// </summary>
        public HttpCookieCollection Cookies { get; set; }

        /// <summary>
        /// 请求主机IP地址
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        public string RequestAppId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string RequestUserId { get; set; }

        /// <summary>
        /// Signature
        /// </summary>
        public string RequestSignature { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public long RequestTimestamp { get; set; }

        /// <summary>
        /// 请求唯一ID
        /// </summary>
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