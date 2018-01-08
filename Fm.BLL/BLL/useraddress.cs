/*         
*│版权所有：Dream1993
*│创建人：Lee        
*/  
using System;
using System.Web;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Fm.WebCommon;

namespace Fm.BLL{
	public partial class useraddress
	{	     
		private readonly Fm.DAL.useraddress dal = new Fm.DAL.useraddress();
		
		#region GetListCustomByXxx 方法，根据Xxx取出  信息(自定义字段)
        /// <summary>
        /// 获得useraddress数据列表(独立连接)
        /// <param name="Xxx"></param>
        /// </summary>
        public List<Fm.Entity.useraddress> GetListCustomByXxx(string Xxx)
        {
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();
            DBHelper myHelperMySQL = new DBHelper();
            myHelperMySQL.connectionStr = MySQLConfig.ConnStringCenter;
            try
            {
                myList = this.GetListCustomByXxx(myHelperMySQL, Xxx);
            }
            catch (Exception errorStr)
            {
                #region 出错打印日志
                //打印日志-----------------------------------------------------------------

                string MailContent = "服务器出现错误!" + ((char)13).ToString() + ((char)10).ToString() +
                    "地址：" + HttpContext.Current.Request.ServerVariables.Get("LOCAL_ADDR").ToString() + ((char)13).ToString() + 
					((char)10).ToString() +
                    "时间：" + DateTime.Now.ToString("yyyy-MM-dd") + ((char)13).ToString() + ((char)10).ToString() +
                    "内容：" + errorStr.ToString() + ((char)13).ToString() + ((char)10).ToString() + " ";

                //-------------------------------------------------------------------------------
                #endregion
            }
            return myList;
        }
        /// <summary>
        /// 获得useraddress数据列表，(方法外传入连接对象，需要人工关闭连接)
        /// <param name="myHelperMySQL">自定义数据连接对象实例</param>
        /// <param name="Xxx"></param>
        /// </summary>
        public List<Fm.Entity.useraddress> GetListCustomByXxx(DBHelper myHelperMySQL, string Xxx)
        {
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();

            //字段
            string fieldSelect = "";
            fieldSelect = "a.Xxx, a.Yyy ";

            //条件
            string strWhere = "Xxx=@Xxx";
            //排序
            string fieldOrder = "createdate desc";
            //参数
            MySqlParameter[] parms =
            {
                new MySqlParameter("Xxx", Xxx)
            };

            myList = dal.GetList(myHelperMySQL, 0, fieldSelect, strWhere, fieldOrder, parms);

            return myList;
        }
        #endregion

        #region GetListNumByXxx 方法，根据Xxx取出符合条件记录数量(自定义字段)
        /// <summary>
        /// 获得useraddress数据列表记录数(独立连接)
        /// <param name="Xxx"></param>
        /// </summary>
        public int GetListNumByXxx(string Xxx)
        {
            int Num = 0;
            DBHelper myHelperMySQL = new DBHelper();
            myHelperMySQL.connectionStr = MySQLConfig.ConnStringCenter;
            try
            {
                Num = this.GetListNumByXxx(myHelperMySQL, Xxx);
            }
            catch (Exception errorStr)
            {
               #region 出错打印日志
                //打印日志-----------------------------------------------------------------

                string MailContent = "服务器出现错误!" + ((char)13).ToString() + ((char)10).ToString() +
                    "地址：" + HttpContext.Current.Request.ServerVariables.Get("LOCAL_ADDR").ToString() + ((char)13).ToString() + 
					((char)10).ToString() +
                    "时间：" + DateTime.Now.ToString("yyyy-MM-dd") + ((char)13).ToString() + ((char)10).ToString() +
                    "内容：" + errorStr.ToString() + ((char)13).ToString() + ((char)10).ToString() + " ";

                //-------------------------------------------------------------------------------
                #endregion
            }
            return Num;
        }
        /// <summary>
        /// 获得useraddress数据列表记录数，(方法外传入连接对象，需要人工关闭连接)
        /// <param name="myHelperMySQL">自定义数据连接对象实例</param>
        /// <param name="Xxx"></param>
        /// </summary>
        public int GetListNumByXxx(DBHelper myHelperMySQL, string Xxx)
        {
            int Num = 0;


            //条件
            string strWhere = "Xxx=@Xxx";

            //参数
            MySqlParameter[] parms =
            {
                new MySqlParameter("Xxx", Xxx)
            };

            Num = dal.GetListNum(myHelperMySQL, strWhere, parms);

            return Num;
        }
        #endregion

        #region UpdateCustom 方法，更新指定字段
        /// <summary>
        /// 更新useraddress指定字段(独立连接)
        /// </summary>
        /// <param name="Xxx">条件</param>
        /// <param name="Vvv1">值1</param>
        /// <param name="Vvv2">值2</param>
        /// <returns>生效记录数</returns>
        public int UpdateCustom(string Xxx, string Vvv1, string Vvv2)
        {
            int iNum = 0;
            DBHelper myHelperMySQL = new DBHelper();
            myHelperMySQL.connectionStr = MySQLConfig.ConnStringCenter;
            try
            {
                iNum = this.UpdateCustom(myHelperMySQL, Xxx, Vvv1, Vvv2);
            }
            catch (Exception errorStr)
            {
                #region 出错打印日志
                //打印日志-----------------------------------------------------------------

                string MailContent = "服务器出现错误!" + ((char)13).ToString() + ((char)10).ToString() +
                    "地址：" + HttpContext.Current.Request.ServerVariables.Get("LOCAL_ADDR").ToString() + ((char)13).ToString() + 
					((char)10).ToString() +
                    "时间：" + DateTime.Now.ToString("yyyy-MM-dd") + ((char)13).ToString() + ((char)10).ToString() +
                    "内容：" + errorStr.ToString() + ((char)13).ToString() + ((char)10).ToString() + " ";

                //-------------------------------------------------------------------------------
                #endregion
            }
            return iNum;
        }
        /// <summary>
        /// 更新useraddress指定字段，(方法外传入连接对象，需要人工关闭连接)
        /// </summary>
        /// <param name="myDbHelperC">自定义数据连接对象实例</param>
        /// <param name="Xxx">条件</param>
        /// <param name="Vvv1">值1</param>
        /// <param name="Vvv2">值2</param>
        /// <returns>生效记录数</returns>
        public int UpdateCustom(DBHelper myHelperMySQL, string Xxx, string Vvv1, string Vvv2)
        {
            int iNum = 0;
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();

            //条件
            string strWhere = "Xxx=@Xxx";

            //字段
            string fieldUpdate = "Field1=@Vvv1,Field2=@Vvv2 ";
            //参数

            MySqlParameter[] parms = 
			{
                new MySqlParameter("Xxx",Xxx),
                new MySqlParameter("Field1",Vvv1),
                new MySqlParameter("Field2",Vvv2)
			};

            iNum = dal.Update(myHelperMySQL, strWhere, fieldUpdate, parms);
            return iNum;


        }
        #endregion

        #region DeleteByXxx 方法，删除指定条件记录
        /// <summary>
        /// 删除useraddress指定条件记录(独立连接)
        /// </summary>
        /// <param name="Xxx">条件</param>
        /// <returns>生效记录数</returns>
        public int DeleteByXxx(string Xxx)
        {
            int iNum = 0;
            DBHelper myHelperMySQL = new DBHelper();
            myHelperMySQL.connectionStr = MySQLConfig.ConnStringCenter;
            try
            {
                iNum = this.DeleteByXxx(myHelperMySQL, Xxx);
            }
            catch (Exception errorStr)
            {
                #region 出错打印日志
                //打印日志-----------------------------------------------------------------

                string MailContent = "服务器出现错误!" + ((char)13).ToString() + ((char)10).ToString() +
                    "地址：" + HttpContext.Current.Request.ServerVariables.Get("LOCAL_ADDR").ToString() + ((char)13).ToString() + 
					((char)10).ToString() +
                    "时间：" + DateTime.Now.ToString("yyyy-MM-dd") + ((char)13).ToString() + ((char)10).ToString() +
                    "内容：" + errorStr.ToString() + ((char)13).ToString() + ((char)10).ToString() + " ";

                //-------------------------------------------------------------------------------
                #endregion
            }
            return iNum;
        }
        /// <summary>
        /// 删除useraddress指定条件记录，(方法外传入连接对象，需要人工关闭连接)
        /// </summary>
        /// <param name="myHelperMySQL">自定义数据连接对象实例</param>
        /// <param name="Xxx">条件</param>
        /// <returns>生效记录数</returns>
        public int DeleteByXxx(DBHelper myHelperMySQL, string Xxx)
        {
            int iNum = 0;
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();

            //条件
            string strWhere = "Xxx=@Xxx";

            //参数
            MySqlParameter[] parms =
            {
                new MySqlParameter("Xxx", Xxx)
            };

            iNum = dal.Delete(myHelperMySQL, strWhere, parms);
            return iNum;


        }
        #endregion


        #region GetAddressListByUserid 方法，根据Userid取出地址列表(自定义字段)
        /// <summary>
        /// 获得useraddress数据列表(独立连接)
        /// <param name="Userid"></param>
        /// </summary>
        public List<Fm.Entity.useraddress> GetAddressListByUserid(string Userid)
        {
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();
            DBHelper myHelperMySQL = new DBHelper();
            myHelperMySQL.connectionStr = MySQLConfig.ConnStringCenter;
            try
            {
                myList = this.GetAddressListByUserid(myHelperMySQL, Userid);
            }
            catch (Exception errorStr)
            {
                #region 出错打印日志
                //打印日志-----------------------------------------------------------------

                string MailContent = "服务器出现错误!" + ((char)13).ToString() + ((char)10).ToString() +
                    "地址：" + HttpContext.Current.Request.ServerVariables.Get("LOCAL_ADDR").ToString() + ((char)13).ToString() +
                    ((char)10).ToString() +
                    "时间：" + DateTime.Now.ToString("yyyy-MM-dd") + ((char)13).ToString() + ((char)10).ToString() +
                    "内容：" + errorStr.ToString() + ((char)13).ToString() + ((char)10).ToString() + " ";

                //-------------------------------------------------------------------------------
                #endregion
            }
            return myList;
        }
        /// <summary>
        /// 获得useraddress数据列表，(方法外传入连接对象，需要人工关闭连接)
        /// <param name="myHelperMySQL">自定义数据连接对象实例</param>
        /// <param name="Userid"></param>
        /// </summary>
        public List<Fm.Entity.useraddress> GetAddressListByUserid(DBHelper myHelperMySQL, string Userid)
        {
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();

            //字段
            string fieldSelect = "";
            fieldSelect = "a.Address, a.PerMobile,a.PerName,a.Address,a.StateId ";

            //条件
            string strWhere = "Userid=@Userid and StateId<>0";
            //排序
            string fieldOrder = "createdate desc";
            //参数
            MySqlParameter[] parms =
            {
                new MySqlParameter("Userid", Userid)
            };

            myList = dal.GetList(myHelperMySQL, 0, fieldSelect, strWhere, fieldOrder, parms);

            return myList;
        }
        #endregion

        #region UpdateAll 方法，更新指定字段
        /// <summary>
        /// 更新useraddress指定字段(独立连接)
        /// </summary>
        /// <param name="AddressID">条件</param>
        /// <param name="PerMobile">收货人手机号</param>
        /// <param name="PerName">收货人姓名</param>
        /// <param name="Address">收货人地址</param>
        /// <param name="StateId">地址状态（0删除，1普通，2默认）</param>
        public int UpdateAll(string AddressID, string PerMobile, string PerName, string Address, string StateId)
        {
            int iNum = 0;
            DBHelper myHelperMySQL = new DBHelper();
            myHelperMySQL.connectionStr = MySQLConfig.ConnStringCenter;
            try
            {
                iNum = this.UpdateAll(myHelperMySQL, AddressID, PerMobile, PerName, Address, StateId);
            }
            catch (Exception errorStr)
            {
                #region 出错打印日志
                //打印日志-----------------------------------------------------------------

                string MailContent = "服务器出现错误!" + ((char)13).ToString() + ((char)10).ToString() +
                    "地址：" + HttpContext.Current.Request.ServerVariables.Get("LOCAL_ADDR").ToString() + ((char)13).ToString() +
                    ((char)10).ToString() +
                    "时间：" + DateTime.Now.ToString("yyyy-MM-dd") + ((char)13).ToString() + ((char)10).ToString() +
                    "内容：" + errorStr.ToString() + ((char)13).ToString() + ((char)10).ToString() + " ";

                //-------------------------------------------------------------------------------
                #endregion
            }
            return iNum;
        }
        /// <summary>
        /// 更新useraddress指定字段
        /// </summary>
        /// <param name="myHelperMySQL"></param>
        /// <param name="AddressID">条件</param>
        /// <param name="PerMobile">收货人手机号</param>
        /// <param name="PerName">收货人姓名</param>
        /// <param name="Address">收货人地址</param>
        /// <param name="StateId">地址状态（0删除，1普通，2默认）</param>
        /// <returns></returns>
        public int UpdateAll(DBHelper myHelperMySQL, string AddressID, string PerMobile, string PerName, string Address, string StateId)
        {
            int iNum = 0;
            List<Fm.Entity.useraddress> myList = new List<Fm.Entity.useraddress>();

            //条件
            string strWhere = "AddressID=@AddressID";

            //字段
            string fieldUpdate = "PerMobile=@PerMobile,PerName=@PerName,Address=@Address,StateId=@StateId ";

            //参数
            MySqlParameter[] parms =
            {
                new MySqlParameter("AddressID",AddressID),
                new MySqlParameter("PerMobile",PerMobile),
                new MySqlParameter("PerName",PerName),
                new MySqlParameter("Address",Address),
                new MySqlParameter("StateId",StateId),
            };

            iNum = dal.Update(myHelperMySQL, strWhere, fieldUpdate, parms);
            return iNum;


        }
        #endregion
    }
}