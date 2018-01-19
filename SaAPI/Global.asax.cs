using SaAPI.Context;
using SaAPI.Models;
using SaAPI.Utility.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SaAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ServiceContext.Instance.AuthenticateManager = new AuthenticateManager();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app == null)
            {
                return;
            }

            HttpErrorResponse httpError = null;
            try
            {
                var exception = app.Server.GetLastError();
                //Logger.ErrorFormat("Caught unhandled exception in http module: {0}.", exception);
                httpError = ErrorMessageHandler.CreateResponseFromException(exception);
            }
            catch (Exception ex)
            {
                //Logger.ErrorFormat("Error occurred when handling exception: {0}", ex);
                httpError = new HttpErrorResponse
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ErrorOutput = new ErrorResponse(new Error
                    {
                        Code = ErrorCode.InternalServerError,
                        Message = ErrorMessage.InternalServerError
                    })
                };
            }

            var response = app.Context.Response;
            response.TrySkipIisCustomErrors = true;

            // Ensure ASP.NET not to show 'Yellow Screen of Death'.
            app.Server.ClearError();

            #region 创建返回类

            // Ensure that any content written to the response stream is erased.
            response.Clear();
            response.ClearContent();            
            
            response.StatusCode = (int)httpError.HttpStatusCode;
            response.ContentType = "application/json; charset=utf-8";

            if (httpError.Headers != null)
            {
                foreach (var key in httpError.Headers.AllKeys)
                {
                    response.AddHeader(key, httpError.Headers.Get(key));
                }
            }
            #endregion

            string responseString = httpError.ErrorOutput.ToJsonDefault();
            response.Output.Write(responseString);

            response.Flush();

            app.Context.ApplicationInstance.CompleteRequest();
        }
    }
}
