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
    /// product_attr：实体类
    /// </summary>
	[Serializable]
	public class product_attr
	{   
      			private string _productid;
		/// <summary>
		/// 商品编号
        /// </summary>
        public string ProductId
        {
            get{ return _productid; }
            set{ _productid = value; }
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
				private string _attributevalue;
		/// <summary>
		/// 商品属性值
        /// </summary>
        public string AttributeValue
        {
            get{ return _attributevalue; }
            set{ _attributevalue = value; }
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