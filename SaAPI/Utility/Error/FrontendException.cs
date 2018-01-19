using System;
using System.Collections.Specialized;
using System.Net;

namespace SaAPI.Utility.Error
{
    public class FrontendException : Exception
    {
        public FrontendException()
        {
        }

        public FrontendException(string messsage) : base(messsage, null)
        {
            //base()的意思是调用基类的构造函数......
        }

        public FrontendException(string messsage, Exception innerException) : base(messsage, innerException)
        {

        }
    }

    public class FrontendHttpException : FrontendException
    {
        public string ErrorCode { get; private set; }

        public HttpStatusCode HttpStatusCode { get; private set; }

        public NameValueCollection Headers { get; private set; }

        public FrontendHttpException()
        {

        }

        public FrontendHttpException(string errorCode, HttpStatusCode httpStatusCode, string message)
            : this(errorCode, httpStatusCode, message, null)
        {
        }

        public FrontendHttpException(string errorCode, HttpStatusCode httpStatusCode, string message, Exception innerException)
            : this(errorCode, httpStatusCode, message, null, innerException)
        {
        }

        public FrontendHttpException(string errorCode, HttpStatusCode httpStatusCode, string message, NameValueCollection headers, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            Headers = headers;
        }
    }
}