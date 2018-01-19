using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Core
{
    public class wxUntil
    {
        /// <summary> 获取随机字符
        /// </summary>
        /// <param name="charNum">字符串包含字符个数</param>
        /// <returns></returns>
        public static string GetRandStr(int charNum)
        {
            System.Threading.Thread.Sleep(3);
            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            while (charNum > 0)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
                charNum--;
            }

            return result;
        }

        public static string GetSignString(Dictionary<string, string> dic)
        {
            //string key = System.Web.Configuration.WebConfigurationManager.AppSettings["key"].ToString();//商户平台 API安全里面设置的KEY  32位长度                                                                                                           
            string key = "424d1e645cd0ff76ee53c9a5b2662d78";
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);//排序 
            //连接字段  
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5  
            //sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToUpper();  
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            sign = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(sign))).Replace("-", null);
            return sign;
        }
    }
}
