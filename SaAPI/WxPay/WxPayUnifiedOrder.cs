using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;

namespace SaAPI.WxPay
{
    public class WxPayUnifiedOrder
    {
        public string UnifiedOrder(string appid,string openid,string product,Fm.Entity.WxEntity model)
        {
            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (var d in dic)
            {
                sb.Append("<" + d.Key + ">" + d.Value + "</" + d.Key + ">");
            }
            sb.Append("</xml>");

            var xml = new XmlDocument();
            //  xml.LoadXml(GetPostString("https://api.mch.weixin.qq.com/pay/unifiedorder", sb.ToString()));  
            CookieCollection coo = new CookieCollection();
            Encoding en = Encoding.GetEncoding("UTF-8");

            HttpWebResponse response = CreatePostHttpResponse("https://api.mch.weixin.qq.com/pay/unifiedorder", sb.ToString(), en);
            //打印返回值  
            Stream stream = response.GetResponseStream();   //获取响应的字符串流  
            StreamReader sr = new StreamReader(stream); //创建一个stream读取流  
            string html = sr.ReadToEnd();   //从头读到尾，放到字符串html  
                                            //Console.WriteLine(html);  
            xml.LoadXml(html);
            return "";
        }
        public static HttpWebResponse CreatePostHttpResponse(string url, string datas, Encoding charset)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //如果需要POST数据     
            //if (!(parameters == null || parameters.Count == 0))  
            //{  
            StringBuilder buffer = new StringBuilder();
            //int i = 0;  
            //foreach (string key in parameters.Keys)  
            //{  
            //    if (i > 0)  
            //    {  
            //        buffer.AppendFormat("&{0}={1}", key, parameters[key]);  
            //    }  
            //    else  
            //    {  
            //        buffer.AppendFormat("{0}={1}", key, parameters[key]);  
            //    }  
            //    i++;  
            //}  
            buffer.AppendFormat(datas);
            byte[] data = charset.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            //}  
            return request.GetResponse() as HttpWebResponse;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }
    }
}