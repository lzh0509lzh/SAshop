using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Core
{
    public class GetTimeID
    {
        /// <summary>
        /// 产生用户编号
        /// </summary>
        /// <returns></returns>
        public static string MakeUserid()
        {
            return Makeid("u");
        }

        /// <summary>
        /// 生成13位时间戳
        /// </summary>
        /// <returns></returns>
        public static string Makeid(string type)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (DateTime.UtcNow.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位  
            string ret = type + t.ToString();
            return ret;
        }

        /// <summary>
        /// 生成10位时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        /// <summary>
        /// 取随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomStr(int length)
        {
            Random rand = new Random();

            int num = rand.Next();

            string str = num.ToString();

            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            else if (str.Length < length)
            {
                int n = length - str.Length;
                while (n > 0)
                {
                    str.Insert(0, "0");
                    n--;
                }
            }
            return str;
        }

    }
}
