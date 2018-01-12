using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaAPI.Common
{
    public class HttpUtils
    {
        public static HttpVerb GetVerb(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            HttpVerb verb;
            var method = context.Request.HttpMethod;
            Enum.TryParse(method, true, out verb);
            return verb;
        }

        public static HttpMethod GetHttpMethod(HttpVerb verb)
        {
            switch (verb)
            {
                case HttpVerb.Get:
                    return HttpMethod.Get;
                case HttpVerb.Post:
                    return HttpMethod.Post;
                case HttpVerb.Put:
                    return HttpMethod.Put;
                case HttpVerb.Delete:
                    return HttpMethod.Delete;
                case HttpVerb.Head:
                    return HttpMethod.Head;
                case HttpVerb.Options:
                    return HttpMethod.Options;
                default:
                    throw new NotSupportedException($"Not supported http verb {verb}");
            }
        }

        public static bool IsReadVerb(HttpVerb verb)
        {
            return verb == HttpVerb.Get || verb == HttpVerb.Head || verb == HttpVerb.Options;
        }

        public static string GetHeaderValue(HttpContext context, string headerKey)
        {
            if (context?.Request?.Headers == null || string.IsNullOrWhiteSpace(headerKey))
            {
                return null;
            }

            if (context.Request.Headers.AllKeys.Any(key => string.Equals(key, headerKey, StringComparison.InvariantCultureIgnoreCase)))
            {
                return context.Request.Headers[headerKey];
            }

            return null;
        }
    }
}