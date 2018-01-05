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
    /// userinfo：实体类
    /// </summary>
	[Serializable]
	public class userinfo
	{   
      			private string _userid;
		/// <summary>
		/// 用户ID
        /// </summary>
        public string UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
				private string _openid;
		/// <summary>
		/// 微信用户的唯一标识
        /// </summary>
        public string Openid
        {
            get{ return _openid; }
            set{ _openid = value; }
        }        
				private string _headimgurl;
		/// <summary>
		/// 用户头像
        /// </summary>
        public string headimgurl
        {
            get{ return _headimgurl; }
            set{ _headimgurl = value; }
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
				private string _pwd;
		/// <summary>
		/// 用户密码
        /// </summary>
        public string Pwd
        {
            get{ return _pwd; }
            set{ _pwd = value; }
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
				private int _groupclass;
		/// <summary>
		/// 用户组：6普通用户，9管理员
        /// </summary>
        public int GroupClass
        {
            get{ return _groupclass; }
            set{ _groupclass = value; }
        }        
				private string _operator;
		/// <summary>
		/// 操作人
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