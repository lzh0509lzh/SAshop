namespace SaAPI.Utility.Error
{
    public class ErrorCode
    {
        /// <summary>
        /// 发生多个错误
        /// </summary>
        public static string MultipleErrorsOccurred = "10001";
        /// <summary>
        /// 系统错误
        /// </summary>
        public static string InternalServerError = "10001";
        /// <summary>
        /// 请求超时
        /// </summary>
        public static string RequestTimeout = "10002";
        /// <summary>
        /// 请求方式错误
        /// </summary>
        public static string RequestMethodError = "10003";
        /// <summary>
        /// 请求Header错误
        /// </summary>
        public static string RequestHeaderError = "10004";
        /// <summary>
        /// API版本不支持
        /// </summary>
        public static string ApiVersionNotSupported = "10004";
        /// <summary>
        /// 请求Body错误
        /// </summary>
        public static string RequestBodyError = "10005";
        /// <summary>
        /// 请求Url参数错误
        /// </summary>
        public static string RequestUrlNotFound = "10006";
        /// <summary>
        /// 请求Url路径错误
        /// </summary>
        public static string RequestPathNotFound = "10007";
        /// <summary>
        /// 用户未通过身份验证
        /// </summary>
        public static string UserUnauthenticated = "10008";
        /// <summary>
        /// 请求未授权
        /// </summary>
        public static string RequestRejected = "10009";
        /// <summary>
        /// 授权错误
        /// </summary>
        public static string AuthorizationCheckFailed = "10009";
        /// <summary>
        /// Quota检测错误
        /// </summary>
        public static string QuotaCheckFailed = "10010";
        /// <summary>
        /// QPS检测错误
        /// </summary>
        public static string QPSCheckFailed = "10010";
        /// <summary>
        /// 
        /// </summary>
        public static string ConcurrentCheckFailed = "10010";

        #region IKB

        public static string DomainNotFound = "DomainNotFound";

        public static string IntentionNotFound = "IntentionNotFound";

        #endregion
    }
}