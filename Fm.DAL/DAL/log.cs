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
    /// log数据访问层类
    /// </summary>
	public partial class log
	{ 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DBHelper myHelperMySQL ,Fm.Entity.log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into log(");			
            strSql.Append("id,Writer,ProjectName,Content,CreateTime");
			strSql.Append(") values (");
            strSql.Append("@id,@Writer,@ProjectName,@Content,@CreateTime");            
            strSql.Append(") ");            
            	
			MySqlParameter[] parameters = {
			            new MySqlParameter("@id", model.id)  ,
                                    new MySqlParameter("@Writer", model.Writer)  ,
                                    new MySqlParameter("@ProjectName", model.ProjectName)  ,
                                    new MySqlParameter("@Content", model.Content)  ,
                                    new MySqlParameter("@CreateTime", model.CreateTime)              
            };
            
            myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);		
		}
		
		/// <summary>
		/// 更新一条数据(所有字段)
		/// </summary>
		public int Update(DBHelper myHelperMySQL ,Fm.Entity.log model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update log set ");
			                        
            strSql.Append(" id = @id , ");                                    
            strSql.Append(" Writer = @Writer , ");                                    
            strSql.Append(" ProjectName = @ProjectName , ");                                    
            strSql.Append(" Content = @Content , ");                                    
            strSql.Append(" CreateTime = @CreateTime  ");                        			
			MySqlParameter[] parameters = {
			            new MySqlParameter("@id", model.id)  ,
                                    new MySqlParameter("@Writer", model.Writer)  ,
                                    new MySqlParameter("@ProjectName", model.ProjectName)  ,
                                    new MySqlParameter("@Content", model.Content)  ,
                                    new MySqlParameter("@CreateTime", model.CreateTime)               
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
            strSql.Append("update log set ");
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
			strSql.Append("delete from log ");
			
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
			strSql.Append("  FROM log  ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            List<Fm.Entity.log> myList = new List<Fm.Entity.log>();
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
		public List<Fm.Entity.log> GetList(DBHelper myHelperMySQL ,int Top, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" a.id, a.Writer, a.ProjectName, a.Content, a.CreateTime  ");			
			strSql.Append("  FROM log a ");
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
            List<Fm.Entity.log> myList = new List<Fm.Entity.log>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.log model = new Fm.Entity.log();
                    
                    										if(dr["id"].ToString()!="")
					{
						model.id=int.Parse(dr["id"].ToString());
					}
																																													model.Writer= dr["Writer"].ToString();
																																								model.ProjectName= dr["ProjectName"].ToString();
																																								model.Content= dr["Content"].ToString();
																																								model.CreateTime= dr["CreateTime"].ToString();
																									
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
		public List<Fm.Entity.log> GetList(DBHelper myHelperMySQL ,int Top, string filedSelect, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//自定义字段
            strSql.Append(" " + filedSelect);
			strSql.Append("  FROM log a  ");			
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
            List<Fm.Entity.log> myList = new List<Fm.Entity.log>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.log model = new Fm.Entity.log();
                    
                    	                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.id").Count() > 0)
	                {
										if(dr["id"].ToString()!="")
					{
						model.id=int.Parse(dr["id"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.writer").Count() > 0)
	                {
															model.Writer= dr["Writer"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.projectname").Count() > 0)
	                {
															model.ProjectName= dr["ProjectName"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.content").Count() > 0)
	                {
															model.Content= dr["Content"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.createtime").Count() > 0)
	                {
															model.CreateTime= dr["CreateTime"].ToString();
																									} 
					
                    myList.Add(model);
                }
                dr.Close();
            }
            return myList;
		}

	}
}