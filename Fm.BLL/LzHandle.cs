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
        #region 商品相关
        /// <summary>
        /// 展示商品类型
        /// </summary>
        /// <returns></returns>
        public string GetProductType()
        {
            string strJson = "";
            Entity.DataResponse_product_type Response = new Entity.DataResponse_product_type();
            BLL.product_type product_type_BLL = new product_type();
            try
            {
                Response.List = product_type_BLL.GetTypeList();
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

        /// <summary>
        /// 展示商品相关列表
        /// </summary>
        /// <param name="stateid">1全部，2首页</param>
        /// <returns></returns>
        public string GetProductList(int stateid)
        {
            string strJson = "";
            Entity.DataResponse_ProductInfo Response = new Entity.DataResponse_ProductInfo();
            BLL.product_info product_info_BLL = new product_info();
            try
            {
                Response.List = product_info_BLL.GetList(stateid);
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

        /// <summary>
        /// 根据类型展示商品列表
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public string GetProductListByTypeId(string TypeId)
        {
            string strJson = "";
            Entity.DataResponse_ProductInfo Response = new Entity.DataResponse_ProductInfo();
            BLL.product_info product_info_BLL = new product_info();
            try
            {
                Response.List = product_info_BLL.GetListByTypeId(TypeId);
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
        #endregion

        #region 订单相关

        /// <summary>
        /// 根据用户编号查询用户订单列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetListByUserId(string UserId)
        {
            string strJson = "";
            Entity.DataResponse_Orderrecord Response = new Entity.DataResponse_Orderrecord();
            BLL.orderrecord orderrecord_BLL = new orderrecord();

            try
            {
                Response.List = orderrecord_BLL.GetListByUserId(UserId);
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

        /// <summary>
        /// 根据订单编号查询订单详情
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public string GetDetailByOrderId(string OrderId)
        {
            string strJson = "";
            Entity.DataResponse_OrderDetail Response = new Entity.DataResponse_OrderDetail();
            BLL.orderlist orderlist_BLL = new orderlist();

            try
            {
                Response.List = orderlist_BLL.GetDetailByOrderId(OrderId);
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

        /// <summary>
        /// 改变订单状态
        /// </summary>
        /// <param name="OrderId">条件</param>
        /// <param name="Stateid">值</param>
        /// <returns></returns>
        public string UpdateStateid(string OrderId, string Stateid)
        {
            string strJson = "";
            Entity.BaseDataResponse Response = new Entity.BaseDataResponse();
            BLL.orderrecord orderrecord_BLL = new BLL.orderrecord();

            try
            {
                orderrecord_BLL.UpdateStateid(OrderId,Stateid);
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
        #endregion

        #region 购物车相关
        /// <summary>
        /// 展示用户购物车列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetListByUserid(string UserId)
        {
            string strJson = "";
            Entity.DataResponse_shop_cart Response = new Entity.DataResponse_shop_cart();
            BLL.shop_cart shop_cart_BLL = new shop_cart();

            try
            {
                Response.List = shop_cart_BLL.GetListByUserid(UserId);
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
        /// <summary>
        /// 编辑购物车
        /// </summary>
        /// <param name="Cartid"></param>
        /// <param name="CartNum"></param>
        /// <returns></returns>
        public string UpdateCartNum(string Cartid, int CartNum)
        {
            string strJson = "";
            Entity.BaseDataResponse Response = new Entity.BaseDataResponse();
            BLL.shop_cart shop_cart_BLL = new shop_cart();

            try
            {
                if (CartNum == 0)
                {
                    shop_cart_BLL.DeleteByCartid(Cartid);
                }
                else
                {
                    shop_cart_BLL.UpdateCartNum(Cartid, CartNum);
                }
                
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
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="MJson"></param>
        /// <returns></returns>
        public string AddCart(string MJson)
        {
            string strJson = "";
            Entity.BaseDataResponse Response = new Entity.BaseDataResponse();
            BLL.shop_cart shop_cart_BLL = new shop_cart();

            try
            {
                Entity.shop_cart model = Newtonsoft.Json.JsonConvert.DeserializeObject<Entity.shop_cart>(MJson);
                shop_cart_BLL.Add(model);
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
        #endregion

        #region 收货地址相关
        /// <summary>
        /// 展示用户收货地址
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetAddressListByUserid(string UserId)
        {
            string strJson = "";
            Entity.DataResponse_useraddress Response = new Entity.DataResponse_useraddress();
            BLL.useraddress useraddress_BLL = new useraddress();

            try
            {
                Response.List = useraddress_BLL.GetAddressListByUserid(UserId);
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
        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="MJson"></param>
        /// <returns></returns>
        public string UpdateAll(string MJson)
        {
            string strJson = "";
            Entity.BaseDataResponse Response = new Entity.BaseDataResponse();
            BLL.useraddress useraddress_BLL = new useraddress();

            try
            {
                Entity.useraddress model = Newtonsoft.Json.JsonConvert.DeserializeObject<Entity.useraddress>(MJson);
                useraddress_BLL.UpdateAll(model.AddressID.ToString(), model.PerMobile, model.PerName, model.Address, model.StateId.ToString());
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
        #endregion
    }
}
