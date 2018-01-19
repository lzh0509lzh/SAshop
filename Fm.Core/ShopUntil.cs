using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Core
{
    public class ShopUntil
    {
        /// <summary>
        /// 生成一个订单号
        /// </summary>
        /// <returns></returns>
        public static string GetOrderID()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位
            Random Seed = new Random();
            string RandomVaule = Seed.Next(1000, 9999).ToString();
            string OrderID = "s" + t.ToString() + RandomVaule;
            return OrderID;
        }
    }
}
