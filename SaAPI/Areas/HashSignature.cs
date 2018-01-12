using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SaAPI.Areas
{
    public class HashSignature
    {
        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="verb">请求方式</param>
        /// <param name="path">请求url路径</param>
        /// <param name="paramList">请求url参数数组,不包括signature, timestamp</param>
        /// <param name="headerList">请求x-msxiaoice前缀Header数组</param>
        /// <param name="requestContent">请求body</param>
        /// <param name="timestamp">Header中时间戳的数值,UTC时间1970年01月01日0:00:00到现在的秒数</param>
        /// <param name="secretKey">请求API开发者密码</param>
        /// <returns></returns>
        public static string ComputeSignature(string verb, string path, List<string> paramList, List<string> headerList, string requestContent, long timestamp, string secretKey)
        {
            //请求方式转为小写
            verb = verb.ToLower();
            //请求Url路径转为小写
            path = path.ToLower();
            //请求Url参数以字典序排序并以"&"连接
            paramList.Sort();
            var strParam = string.Join("&", paramList);
            //请求x-msxiaoice前缀Header转为小写,以字典序排序并以","连接
            for (int i = 0; i < headerList.Count; i++)
            {
                headerList[i] = headerList[i].ToLower();
            }
            headerList.Sort();
            var strHeader = string.Join(",", headerList);
            //请求时间转为字符串
            var strTimestamp = timestamp.ToString();
            // ";"连接所有输入拼接为长字符串
            var concatenatedContent =
            verb + ";" +
            path + ";" +
            strParam + ";" +
            strHeader + ";" +
            requestContent + ";" +
            strTimestamp + ";" +
            secretKey;
            //初始化HMACSHA1,输入开发者密码Byte数组
            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey)))
            {
                // HMACSHA1对象对消息数据Byte数组进行哈希计算
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(concatenatedContent));
                //将哈希结果转化为Base64作为签名
                var computedSignature = Convert.ToBase64String(computedHash);
                return computedSignature;
            }
        }

        private static bool VerifySignature(string verb, string path, IList<string> queryList, IList<string> headerList, byte[] requestBodyBytes, long timestamp, string secretKey, string signature)
        {
            var requestContent = Encoding.UTF8.GetString(requestBodyBytes);

            var concatenatedContent = verb + ";" +
                path + ";" +
                string.Join("&", queryList) + ";" +
                string.Join(",", headerList) + ";" +
                requestContent + ";" +
                timestamp + ";" +
                secretKey;

            var enc = Encoding.UTF8;
            using (var hmac = new HMACSHA1(enc.GetBytes(secretKey)))
            {
                var computedSignature = Convert.ToBase64String(hmac.ComputeHash(enc.GetBytes(concatenatedContent)));
                //Logger.InfoFormat("computed signature is {0}, the request signature is {1}", computedSignature, signature);

                return string.Equals(signature, computedSignature, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}