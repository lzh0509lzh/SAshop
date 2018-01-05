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
    /// wx_userinfo：实体类
    /// </summary>
	[Serializable]
	public class wx_userinfo
	{   
      			private string _openid;
		/// <summary>
		/// 用户的唯一标识
        /// </summary>
        public string openid
        {
            get{ return _openid; }
            set{ _openid = value; }
        }        
				private string _nickname;
		/// <summary>
		/// 用户昵称
        /// </summary>
        public string nickname
        {
            get{ return _nickname; }
            set{ _nickname = value; }
        }        
				private int _sex;
		/// <summary>
		/// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int sex
        {
            get{ return _sex; }
            set{ _sex = value; }
        }        
				private string _province;
		/// <summary>
		/// 用户个人资料填写的省份
        /// </summary>
        public string province
        {
            get{ return _province; }
            set{ _province = value; }
        }        
				private string _city;
		/// <summary>
		/// 普通用户个人资料填写的城市
        /// </summary>
        public string city
        {
            get{ return _city; }
            set{ _city = value; }
        }        
				private string _country;
		/// <summary>
		/// 国家，如中国为CN
        /// </summary>
        public string country
        {
            get{ return _country; }
            set{ _country = value; }
        }        
				private string _headimgurl;
		/// <summary>
		/// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        public string headimgurl
        {
            get{ return _headimgurl; }
            set{ _headimgurl = value; }
        }        
				private string _privilege;
		/// <summary>
		/// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        public string privilege
        {
            get{ return _privilege; }
            set{ _privilege = value; }
        }        
				private string _unionid;
		/// <summary>
		/// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string unionid
        {
            get{ return _unionid; }
            set{ _unionid = value; }
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
		   
	}
}