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
    /// shop_cart：实体类
    /// </summary>
	[Serializable]
	public class shop_cart
	{   
      			private int _cartid;
		/// <summary>
		/// 记录号
        /// </summary>
        public int Cartid
        {
            get{ return _cartid; }
            set{ _cartid = value; }
        }        
				private string _userid;
		/// <summary>
		/// 用户编号
        /// </summary>
        public string UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
				private string _productid;
		/// <summary>
		/// 产品编号
        /// </summary>
        public string ProductId
        {
            get{ return _productid; }
            set{ _productid = value; }
        }        
				private int _cartnum;
		/// <summary>
		/// 购物车存放数量
        /// </summary>
        public int CartNum
        {
            get{ return _cartnum; }
            set{ _cartnum = value; }
        }        
		   
	}
}