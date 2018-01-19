using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace SaAPI.Utility.Error
{
    public class HttpErrorResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ErrorResponse ErrorOutput { get; set; }

        public NameValueCollection Headers { get; set; }
    }

    public class Error
    {
        [JsonProperty(Required = Required.Always)]
        public string Code { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Message { get; set; }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }

        public ErrorResponse(Error error)
        {
            Error = error;
        }

        [JsonProperty(Required = Required.Always)]
        public Error Error { get; set; }
    }
}