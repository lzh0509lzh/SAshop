/*         
*│版权所有：Dream1993
*│创建人：Lee        
*/  
using System;
using System.Text;
using System.Data;
using System.Linq;
using Fm.WebCommon;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Fm.DAL{
	/// <summary>
    /// userinfo数据访问层类
    /// </summary>
	public partial class userinfo
	{ 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DBHelper myHelperMySQL ,Fm.Entity.userinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userinfo(");			
            strSql.Append("UserId,Openid,headimgurl,UserName,Pwd,Mobile,GroupClass,Operator,StateId,CreateDate,RefreshDate");
			strSql.Append(") values (");
            strSql.Append("@UserId,@Openid,@headimgurl,@UserName,@Pwd,@Mobile,@GroupClass,@Operator,@StateId,@CreateDate,@RefreshDate");            
            strSql.Append(") ");            
            	
			MySqlParameter[] parameters = {
			            new MySqlParameter("@UserId", model.UserId)  ,
                                    new MySqlParameter("@Openid", model.Openid)  ,
                                    new MySqlParameter("@headimgurl", model.headimgurl)  ,
                                    new MySqlParameter("@UserName", model.UserName)  ,
                                    new MySqlParameter("@Pwd", model.Pwd)  ,
                                    new MySqlParameter("@Mobile", model.Mobile)  ,
                                    new MySqlParameter("@GroupClass", model.GroupClass)  ,
                                    new MySqlParameter("@Operator", model.Operator)  ,
                                    new MySqlParameter("@StateId", model.StateId)  ,
                                    new MySqlParameter("@CreateDate", model.CreateDate)  ,
                                    new MySqlParameter("@RefreshDate", model.RefreshDate)              
            };
            
            myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);		
		}
		
		/// <summary>
		/// 更新一条数据(所有字段)
		/// </summary>
		public int Update(DBHelper myHelperMySQL ,Fm.Entity.userinfo model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userinfo set ");
			                        
            strSql.Append(" UserId = @UserId , ");                                    
            strSql.Append(" Openid = @Openid , ");                                    
            strSql.Append(" headimgurl = @headimgurl , ");                                    
            strSql.Append(" UserName = @UserName , ");                                    
            strSql.Append(" Pwd = @Pwd , ");                                    
            strSql.Append(" Mobile = @Mobile , ");                                    
            strSql.Append(" GroupClass = @GroupClass , ");                                    
            strSql.Append(" Operator = @Operator , ");                                    
            strSql.Append(" StateId = @StateId , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" RefreshDate = @RefreshDate  ");                        			
			MySqlParameter[] parameters = {
			            new MySqlParameter("@UserId", model.UserId)  ,
                                    new MySqlParameter("@Openid", model.Openid)  ,
                                    new MySqlParameter("@headimgurl", model.headimgurl)  ,
                                    new MySqlParameter("@UserName", model.UserName)  ,
                                    new MySqlParameter("@Pwd", model.Pwd)  ,
                                    new MySqlParameter("@Mobile", model.Mobile)  ,
                                    new MySqlParameter("@GroupClass", model.GroupClass)  ,
                                    new MySqlParameter("@Operator", model.Operator)  ,
                                    new MySqlParameter("@StateId", model.StateId)  ,
                                    new MySqlParameter("@CreateDate", model.CreateDate)  ,
                                    new MySqlParameter("@RefreshDate", model.RefreshDate)               
            };
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            
            int rows=myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);

			return rows;
		}
		
		 /// <summary>
        /// 更新一条数据，自定义条件和字段
        /// </summary>
        /// <param name="myDbHelperC">DbHelperC实例（数据访问类）.</param>
        /// <param name="strWhere">条件（重要）</param>
        /// <param name="filedUpdate">更新字段</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int Update(DBHelper myHelperMySQL, string strWhere, string filedUpdate, MySqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update userinfo set ");
            if (filedUpdate != "")
            {
                strSql.Append(filedUpdate);

                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                int rows = myHelperMySQL.ExecuteNonQuery(strSql.ToString(), parameters);
                return rows;

            }
            else
            {
                return 0;
            }
        }
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(DBHelper myHelperMySQL ,string strWhere, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userinfo ");
			
			if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

			int rows=myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);
			return rows;
		}
	
		/// <summary>
        /// 得到一个对象实体(List类型)中指定条件记录数，数据连接类用DbHelperC（非静态）
        /// 表：PFWebSpecialityShop a
        ///     <param name="myHelperMySQL">myHelperMySQL实例（数据访问类）.</param>
        ///     <param name="strWhere">条件.</param>
        ///     <param name="dbParameters">参数(若条件中未使用参数可为null).</param>
        /// </summary>
        public int GetListNum(DBHelper myHelperMySQL, string strWhere, MySqlParameter[] parameters)
        {
            int Num = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" count(1) as Num ");
			strSql.Append("  FROM userinfo  ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            List<Fm.Entity.userinfo> myList = new List<Fm.Entity.userinfo>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    if (dr["Num"].ToString().Trim() != "")
                    {
                        Num = int.Parse(dr["Num"].ToString().Trim());
                    }
                }
                dr.Close();
            }
            return Num;
        }
		/// <summary>
        /// 得到一个对象实体(List类型)，数据连接类用myHelperMySQL（非静态）,查询全部数据
        /// 表：MessageBoard 
        /// <param name="myHelperMySQL">myHelperMySQL实例（数据访问类）.</param>
        /// <param name="Top">记录数.</param>
        /// <param name="strWhere">条件.</param>
        /// <param name="filedOrder">排序字段.</param>
        /// <param name="parameters">参数(若条件中未使用参数可为null).</param>
        /// </summary>
		public List<Fm.Entity.userinfo> GetList(DBHelper myHelperMySQL ,int Top, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" a.UserId, a.Openid, a.headimgurl, a.UserName, a.Pwd, a.Mobile, a.GroupClass, a.Operator, a.StateId, a.CreateDate, a.RefreshDate  ");			
			strSql.Append("  FROM userinfo a ");
			if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Fm.Entity.userinfo> myList = new List<Fm.Entity.userinfo>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.userinfo model = new Fm.Entity.userinfo();
                    
                    															model.UserId= dr["UserId"].ToString();
																																								model.Openid= dr["Openid"].ToString();
																																								model.headimgurl= dr["headimgurl"].ToString();
																																								model.UserName= dr["UserName"].ToString();
																																								model.Pwd= dr["Pwd"].ToString();
																																								model.Mobile= dr["Mobile"].ToString();
																																			if(dr["GroupClass"].ToString()!="")
					{
						model.GroupClass=int.Parse(dr["GroupClass"].ToString());
					}
																																													model.Operator= dr["Operator"].ToString();
																																			if(dr["StateId"].ToString()!="")
					{
						model.StateId=int.Parse(dr["StateId"].ToString());
					}
																																													model.CreateDate= dr["CreateDate"].ToString();
																																								model.RefreshDate= dr["RefreshDate"].ToString();
																									
                    myList.Add(model);
                }
                dr.Close();
            }
            return myList;
		}
		
		 /// <summary>
        /// 得到一个对象实体(List类型)，数据连接类用myHelperMySQL（非静态）
        /// 表：MessageBoard 
        /// <param name="myHelperMySQL">myHelperMySQL实例（数据访问类）.</param>
        /// <param name="Top">记录数.</param>
        /// <param name="filedSelect">自定义字段.</param> 
        /// <param name="strWhere">条件.</param>
        /// <param name="filedOrder">排序字段.</param>
        /// <param name="parameters">参数(若条件中未使用参数可为null).</param>
        /// </summary>
		public List<Fm.Entity.userinfo> GetList(DBHelper myHelperMySQL ,int Top, string filedSelect, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//自定义字段
            strSql.Append(" " + filedSelect);
			strSql.Append("  FROM userinfo a  ");			
			if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Fm.Entity.userinfo> myList = new List<Fm.Entity.userinfo>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.userinfo model = new Fm.Entity.userinfo();
                    
                    	                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.userid").Count() > 0)
	                {
															model.UserId= dr["UserId"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.openid").Count() > 0)
	                {
															model.Openid= dr["Openid"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.headimgurl").Count() > 0)
	                {
															model.headimgurl= dr["headimgurl"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.username").Count() > 0)
	                {
															model.UserName= dr["UserName"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.pwd").Count() > 0)
	                {
															model.Pwd= dr["Pwd"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.mobile").Count() > 0)
	                {
															model.Mobile= dr["Mobile"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.groupclass").Count() > 0)
	                {
										if(dr["GroupClass"].ToString()!="")
					{
						model.GroupClass=int.Parse(dr["GroupClass"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.operator").Count() > 0)
	                {
															model.Operator= dr["Operator"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.stateid").Count() > 0)
	                {
										if(dr["StateId"].ToString()!="")
					{
						model.StateId=int.Parse(dr["StateId"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.createdate").Count() > 0)
	                {
															model.CreateDate= dr["CreateDate"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.refreshdate").Count() > 0)
	                {
															model.RefreshDate= dr["RefreshDate"].ToString();
																									} 
					
                    myList.Add(model);
                }
                dr.Close();
            }
            return myList;
		}

	}
}