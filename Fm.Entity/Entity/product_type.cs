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
    /// product_type：实体类
    /// </summary>
	[Serializable]
	public class product_type
	{   
      			private int _typeid;
		/// <summary>
		/// 商品类型Id
        /// </summary>
        public int TypeId
        {
            get{ return _typeid; }
            set{ _typeid = value; }
        }        
				private string _typename;
		/// <summary>
		/// 商品类型名
        /// </summary>
        public string TypeName
        {
            get{ return _typename; }
            set{ _typename = value; }
        }        
				private string _typepic;
		/// <summary>
		/// 类型图片地址
        /// </summary>
        public string TypePic
        {
            get{ return _typepic; }
            set{ _typepic = value; }
        }        
				private int _fathertypeid;
		/// <summary>
		/// 父类型Id（无父类型默认为0）
        /// </summary>
        public int FatherTypeId
        {
            get{ return _fathertypeid; }
            set{ _fathertypeid = value; }
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
		/// 用户状态（默认为1）（0未启用，1启用，2首页展示）
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