using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace Fm.BusinessRules
{
    public class LifeUserAuthenticationDy : SoapHeader
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LifeUserAuthenticationDy()
        {
        }

        /// <summary>
        /// 构造函数，初始化用户名密码
        /// </summary>
        /// <param name="iUserId">用户名</param>
        /// <param name="iPassWord">密码</param>
        public LifeUserAuthenticationDy(string iAPIAccount, string iAPISecret)
        {
            Initial(iAPIAccount, iAPISecret);
        }

        /// <summary>
        /// Account
        /// </summary>
        public string APIAccount { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string APISecret { get; set; }

        /// <summary>
        /// 初始化用户名密码
        /// </summary>
        /// <param name="iUserId">用户名</param>
        /// <param name="iPassWord">密码</param>
        private void Initial(string iAPIAccount, string iAPISecret)
        {
            APIAccount = iAPIAccount;
            APISecret = iAPISecret;
        }

        /// <summary>
        /// 验证用户身份公用方法
        /// </summary>
        /// <param name="iMsg">提示信息</param>
        /// <returns>是否合法</returns>
        public bool IsValid(out string iMsg)
        {
            return IsValid(APIAccount, APISecret, out iMsg);
        }

        private bool IsValid(string iUserId, string iPassWord, out string iMsg)
        {
            iMsg = "";
            try
            {
                //判断用户名密码
                if ((iUserId == Fm.BLL.Base.SoapConfig.APIAccount && iPassWord == Fm.BLL.Base.SoapConfig.APISecret))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                iMsg = "对不起，异常错误，请稍后再试！";
                return false;
            }
        }

 
    }
}
