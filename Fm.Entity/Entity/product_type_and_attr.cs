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
    /// product_type_and_attr：实体类
    /// </summary>
	[Serializable]
	public class product_type_and_attr
	{   
      			private int _attrtid;
		/// <summary>
		/// AttrTId
        /// </summary>
        public int AttrTId
        {
            get{ return _attrtid; }
            set{ _attrtid = value; }
        }        
				private int _typeid;
		/// <summary>
		/// 商品类型Id
        /// </summary>
        public int TypeId
        {
            get{ return _typeid; }
            set{ _typeid = value; }
        }        
				private string _attributename;
		/// <summary>
		/// 商品属性名
        /// </summary>
        public string AttributeName
        {
            get{ return _attributename; }
            set{ _attributename = value; }
        }        
				private string _operator;
		/// <summary>
		/// 操作人（默认为Admin）
        /// </summary>
        public string Operator
        {
            get{ return _operator; }
            set{ _operator = value; }
        }        
				private int _stateid;
		/// <summary>
		/// 用户状态（默认为1）
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