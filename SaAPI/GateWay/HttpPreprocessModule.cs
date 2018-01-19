using SaAPI.Common;
using SaAPI.Context;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace SaAPI
{
    public class HttpPreprocessModule : IHttpModule
    {
        #region Demo
        //public void Init(HttpApplication context)
        //{
        //    // 下面是如何处理 LogRequest 事件并为其 
        //    // 提供自定义日志记录实现的示例
        //    context.LogRequest += new EventHandler(OnLogRequest);
        //    //Asp.net处理的第一个事件，表示处理的开始
        //    context.BeginRequest += context_BeginRequest;
        //    //已经获取请求用户的信息
        //    context.PostAuthenticateRequest += context_PostAuthenticateRequest;
        //    //用户请求已经得到授权
        //    context.PostAuthorizeRequest += context_PostAuthorizeRequest;
        //    //获取以前处理缓存的处理结果，如果以前缓存过，那么，不必再进行请求的处理工作，直接返回缓存结果
        //    context.ResolveRequestCache += context_ResolveRequestCache;
        //    //已经完成缓存的获取操作
        //    context.PostResolveRequestCache += context_PostResolveRequestCache;
        //    //已经根据用户的请求，创建了处理请求的处理器对象
        //    context.PostMapRequestHandler += context_PostMapRequestHandler;
        //    //已经取得了Session
        //    context.PostAcquireRequestState += context_PostAcquireRequestState;
        //    //准备执行处理程序
        //    context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        //    //已经执行了处理程序
        //    context.PostRequestHandlerExecute += context_PostRequestHandlerExecute;
        //    //释放请求的状态
        //    context.ReleaseRequestState += context_ReleaseRequestState;
        //    //更新缓存
        //    context.UpdateRequestCache += context_UpdateRequestCache;
        //    //已经更新了缓存
        //    context.PostUpdateRequestCache += context_PostUpdateRequestCache;
        //    //已经完成了请求的日志操作
        //    context.PostLogRequest += context_PostLogRequest;
        //    //本次请求处理完成
        //    context.EndRequest += context_EndRequest;
        //    context.PreSendRequestContent += context_PreSendRequestContent;
        //    context.PreSendRequestHeaders += context_PreSendRequestHeaders;

        //    context.RequestCompleted += context_RequestCompleted;
        //}

        //void context_UpdateRequestCache(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的UpdateRequestCache<br/>");
        //    }
        //}

        //void context_ResolveRequestCache(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的ResolveRequestCache<br/>");
        //    }
        //}

        //void context_RequestCompleted(object sender, EventArgs e)
        //{
        //    //HttpApplication app = sender as HttpApplication;
        //    //if (app != null)
        //    //{
        //    //    HttpContext context = app.Context;
        //    //    HttpResponse response = app.Response;
        //    //    response.Write("自定义HttpModule中的RequestCompleted<br/>");
        //    //}
        //}

        //void context_PreSendRequestHeaders(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PreSendRequestHeaders<br/>");
        //    }
        //}

        //void context_PreSendRequestContent(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PreSendRequestContent<br/>");
        //    }
        //}

        //void context_PreRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PreRequestHandlerExecute<br/>");
        //    }
        //}

        //void context_PostUpdateRequestCache(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostUpdateRequestCache<br/>");
        //    }
        //}

        //void context_PostResolveRequestCache(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostResolveRequestCache<br/>");
        //    }
        //}

        //void context_PostRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostRequestHandlerExecut<br/>");
        //    }
        //}

        //void context_PostMapRequestHandler(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostMapRequestHandler<br/>");
        //    }
        //}

        //void context_PostLogRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostLogRequest<br/>");
        //    }
        //}

        //void context_PostAuthorizeRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostAuthorizeRequest<br/>");
        //    }
        //}

        //void context_PostAuthenticateRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostAuthenticateRequest<br/>");
        //    }
        //}

        //void context_PostAcquireRequestState(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的PostAcquireRequestState<br/>");
        //    }
        //}

        //void context_ReleaseRequestState(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的ReleaseRequestState<br/>");
        //    }
        //}

        //void context_EndRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的EndRequest<br/>");
        //    }
        //}

        //void context_BeginRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = sender as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("Out!!!!!!!!!<br/>");
        //    }
        //}

        //public void OnLogRequest(Object source, EventArgs e)
        //{
        //    HttpApplication app = source as HttpApplication;
        //    if (app != null)
        //    {
        //        HttpContext context = app.Context;
        //        HttpResponse response = app.Response;
        //        response.Write("自定义HttpModule中的LogRequest<br/>");
        //        return;
        //    }
        //}
        #endregion

        public void Init(HttpApplication context)
        {
            var asyncHelper = new EventHandlerTaskAsyncHelper(context_OnBeginRequestAsync);
            context.AddOnBeginRequestAsync(asyncHelper.BeginEventHandler, asyncHelper.EndEventHandler);

            asyncHelper = new EventHandlerTaskAsyncHelper(context_OnAuthenticateRequestAsync);
            context.AddOnAuthenticateRequestAsync(asyncHelper.BeginEventHandler, asyncHelper.EndEventHandler);

            //asyncHelper = new EventHandlerTaskAsyncHelper(context_OnPostAuthorizationRequestAsync);
            //context.AddOnPostAuthorizeRequestAsync(asyncHelper.BeginEventHandler, asyncHelper.EndEventHandler);

            asyncHelper = new EventHandlerTaskAsyncHelper(context_OnEndRequestAsync);
            context.AddOnEndRequestAsync(asyncHelper.BeginEventHandler, asyncHelper.EndEventHandler);

        }

        private static async Task context_OnBeginRequestAsync(object sender, EventArgs e)
        {

            var app = sender as HttpApplication;
            if (app == null)
            {
                return;
            }

            //HttpApplication中添加 开始时间Items
            app.Context.Items.Add("StartRequestTime", DateTime.Now);

            #region 创建traceId
            var traceId = Guid.NewGuid().ToString().Replace("-", "");
            app.Context.Items.Add("TraceId", traceId);
            #endregion

            #region 白名单
            //if (app.Context.Request.Headers.AllKeys.Contains(HttpHeaderKey.AppId))
            //{
            //    var RequestAppId = app.Context.Request.Headers[HttpHeaderKey.AppId];
            //    if (AppIDWhilteList.Any(v => string.Equals(v, RequestAppId, StringComparison.InvariantCultureIgnoreCase)))
            //    {
            //        traceId = "GGGGGGGG-GGGG-GGGG-GGGG-GGGGGGGGGGGG";
            //    }
            //}
            #endregion

            //var mockTraceableObj = new MockTraceableObj
            //{
            //    TraceId = traceId,
            //    Source = PartnerNameEx.SAIPartnerID.ToString("D")
            //};
            //mockTraceableObj.ContinueOrStartTracing();
            //CallContext.LogicalSetData("TraceId", traceId);

            #region Url校验
            //if (app.Context.Request.Url.PathAndQuery.Equals("/533b7a9e/Monitor/keepalive"))
            //{
            //    var response = app.Context.Response;
            //    response.TrySkipIisCustomErrors = true;

            //    // Ensure that any content written to the response stream is erased.
            //    response.Clear();
            //    response.ClearContent();

            //    response.StatusCode = 200;
            //    app.Context.ApplicationInstance.CompleteRequest();
            //    return;
            //}

            //Logger.InfoFormat("Receive request {0} {1}", app.Context.Request.HttpMethod, app.Context.Request.Url);
            #endregion

            #region 创建RequestContext对象
            DateTime startTime = DateTime.Now;
            var requestContext = await BuildRequestContextAsync(app.Context, traceId);
            DateTime stopTime = DateTime.Now;
            TimeSpan elapsedTime = stopTime - startTime;

            //Logger.Info("BuildRequestContextAsync elapsedTime: " + elapsedTime);
            //TODO: create event log here
            //Logger.InfoFormat("Request context: verb={0}, url={1}, client ip={2}, ActivityId={3}",
            //    requestContext.HttpVerb,
            //    requestContext.Uri,
            //    requestContext.ClientIpAddress,
            //    requestContext.TraceId);

            #region 添加响应Headers
            app.Context.Response.Headers.Add(HttpHeaderKey.TraceId, requestContext.TraceId);
            #endregion

            #region 初始化resourcePath
            ResourcePath resourcePath = new ResourcePath(app.Context.Request.Url);
            requestContext.ResourcePath = resourcePath;
            #endregion

            #endregion

            #region 恶意请求过滤
            //RemoveMaliciousRequestHttpHeader(app.Context.Request);

            //Logger.Info("Start BlockByIpAddress……");
            //if (ServiceContext.Instance.FirewallManager.BlockByIpAddress(resourcePath, app.Context.Request.UserHostAddress))
            //{
            //    //Logger.ErrorFormat("The IP {0} is blocked for URL {1}", app.Context.Request.UserHostAddress, app.Context.Request.Url);
            //    throw new FrontendHttpException(
            //        errorCode: ErrorCode.RequestRejected,
            //        httpStatusCode: HttpStatusCode.Forbidden,
            //        message: ErrorMessage.RequestRejected);
            //}

            //Logger.Info("Start TrafficControlByIP……");
            //ServiceContext.Instance.FirewallManager.TrafficControlByIP(app.Context.Request.UserHostAddress);

            //Logger.Info("Start BotDetect……");
            //if (ServiceContext.Instance.FirewallManager.BotDetect(app.Context.Request))
            //{
            //    Logger.ErrorFormat("The request agent {0} is detected as bot.", app.Context.Request.UserAgent);
            //    throw new FrontendHttpException(
            //        errorCode: ErrorCode.RequestRejected,
            //        httpStatusCode: HttpStatusCode.Forbidden,
            //        message: ErrorMessage.RequestRejected);
            //}

            //Logger.Info("End BeginRequest……");
            #endregion
        }

        /// <summary>
        /// 使安全模块对请求进行身份验证
        /// </summary>
        private async static Task context_OnAuthenticateRequestAsync(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app != null)
            {
                DateTime startTime = DateTime.Now;
                await ServiceContext.Instance.AuthenticateManager.AuthenticateAsync(RequestContext.Get(app.Context));
                DateTime stopTime = DateTime.Now;
                TimeSpan elapsedTime = stopTime - startTime;
                //Logger.Info("AuthenticateAsync elapsedTime: " + elapsedTime);
            }
        }

        private static async Task context_OnPostAuthorizationRequestAsync(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app == null)
            {
                return;
            }
            DateTime startTime = DateTime.Now;
            //方法体
            DateTime stopTime = DateTime.Now;
            TimeSpan elapsedTime = stopTime - startTime;
        }

        private static async Task context_OnEndRequestAsync(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app == null)
            {
                return;
            }

        }
        public void Dispose()
        {
            //此处放置清除代码。
        }

        /// <summary>
        /// RequestContext 构建
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="traceId"></param>
        /// <returns></returns>
        private static async Task<RequestContext> BuildRequestContextAsync(HttpContext httpContext, string traceId)
        {
            var requestContext = new RequestContext
            {
                Uri = httpContext.Request.Url,
                HttpVerb = HttpUtils.GetVerb(httpContext),
                Headers = httpContext.Request.Headers,
                ContentLength = httpContext.Request.InputStream.Length,
                Cookies = httpContext.Request.Cookies,
                TraceId = traceId,
                ClientIpAddress = httpContext.Request.UserHostAddress
            };

            // offload the request stream
            using (var ms = new MemoryStream())
            {
                DateTime startTime = DateTime.Now;
                await httpContext.Request.InputStream.CopyToAsync(ms);
                DateTime stopTime = DateTime.Now;
                TimeSpan elapsedTime = stopTime - startTime;
                //Logger.Info("InputStream.CopyToAsync elapsedTime: " + elapsedTime);
                requestContext.RequestContent = ms.ToArray();
                string str = System.Text.Encoding.Default.GetString(ms.ToArray());
            }

            if (httpContext.Request.Headers.AllKeys.Contains(HttpHeaderKey.AppId))
            {
                requestContext.RequestAppId = httpContext.Request.Headers[HttpHeaderKey.AppId];
            }

            if (httpContext.Request.Headers.AllKeys.Contains(HttpHeaderKey.UserId))
            {
                requestContext.RequestUserId = httpContext.Request.Headers[HttpHeaderKey.UserId];
            }

            if (httpContext.Request.Headers.AllKeys.Contains(HttpHeaderKey.Signature))
            {
                requestContext.RequestSignature = httpContext.Request.Headers[HttpHeaderKey.Signature];
            }

            if (httpContext.Request.Headers.AllKeys.Contains(HttpHeaderKey.Timestamp))
            {
                long timestamp = 0;
                if (long.TryParse(httpContext.Request.Headers[HttpHeaderKey.Timestamp], out timestamp))
                {
                    requestContext.RequestTimestamp = timestamp;
                }
            }

            requestContext.Set(httpContext);

            return requestContext;
        }

        /// <summary>
        /// 移除恶意请求
        /// </summary>
        /// <param name="request"></param>
        private static void RemoveMaliciousRequestHttpHeader(HttpRequest request)
        {
            //if (HttpHeaderFilterConfig.Get().Enabled)
            //{
            //    foreach (var key in request.Headers.AllKeys)
            //    {
            //        if (!HttpHeaderFilterConfig.Get().RequestHeaderWhitelist
            //            .Any(s => string.Equals(s.Header, key, StringComparison.InvariantCultureIgnoreCase)))
            //        {
            //            request.Headers.Remove(key);
            //            Logger.InfoFormat("Request header has been removed. Header=[{0}:{1}]", key, request.Headers[key]);
            //        }
            //    }
            //}
        }

        
    }
}
