/*         
*│版权所有：Dream1993
*│创建人：Lee        
*/  
using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Fm.Entity{
	/// <summary>
    /// orderlist：实体类
    /// </summary>
	[Serializable]
	public class orderlist
	{   
      			private string _orderid;
		/// <summary>
		/// 订单编号
        /// </summary>
        public string OrderId
        {
            get{ return _orderid; }
            set{ _orderid = value; }
        }        
				private string _productid;
		/// <summary>
		/// 商品编号
        /// </summary>
        public string ProductId
        {
            get{ return _productid; }
            set{ _productid = value; }
        }        
				private string _productname;
		/// <summary>
		/// 商品名称
        /// </summary>
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
        }        
				private int _num;
		/// <summary>
		/// 商品数量
        /// </summary>
        public int Num
        {
            get{ return _num; }
            set{ _num = value; }
        }        
				private decimal _productprice;
		/// <summary>
		/// 商品单价
        /// </summary>
        public decimal ProductPrice
        {
            get{ return _productprice; }
            set{ _productprice = value; }
        }        
				private string _productimage;
		/// <summary>
		/// 商品图片
        /// </summary>
        public string ProductImage
        {
            get{ return _productimage; }
            set{ _productimage = value; }
        }        
		   
	}
}