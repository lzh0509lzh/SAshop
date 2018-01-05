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
    /// useraddress：实体类
    /// </summary>
	[Serializable]
	public class useraddress
	{   
      			private int _addressid;
		/// <summary>
		/// 地址编号
        /// </summary>
        public int AddressID
        {
            get{ return _addressid; }
            set{ _addressid = value; }
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
				private string _permobile;
		/// <summary>
		/// 收货人手机号
        /// </summary>
        public string PerMobile
        {
            get{ return _permobile; }
            set{ _permobile = value; }
        }        
				private string _pername;
		/// <summary>
		/// 收货人姓名
        /// </summary>
        public string PerName
        {
            get{ return _pername; }
            set{ _pername = value; }
        }        
				private string _address;
		/// <summary>
		/// 收货人地址
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }        
				private int _stateid;
		/// <summary>
		/// 地址状态（1普通，2默认）
        /// </summary>
        public int StateId
        {
            get{ return _stateid; }
            set{ _stateid = value; }
        }        
				private string _createdate;
		/// <summary>
		/// 创建时间
        /// </summary>
        public string CreateDate
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