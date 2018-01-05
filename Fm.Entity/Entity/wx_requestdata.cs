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
    /// wx_requestdata：实体类
    /// </summary>
	[Serializable]
	public class wx_requestdata
	{   
      			private int _id;
		/// <summary>
		/// 序列号
        /// </summary>
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
				private string _datakey;
		/// <summary>
		/// 数据名
        /// </summary>
        public string DataKey
        {
            get{ return _datakey; }
            set{ _datakey = value; }
        }        
				private string _datavalue;
		/// <summary>
		/// 数据值
        /// </summary>
        public string DataValue
        {
            get{ return _datavalue; }
            set{ _datavalue = value; }
        }        
				private string _expires_in;
		/// <summary>
		/// 有效时间/秒
        /// </summary>
        public string expires_in
        {
            get{ return _expires_in; }
            set{ _expires_in = value; }
        }        
				private string _refreshtime;
		/// <summary>
		/// 有效时间/秒
        /// </summary>
        public string RefreshTime
        {
            get{ return _refreshtime; }
            set{ _refreshtime = value; }
        }        
		   
	}
}