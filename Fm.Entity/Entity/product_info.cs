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
    /// product_info：实体类
    /// </summary>
	[Serializable]
	public class product_info
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
				private string _productname;
		/// <summary>
		/// 商品名称
        /// </summary>
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
        }        
				private decimal _productprice;
		/// <summary>
		/// 标价
        /// </summary>
        public decimal ProductPrice
        {
            get{ return _productprice; }
            set{ _productprice = value; }
        }        
				private string _mainimgurl;
		/// <summary>
		/// 商品图片
        /// </summary>
        public string MainImgUrl
        {
            get{ return _mainimgurl; }
            set{ _mainimgurl = value; }
        }        
				private int _storenum;
		/// <summary>
		/// 商品库存
        /// </summary>
        public int StoreNum
        {
            get{ return _storenum; }
            set{ _storenum = value; }
        }        
				private int _salesnum;
		/// <summary>
		/// 商品销量
        /// </summary>
        public int SalesNum
        {
            get{ return _salesnum; }
            set{ _salesnum = value; }
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
				private string _specifications;
		/// <summary>
		/// 商品规格  
        /// </summary>
        public string Specifications
        {
            get{ return _specifications; }
            set{ _specifications = value; }
        }        
				private decimal _productweight;
		/// <summary>
		/// 商品单位重量(kg）
        /// </summary>
        public decimal ProductWeight
        {
            get{ return _productweight; }
            set{ _productweight = value; }
        }        
				private string _productdetail;
		/// <summary>
		/// 商品描述
        /// </summary>
        public string ProductDetail
        {
            get{ return _productdetail; }
            set{ _productdetail = value; }
        }        
				private string _madefactor;
		/// <summary>
		/// 所属公司
        /// </summary>
        public string MadeFactor
        {
            get{ return _madefactor; }
            set{ _madefactor = value; }
        }        
				private string _madehome;
		/// <summary>
		/// 商品产地
        /// </summary>
        public string MadeHome
        {
            get{ return _madehome; }
            set{ _madehome = value; }
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