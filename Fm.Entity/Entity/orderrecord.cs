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
    /// orderrecord：实体类
    /// </summary>
	[Serializable]
	public class orderrecord
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
				private string _userid;
		/// <summary>
		/// 用户编号
        /// </summary>
        public string UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
				private string _username;
		/// <summary>
		/// 用户名
        /// </summary>
        public string UserName
        {
            get{ return _username; }
            set{ _username = value; }
        }        
				private string _pername;
		/// <summary>
		/// 收货人
        /// </summary>
        public string PerName
        {
            get{ return _pername; }
            set{ _pername = value; }
        }        
				private string _address;
		/// <summary>
		/// 收货地址
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }        
				private string _mobile;
		/// <summary>
		/// 手机号
        /// </summary>
        public string Mobile
        {
            get{ return _mobile; }
            set{ _mobile = value; }
        }        
				private int _stateid;
		/// <summary>
		/// 订单状态 （0未发货，1已发货，2待收货，3已收货，4删除）
        /// </summary>
        public int Stateid
        {
            get{ return _stateid; }
            set{ _stateid = value; }
        }        
				private decimal _postamount;
		/// <summary>
		/// 邮费
        /// </summary>
        public decimal PostAmount
        {
            get{ return _postamount; }
            set{ _postamount = value; }
        }        
				private decimal _amount;
		/// <summary>
		/// 订单总价
        /// </summary>
        public decimal Amount
        {
            get{ return _amount; }
            set{ _amount = value; }
        }        
				private string _createdate;
		/// <summary>
		/// 创建时间
        /// </summary>
        public string Createdate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
				private string _refreshdate;
		/// <summary>
		/// 更新时间
        /// </summary>
        public string RefreshDate
        {
            get{ return _refreshdate; }
            set{ _refreshdate = value; }
        }        
		   
	}
}