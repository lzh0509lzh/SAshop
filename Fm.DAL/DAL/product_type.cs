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
    /// product_type数据访问层类
    /// </summary>
	public partial class product_type
	{ 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DBHelper myHelperMySQL ,Fm.Entity.product_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into product_type(");			
            strSql.Append("TypeId,TypeName,TypePic,FatherTypeId,Operator,StateId,CreateDate,RefreshDate");
			strSql.Append(") values (");
            strSql.Append("@TypeId,@TypeName,@TypePic,@FatherTypeId,@Operator,@StateId,@CreateDate,@RefreshDate");            
            strSql.Append(") ");            
            	
			MySqlParameter[] parameters = {
			            new MySqlParameter("@TypeId", model.TypeId)  ,
                                    new MySqlParameter("@TypeName", model.TypeName)  ,
                                    new MySqlParameter("@TypePic", model.TypePic)  ,
                                    new MySqlParameter("@FatherTypeId", model.FatherTypeId)  ,
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
		public int Update(DBHelper myHelperMySQL ,Fm.Entity.product_type model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update product_type set ");
			                        
            strSql.Append(" TypeId = @TypeId , ");                                    
            strSql.Append(" TypeName = @TypeName , ");                                    
            strSql.Append(" TypePic = @TypePic , ");                                    
            strSql.Append(" FatherTypeId = @FatherTypeId , ");                                    
            strSql.Append(" Operator = @Operator , ");                                    
            strSql.Append(" StateId = @StateId , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" RefreshDate = @RefreshDate  ");                        			
			MySqlParameter[] parameters = {
			            new MySqlParameter("@TypeId", model.TypeId)  ,
                                    new MySqlParameter("@TypeName", model.TypeName)  ,
                                    new MySqlParameter("@TypePic", model.TypePic)  ,
                                    new MySqlParameter("@FatherTypeId", model.FatherTypeId)  ,
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
            strSql.Append("update product_type set ");
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
			strSql.Append("delete from product_type ");
			
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
			strSql.Append("  FROM product_type  ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            List<Fm.Entity.product_type> myList = new List<Fm.Entity.product_type>();
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
		public List<Fm.Entity.product_type> GetList(DBHelper myHelperMySQL ,int Top, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" a.TypeId, a.TypeName, a.TypePic, a.FatherTypeId, a.Operator, a.StateId, a.CreateDate, a.RefreshDate  ");			
			strSql.Append("  FROM product_type a ");
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
            List<Fm.Entity.product_type> myList = new List<Fm.Entity.product_type>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.product_type model = new Fm.Entity.product_type();
                    
                    										if(dr["TypeId"].ToString()!="")
					{
						model.TypeId=int.Parse(dr["TypeId"].ToString());
					}
																																													model.TypeName= dr["TypeName"].ToString();
																																								model.TypePic= dr["TypePic"].ToString();
																																			if(dr["FatherTypeId"].ToString()!="")
					{
						model.FatherTypeId=int.Parse(dr["FatherTypeId"].ToString());
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
		public List<Fm.Entity.product_type> GetList(DBHelper myHelperMySQL ,int Top, string filedSelect, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//自定义字段
            strSql.Append(" " + filedSelect);
			strSql.Append("  FROM product_type a  ");			
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
            List<Fm.Entity.product_type> myList = new List<Fm.Entity.product_type>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.product_type model = new Fm.Entity.product_type();
                    
                    	                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.typeid").Count() > 0)
	                {
										if(dr["TypeId"].ToString()!="")
					{
						model.TypeId=int.Parse(dr["TypeId"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.typename").Count() > 0)
	                {
															model.TypeName= dr["TypeName"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.typepic").Count() > 0)
	                {
															model.TypePic= dr["TypePic"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.fathertypeid").Count() > 0)
	                {
										if(dr["FatherTypeId"].ToString()!="")
					{
						model.FatherTypeId=int.Parse(dr["FatherTypeId"].ToString());
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