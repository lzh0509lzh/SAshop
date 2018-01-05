using System;
using System.Web;

namespace SaAPI
{
    public class HttpPreprocessModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            //// 下面是如何处理 LogRequest 事件并为其 
            //// 提供自定义日志记录实现的示例
            //context.LogRequest += new EventHandler(OnLogRequest);
            ////Asp.net处理的第一个事件，表示处理的开始
            //context.BeginRequest += context_BeginRequest;
            ////已经获取请求用户的信息
            //context.PostAuthenticateRequest += context_PostAuthenticateRequest;
            ////用户请求已经得到授权
            //context.PostAuthorizeRequest += context_PostAuthorizeRequest;
            ////获取以前处理缓存的处理结果，如果以前缓存过，那么，不必再进行请求的处理工作，直接返回缓存结果
            //context.ResolveRequestCache += context_ResolveRequestCache;
            ////已经完成缓存的获取操作
            //context.PostResolveRequestCache += context_PostResolveRequestCache;
            ////已经根据用户的请求，创建了处理请求的处理器对象
            //context.PostMapRequestHandler += context_PostMapRequestHandler;
            ////已经取得了Session
            //context.PostAcquireRequestState += context_PostAcquireRequestState;
            ////准备执行处理程序
            //context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
            ////已经执行了处理程序
            //context.PostRequestHandlerExecute += context_PostRequestHandlerExecute;
            ////释放请求的状态
            //context.ReleaseRequestState += context_ReleaseRequestState;
            ////更新缓存
            //context.UpdateRequestCache += context_UpdateRequestCache;
            ////已经更新了缓存
            //context.PostUpdateRequestCache += context_PostUpdateRequestCache;
            ////已经完成了请求的日志操作
            //context.PostLogRequest += context_PostLogRequest;
            ////本次请求处理完成
            //context.EndRequest += context_EndRequest;
            //context.PreSendRequestContent += context_PreSendRequestContent;
            //context.PreSendRequestHeaders += context_PreSendRequestHeaders;

            //context.RequestCompleted += context_RequestCompleted;
        }

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
        //    {
        //        HttpApplication app = source as HttpApplication;
        //        if (app != null)
        //        {
        //            HttpContext context = app.Context;
        //            HttpResponse response = app.Response;
        //            response.Write("自定义HttpModule中的LogRequest<br/>");
        //            return;
        //        }
        //    }


        public void Dispose()
            {
                //此处放置清除代码。
            }
        }
}
