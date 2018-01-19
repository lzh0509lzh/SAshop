using Fm.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace SaAPI.Controllers
{
    public class ValuesController : ApiController
    {  

        #region 商品相关
        /// <summary>
        /// 获取商品类型列表
        /// </summary>
        /// <returns>
        ///{
        ///    "List": [
        ///        {
        ///            "TypeId": 1,         类型编号
        ///            "TypeName": "苹果",   商品类型名
        ///            "TypePic": 1         类型图片地址
        ///            "FatherTypeId":0     父类型Id（无父类型默认为0）
        ///        }
        ///    ],
        ///    "Result": true,
        ///    "Msg": ""
        ///}
        /// </returns>
        [HttpPost]
        [Route("SevenApple/GetProductType")]
        public IHttpActionResult GetProductType()
        {
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetProductType();
            return Ok(strJson);
        }
        /// <summary>
        /// 展示商品列表
        /// </summary>
        /// <param name="stateid">1全部，2首页</param>
        /// <returns>
        /// {
        ///     "list":[
        ///         {
        ///             "productid":""          商品编号
        ///             "productname":""        商品名称
        ///             "productprice":19.9     标价
        ///             "mainimgurl":""         商品图片
        ///             "storenum":10           商品库存
        ///             "salesnum":5            商品销量
        ///             "typeid":123            商品类型id
        ///             "specifications":""     商品规格
        ///             "productweight":""      商品单位重量(kg）
        ///             "productdetail":""      商品描述
        ///             "madefactor":""         所属公司
        ///             "madehome":""           商品产地
        ///             "operator":""           操作人（默认为admin）
        ///             "stateid":1             用户状态（默认为1）
        ///             "createdate":""         创建时间
        ///             "refreshdate":""        更新时间
        ///         }
        ///     ]
        /// }
        /// </returns>
        [HttpPost]
        [Route("SevenApple/GetProductList")]
        public IHttpActionResult GetProductList()
        {
            int stateid =Convert.ToInt32(HttpContext.Current.Request.Form["TypeId"]);
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetProductList(stateid);
            return Ok(strJson);
        }

        /// <summary>
        /// 根据类型查询商品列表
        /// </summary>
        /// <returns>
        /// {
        ///     "List":[
        ///         {
        ///             "ProductId":""          商品编号
        ///             "ProductName":""        商品名称
        ///             "ProductPrice":19.9     标价
        ///             "MainImgUrl":""         商品图片
        ///             "StoreNum":10           商品库存
        ///             "SalesNum":5            商品销量
        ///             "TypeId":123            商品类型Id
        ///             "Specifications":""     商品规格
        ///             "ProductWeight":""      商品单位重量(kg）
        ///             "ProductDetail":""      商品描述
        ///             "MadeFactor":""         所属公司
        ///             "MadeHome":""           商品产地
        ///             "Operator":""           操作人（默认为Admin）
        ///             "StateId":1             用户状态（默认为1）
        ///             "CreateDate":""         创建时间
        ///             "RefreshDate":""        更新时间
        ///         }
        ///     ]
        /// }
        /// </returns>
        [HttpPost]
        [Route("SevenApple/GetProductListByTypeId")]
        public IHttpActionResult GetProductListByTypeId()
        {
            HttpRequest MyRequest = HttpContext.Current.Request;
            var TypeId = MyRequest.Form["TypeId"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetProductListByTypeId(TypeId);
            return Ok(strJson);
        }
        #endregion

        #region 订单相关
        /// <summary>
        /// 查询用户订单列表
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/GetOrderListByUserId")]
        public IHttpActionResult GetOrderListByUserId()
        {
            string UserId=HttpContext.Current.Request.Form["UserId"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetListByUserId(UserId);
            return Ok(strJson);
        }

        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/GetDetailByOrderId")]
        public IHttpActionResult GetDetailByOrderId()
        {
            string OrderId = HttpContext.Current.Request.Form["OrderId"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetDetailByOrderId(OrderId);
            return Ok(strJson);
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="Stateid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/UpdateStateid")]
        public IHttpActionResult UpdateStateid()
        {
            string OrderId = HttpContext.Current.Request.Form["OrderId"];
            string Stateid = HttpContext.Current.Request.Form["Stateid"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.UpdateStateid(OrderId, Stateid);
            return Ok(strJson);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult CreateOrder()
        {
            string qJson = HttpContext.Current.Request.Form["strJson"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.CreateOrder(qJson);
            return Ok(strJson);
        }
        #endregion

        #region 购物车相关
        /// <summary>
        /// 获取用户购物车列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/GetCartListByUserid")]
        public IHttpActionResult GetCartListByUserid()
        {
            string UserId = HttpContext.Current.Request.Form["UserId"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetListByUserid(UserId);
            return Ok(strJson);
        }

        /// <summary>
        /// 修改购物车
        /// </summary>
        /// <param name="Cartid"></param>
        /// <param name="CartNum"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/UpdateCartNum")]
        public IHttpActionResult UpdateCartNum()
        {
            string Cartid = HttpContext.Current.Request.Form["Cartid"];
            int CartNum =Convert.ToInt32(HttpContext.Current.Request.Form["CartNum"]);
            LzHandle Handle = new LzHandle();
            string strJson = Handle.UpdateCartNum(Cartid, CartNum);
            return Ok(strJson);
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="MJson"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/AddCart")]
        public IHttpActionResult AddCart()
        {
            string MJson = HttpContext.Current.Request.Form["MJson"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.AddCart(MJson);
            return Ok(strJson);
        }
        #endregion

        #region 收货地址相关
        /// <summary>
        /// 获取用户收货地址
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/GetAddressListByUserid")]
        public IHttpActionResult GetAddressListByUserid()
        {
            string UserId = HttpContext.Current.Request.Form["UserId"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetAddressListByUserid(UserId);
            return Ok(strJson);
        }

        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="MJson"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SevenApple/UpdateAll")]
        public IHttpActionResult UpdateAll()
        {
            string MJson = HttpContext.Current.Request.Form["MJson"];
            LzHandle Handle = new LzHandle();
            string strJson = Handle.UpdateAll(MJson);
            return Ok(strJson);
        }

        #endregion
    }
}
