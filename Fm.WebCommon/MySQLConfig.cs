using System;
using System.Configuration;
using System.Text;
using Fm.Core.DEncrypt;

namespace Fm.WebCommon
{
    
    public class MySQLConfig
    {
        private static readonly string ConStringEncrypt = "flase";
        private static readonly string strSQLServerIp = "server=gz-cdb-7mb8ndct.sql.tencentcdb.com:63403;Port=63403;";
        private static readonly string strSQLDBPassword = "user id=root;";
        private static readonly string strSQLDBName = "password=lizhen@2688;";
        private static readonly string strSQLDBUserName = "database=GoThing;";
        private static readonly string MaxPool = "maxpoolsize=10;";//最大连接数
        private static readonly string MinPool = "minpoolsize=5;"; //最小连接数      
        private static readonly string Conn_Timeout = "connectiontimeout=15;";  //设置连接等待时间
        private static readonly string Conn_Lifetime = "connectionlifetime=15";//设置连接的生命周期
        private static readonly bool Asyn_Process = true;//设置异步访问数据库

        private static readonly string MySQLConStr = ""+
            "server=gz-cdb-7mb8ndct.sql.tencentcdb.com;" +
            "Port=63403;" +
            "user id=root;" +
            "password=lizhen@2688;"+
            "database=GoThing;"+
            "maxpoolsize=10;" +         //最大连接数
            "minpoolsize=5;" +          //最小连接数   
            "connectiontimeout=15;" +   //设置连接等待时间
            "connectionlifetime=15";    //设置连接的生命周期

        /// <summary>
        /// bookdinner库(连接池)
        /// </summary>
        public static string ConnStringCenter
        {           
            get 
            {
                //StringBuilder strConn = new StringBuilder();
                //if (ConStringEncrypt == "true")
                //{
                //    strConn.Append(DESEncrypt.Decrypt(strSQLServerIp));
                //    strConn.Append(DESEncrypt.Decrypt(strSQLDBUserName));
                //    strConn.Append(DESEncrypt.Decrypt(strSQLDBPassword));
                //    strConn.Append(DESEncrypt.Decrypt(strSQLDBName));
                //}
                //else
                //{
                //    strConn.Append(strSQLServerIp);
                //    strConn.Append(strSQLDBUserName);
                //    strConn.Append(strSQLDBPassword);
                //    strConn.Append(strSQLDBName);
                //}
                return MySQLConStr;
            }
        }


    }
}
