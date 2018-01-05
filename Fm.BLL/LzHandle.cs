using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fm.Core;

namespace Fm.BLL
{
    public class LzHandle
    {

        public string GetProductinfo()
        {
            string strJson = "";
            Entity.DataResponse_ProductInfo Response = new Entity.DataResponse_ProductInfo();
            List<Fm.Entity.product_info> myList = new List<Fm.Entity.product_info>();
            BLL.product_info product_info_BLL = new product_info();
            try
            {
                myList = product_info_BLL.GetList("1");
                Response.List = myList;
                Response.Result = true;
                Response.Msg = "";
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
                Response.Result = false;
                Response.Msg = "数据异常！";
            }
            strJson = Newtonsoft.Json.JsonConvert.SerializeObject(Response);
            return strJson;
        }

    }
}
