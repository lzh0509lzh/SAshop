using SaAPI.Common;
using SaAPI.Context;
using SaAPI.Utility.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SaAPI.Models
{
    public class AuthenticateManager : IAuthenticateManager
    {
        public async Task AuthenticateAsync(RequestContext context)
        {
            bool isVerified = false;
            try
            {
                var verb = context.HttpVerb.ToString().ToLowerInvariant();
                var path = context.ResourcePath.Path.ToLowerInvariant();
                var queryList = context.ResourcePath.QueryList;
                var headerList = new List<string>
                    {
                    (HttpHeaderKey.AppId + ":" + context.RequestAppId).ToLowerInvariant(),
                    (HttpHeaderKey.UserId + ":" + context.RequestUserId).ToLowerInvariant()
                    }.OrderBy(x => x).ToList();
                var requestBodyBytes = context.RequestContent;
                var timestamp = context.RequestTimestamp;
                var secret = "4f64e672-6460-4711-891c-cc9fad5925cb";
                var signature = context.RequestSignature;

                isVerified = VerifySignature(verb, path, queryList, headerList, requestBodyBytes, timestamp, secret, signature);
            }
            catch (Exception ex)
            {
                string Msg = ex.ToString();
            }

            if (isVerified)
            {
                return;
            }
            else
            {
                //Logger.InfoFormat("The signature verification failed.");
                throw new FrontendHttpException(
                    errorCode: ErrorCode.UserUnauthenticated,
                    httpStatusCode: HttpStatusCode.Unauthorized,
                    message: ErrorMessage.UnauthenticatedWithInvalidSignature);
            }
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="path"></param>
        /// <param name="queryList"></param>
        /// <param name="headerList"></param>
        /// <param name="requestBodyBytes"></param>
        /// <param name="timestamp"></param>
        /// <param name="secret"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        private static bool VerifySignature(string verb, string path, IList<string> queryList, IList<string> headerList, byte[] requestBodyBytes, long timestamp, string secret, string signature)
        {
            var requestContent = Encoding.UTF8.GetString(requestBodyBytes);

            var concatenatedContent = verb + ";" +
                path + ";" +
                (queryList == null ? "" : string.Join("&", queryList)) + ";" +
                string.Join(",", headerList) + ";" +
                requestContent + ";" +
                timestamp + ";" +
                secret;

            var enc = Encoding.UTF8;
            using (var hmac = new HMACSHA1(enc.GetBytes(secret)))
            {
                var computedSignature = Convert.ToBase64String(hmac.ComputeHash(enc.GetBytes(concatenatedContent)));
                //Logger.InfoFormat("computed signature is {0}, the request signature is {1}", computedSignature, signature);

                return string.Equals(signature, computedSignature, StringComparison.OrdinalIgnoreCase);
            }
        }

    }
}