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
    /// wx_userinfo数据访问层类
    /// </summary>
	public partial class wx_userinfo
	{ 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DBHelper myHelperMySQL ,Fm.Entity.wx_userinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_userinfo(");			
            strSql.Append("openid,nickname,sex,province,city,country,headimgurl,privilege,unionid,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@openid,@nickname,@sex,@province,@city,@country,@headimgurl,@privilege,@unionid,@CreateDate");            
            strSql.Append(") ");            
            	
			MySqlParameter[] parameters = {
			            new MySqlParameter("@openid", model.openid)  ,
                                    new MySqlParameter("@nickname", model.nickname)  ,
                                    new MySqlParameter("@sex", model.sex)  ,
                                    new MySqlParameter("@province", model.province)  ,
                                    new MySqlParameter("@city", model.city)  ,
                                    new MySqlParameter("@country", model.country)  ,
                                    new MySqlParameter("@headimgurl", model.headimgurl)  ,
                                    new MySqlParameter("@privilege", model.privilege)  ,
                                    new MySqlParameter("@unionid", model.unionid)  ,
                                    new MySqlParameter("@CreateDate", model.CreateDate)              
            };
            
            myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);		
		}
		
		/// <summary>
		/// 更新一条数据(所有字段)
		/// </summary>
		public int Update(DBHelper myHelperMySQL ,Fm.Entity.wx_userinfo model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_userinfo set ");
			                        
            strSql.Append(" openid = @openid , ");                                    
            strSql.Append(" nickname = @nickname , ");                                    
            strSql.Append(" sex = @sex , ");                                    
            strSql.Append(" province = @province , ");                                    
            strSql.Append(" city = @city , ");                                    
            strSql.Append(" country = @country , ");                                    
            strSql.Append(" headimgurl = @headimgurl , ");                                    
            strSql.Append(" privilege = @privilege , ");                                    
            strSql.Append(" unionid = @unionid , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");                        			
			MySqlParameter[] parameters = {
			            new MySqlParameter("@openid", model.openid)  ,
                                    new MySqlParameter("@nickname", model.nickname)  ,
                                    new MySqlParameter("@sex", model.sex)  ,
                                    new MySqlParameter("@province", model.province)  ,
                                    new MySqlParameter("@city", model.city)  ,
                                    new MySqlParameter("@country", model.country)  ,
                                    new MySqlParameter("@headimgurl", model.headimgurl)  ,
                                    new MySqlParameter("@privilege", model.privilege)  ,
                                    new MySqlParameter("@unionid", model.unionid)  ,
                                    new MySqlParameter("@CreateDate", model.CreateDate)               
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
            strSql.Append("update wx_userinfo set ");
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
			strSql.Append("delete from wx_userinfo ");
			
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
			strSql.Append("  FROM wx_userinfo  ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            List<Fm.Entity.wx_userinfo> myList = new List<Fm.Entity.wx_userinfo>();
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
		public List<Fm.Entity.wx_userinfo> GetList(DBHelper myHelperMySQL ,int Top, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" a.openid, a.nickname, a.sex, a.province, a.city, a.country, a.headimgurl, a.privilege, a.unionid, a.CreateDate  ");			
			strSql.Append("  FROM wx_userinfo a ");
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
            List<Fm.Entity.wx_userinfo> myList = new List<Fm.Entity.wx_userinfo>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.wx_userinfo model = new Fm.Entity.wx_userinfo();
                    
                    															model.openid= dr["openid"].ToString();
																																								model.nickname= dr["nickname"].ToString();
																																			if(dr["sex"].ToString()!="")
					{
						model.sex=int.Parse(dr["sex"].ToString());
					}
																																													model.province= dr["province"].ToString();
																																								model.city= dr["city"].ToString();
																																								model.country= dr["country"].ToString();
																																								model.headimgurl= dr["headimgurl"].ToString();
																																								model.privilege= dr["privilege"].ToString();
																																								model.unionid= dr["unionid"].ToString();
																																								model.CreateDate= dr["CreateDate"].ToString();
																									
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
		public List<Fm.Entity.wx_userinfo> GetList(DBHelper myHelperMySQL ,int Top, string filedSelect, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//自定义字段
            strSql.Append(" " + filedSelect);
			strSql.Append("  FROM wx_userinfo a  ");			
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
            List<Fm.Entity.wx_userinfo> myList = new List<Fm.Entity.wx_userinfo>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.wx_userinfo model = new Fm.Entity.wx_userinfo();
                    
                    	                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.openid").Count() > 0)
	                {
															model.openid= dr["openid"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.nickname").Count() > 0)
	                {
															model.nickname= dr["nickname"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.sex").Count() > 0)
	                {
										if(dr["sex"].ToString()!="")
					{
						model.sex=int.Parse(dr["sex"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.province").Count() > 0)
	                {
															model.province= dr["province"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.city").Count() > 0)
	                {
															model.city= dr["city"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.country").Count() > 0)
	                {
															model.country= dr["country"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.headimgurl").Count() > 0)
	                {
															model.headimgurl= dr["headimgurl"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.privilege").Count() > 0)
	                {
															model.privilege= dr["privilege"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.unionid").Count() > 0)
	                {
															model.unionid= dr["unionid"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.createdate").Count() > 0)
	                {
															model.CreateDate= dr["CreateDate"].ToString();
																									} 
					
                    myList.Add(model);
                }
                dr.Close();
            }
            return myList;
		}

	}
}