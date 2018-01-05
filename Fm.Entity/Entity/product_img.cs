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
    /// product_img：实体类
    /// </summary>
	[Serializable]
	public class product_img
	{   
      			private string _productid;
		/// <summary>
		/// ProductId
        /// </summary>
        public string ProductId
        {
            get{ return _productid; }
            set{ _productid = value; }
        }        
				private string _photourl;
		/// <summary>
		/// PhotoUrl
        /// </summary>
        public string PhotoUrl
        {
            get{ return _photourl; }
            set{ _photourl = value; }
        }        
		   
	}
}