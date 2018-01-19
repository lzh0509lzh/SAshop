using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Entity
{
    public class WxEntity
    {
        /// <summary>
        /// 小程序ID	
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 商户号	
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 设备号	
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 商品描述	
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 商品详情	
        /// </summary>
        public string detail { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        public string attach { get; set; }
        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 标价币种
        /// </summary>
        public string fee_type { get; set; }
        /// <summary>
        /// 标价金额(分)
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 终端IP	
        /// </summary>
        public string spbill_create_ip { get; set; }
        /// <summary>
        /// 交易起始时间	
        /// </summary>
        public string time_start { get; set; }
        /// <summary>
        /// 交易结束时间	
        /// </summary>
        public string time_expire { get; set; }
        /// <summary>
        /// 订单优惠标记	
        /// </summary>
        public string goods_tag { get; set; }
        /// <summary>
        /// 通知地址	
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// 交易类型	
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 商品ID	
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// 指定支付方式	
        /// </summary>
        public string limit_pay { get; set; }
        /// <summary>
        /// 用户标识	
        /// </summary>
        public string openid { get; set; }

        
        public void set(string orderid,int Amount,string ip,string myurl,string useropenid)
        {
            appid = "wx7df8ffe170de0970";
            mch_id = "1495358012";
            device_info = "WEB";
            nonce_str = Fm.Core.wxUntil.GetRandStr(30);
            body = "七个果儿-水果";
            //detail = "";
            attach = "七个果儿-官方自营";
            out_trade_no = orderid;
            fee_type = "CNY";
            total_fee = Amount;
            spbill_create_ip = ip;
            time_start = DateTime.Now.ToString("yyyyMMddHHmmss");
            time_expire = DateTime.Now.AddHours(2).ToString("yyyyMMddHHmmss");
            notify_url = myurl;
            trade_type = "JSAPI";
            //product_id = "";
            openid = useropenid;
            
            var res = new Dictionary<string, string>
            {
                {"appId", appid},
                {"mch_id", mch_id},
                {"device_info", device_info},
                {"body", body},
                {"attach", attach},
                {"out_trade_no", out_trade_no},
                {"fee_type", fee_type},
                {"total_fee", total_fee.ToString()},
                {"spbill_create_ip", spbill_create_ip},
                {"time_start", time_start},
                {"time_expire", time_expire},
                {"notify_url", notify_url},
                {"trade_type", trade_type},
                {"openid", openid}
            };
            sign = Fm.Core.wxUntil.GetSignString(res);
        }

    }
}
