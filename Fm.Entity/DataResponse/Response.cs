using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Entity
{
    #region 商品基本信息
    [Serializable]
    public class DataResponse_ProductInfo : BaseDataResponse
    {
        public List<Fm.Entity.product_info> List { get; set; }
    }
    #endregion

    #region 订单详情
    [Serializable]
    public class DataResponse_OrderDetail : BaseDataResponse
    {
        public List<Fm.Entity.orderlist> List { get; set; }
    }
    #endregion

    #region 订单记录
    [Serializable]
    public class DataResponse_Orderrecord : BaseDataResponse
    {
        public List<Fm.Entity.orderrecord> List { get; set; }
    }
    #endregion

    #region 购物车
    [Serializable]
    public class DataResponse_shop_cart : BaseDataResponse
    {
        public List<Fm.Entity.shop_cart> List { get; set; }
    }
    #endregion

    #region 收货地址
    [Serializable]
    public class DataResponse_useraddress : BaseDataResponse
    {
        public List<Fm.Entity.useraddress> List { get; set; }
    }
    #endregion

    #region 商品类型
    [Serializable]
    public class DataResponse_product_type : BaseDataResponse
    {
        public List<Fm.Entity.product_type> List { get; set; }
    }
    #endregion
}
