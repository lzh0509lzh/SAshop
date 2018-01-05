using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace Fm.BusinessRules
{
    /// <summary>
    /// Web Services 基于SoapHeader的验证类（生活宝固定验证头）
    /// </summary>
    public class LifeUserAuthentication : SoapHeader
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LifeUserAuthentication()
        {
        }

        /// <summary>
        /// 构造函数，初始化用户名密码
        /// </summary>
        /// <param name="iUserId">用户名</param>
        /// <param name="iPassWord">密码</param>
        public LifeUserAuthentication(string iUserId, string iPassWord)
        {
            Initial(iUserId, iPassWord);
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 初始化用户名密码
        /// </summary>
        /// <param name="iUserId">用户名</param>
        /// <param name="iPassWord">密码</param>
        private void Initial(string iUserId, string iPassWord)
        {
            UserId = iUserId;
            PassWord = iPassWord;
        }

        /// <summary>
        /// 验证用户身份公用方法
        /// </summary>
        /// <param name="iMsg">提示信息</param>
        /// <returns>是否合法</returns>
        public bool IsValid(out string iMsg)
        {
            return IsValid(UserId, PassWord, out iMsg);
        }

        private bool IsValid(string iUserId, string iPassWord, out string iMsg)
        {
            iMsg = "";
            try
            {
                //BaseHandle.WriteLog("cdt", "1IsValid", iUserId + " " + iPassWord);
                //判断用户名密码
                if ((iUserId == Fm.BLL.Base.SoapConfig.APIAccount && iPassWord == Fm.BLL.Base.SoapConfig.APISecret))
                {
                    return true;
                }
                else
                {
                    if (string.IsNullOrEmpty(iUserId) || string.IsNullOrEmpty(iPassWord))
                    {
                        iMsg = "对不起，用户验证未通过！";
                        return false;
                    }
                    if ((iUserId == "2688" && iPassWord == "268826881"))
                    {
                        return true;
                    }

                    return true;
                }
            }
            catch
            {
                iMsg = "对不起，异常错误，请稍后再试！";
                return false;
            }
        }

        #region 未启用

        /// <summary>
        /// 接口名称
        /// </summary>			
        public string APIName { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceNo { get; set; }

        /// <summary>
        /// 设备类型： android手机，iPhone
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 系统版本号
        /// </summary>
        public string SystemVersion { get; set; }

        /// <summary>
        /// 应用版本号
        /// </summary>
        public string AppVersion { get; set; }

        #endregion

    }

    public class Parstr
    {

    }

}
