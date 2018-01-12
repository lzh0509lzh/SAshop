using SaAPI.Common;
using SaAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
            bool isVerified = VerifySignature(
                verb: context.HttpVerb.ToString().ToLowerInvariant(),
                path: context.ResourcePath.Path.ToLowerInvariant(),
                queryList: context.ResourcePath.QueryList,
                headerList: new List<string>
                {
                    (HttpHeaderKey.AppId + ":" + context.RequestAppId).ToLowerInvariant(),
                    (HttpHeaderKey.UserId + ":" + context.RequestUserId).ToLowerInvariant()
                }.OrderBy(x => x).ToList(),
                requestBodyBytes: context.RequestContent,
                timestamp: context.RequestTimestamp,
                secret: "4f64e672-6460-4711-891c-cc9fad5925cb",
                signature: context.RequestSignature);

            if (isVerified)
                return;
        }

        private static bool VerifySignature(string verb, string path, IList<string> queryList, IList<string> headerList, byte[] requestBodyBytes, long timestamp, string secret, string signature)
        {
            var requestContent = Encoding.UTF8.GetString(requestBodyBytes);

            var concatenatedContent = verb + ";" +
                path + ";" +
                string.Join("&", queryList) + ";" +
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