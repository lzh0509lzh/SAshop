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
    /// orderrecord数据访问层类
    /// </summary>
	public partial class orderrecord
	{ 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DBHelper myHelperMySQL ,Fm.Entity.orderrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into orderrecord(");			
            strSql.Append("OrderId,UserId,UserName,PerName,Address,Mobile,Stateid,PostAmount,Amount,Createdate,RefreshDate");
			strSql.Append(") values (");
            strSql.Append("@OrderId,@UserId,@UserName,@PerName,@Address,@Mobile,@Stateid,@PostAmount,@Amount,@Createdate,@RefreshDate");            
            strSql.Append(") ");            
            	
			MySqlParameter[] parameters = {
			            new MySqlParameter("@OrderId", model.OrderId)  ,
                                    new MySqlParameter("@UserId", model.UserId)  ,
                                    new MySqlParameter("@UserName", model.UserName)  ,
                                    new MySqlParameter("@PerName", model.PerName)  ,
                                    new MySqlParameter("@Address", model.Address)  ,
                                    new MySqlParameter("@Mobile", model.Mobile)  ,
                                    new MySqlParameter("@Stateid", model.Stateid)  ,
                                    new MySqlParameter("@PostAmount", model.PostAmount)  ,
                                    new MySqlParameter("@Amount", model.Amount)  ,
                                    new MySqlParameter("@Createdate", model.Createdate)  ,
                                    new MySqlParameter("@RefreshDate", model.RefreshDate)              
            };
            
            myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);		
		}
		
		/// <summary>
		/// 更新一条数据(所有字段)
		/// </summary>
		public int Update(DBHelper myHelperMySQL ,Fm.Entity.orderrecord model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update orderrecord set ");
			                        
            strSql.Append(" OrderId = @OrderId , ");                                    
            strSql.Append(" UserId = @UserId , ");                                    
            strSql.Append(" UserName = @UserName , ");                                    
            strSql.Append(" PerName = @PerName , ");                                    
            strSql.Append(" Address = @Address , ");                                    
            strSql.Append(" Mobile = @Mobile , ");                                    
            strSql.Append(" Stateid = @Stateid , ");                                    
            strSql.Append(" PostAmount = @PostAmount , ");                                    
            strSql.Append(" Amount = @Amount , ");                                    
            strSql.Append(" Createdate = @Createdate , ");                                    
            strSql.Append(" RefreshDate = @RefreshDate  ");                        			
			MySqlParameter[] parameters = {
			            new MySqlParameter("@OrderId", model.OrderId)  ,
                                    new MySqlParameter("@UserId", model.UserId)  ,
                                    new MySqlParameter("@UserName", model.UserName)  ,
                                    new MySqlParameter("@PerName", model.PerName)  ,
                                    new MySqlParameter("@Address", model.Address)  ,
                                    new MySqlParameter("@Mobile", model.Mobile)  ,
                                    new MySqlParameter("@Stateid", model.Stateid)  ,
                                    new MySqlParameter("@PostAmount", model.PostAmount)  ,
                                    new MySqlParameter("@Amount", model.Amount)  ,
                                    new MySqlParameter("@Createdate", model.Createdate)  ,
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
            strSql.Append("update orderrecord set ");
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
			strSql.Append("delete from orderrecord ");
			
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
			strSql.Append("  FROM orderrecord  ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            List<Fm.Entity.orderrecord> myList = new List<Fm.Entity.orderrecord>();
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
		public List<Fm.Entity.orderrecord> GetList(DBHelper myHelperMySQL ,int Top, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" a.OrderId, a.UserId, a.UserName, a.PerName, a.Address, a.Mobile, a.Stateid, a.PostAmount, a.Amount, a.Createdate, a.RefreshDate  ");			
			strSql.Append("  FROM orderrecord a ");
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
            List<Fm.Entity.orderrecord> myList = new List<Fm.Entity.orderrecord>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.orderrecord model = new Fm.Entity.orderrecord();
                    
                    															model.OrderId= dr["OrderId"].ToString();
																																								model.UserId= dr["UserId"].ToString();
																																								model.UserName= dr["UserName"].ToString();
																																								model.PerName= dr["PerName"].ToString();
																																								model.Address= dr["Address"].ToString();
																																								model.Mobile= dr["Mobile"].ToString();
																																			if(dr["Stateid"].ToString()!="")
					{
						model.Stateid=int.Parse(dr["Stateid"].ToString());
					}
																																								if(dr["PostAmount"].ToString()!="")
					{
						model.PostAmount=decimal.Parse(dr["PostAmount"].ToString());
					}
																																								if(dr["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dr["Amount"].ToString());
					}
																																													model.Createdate= dr["Createdate"].ToString();
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
		public List<Fm.Entity.orderrecord> GetList(DBHelper myHelperMySQL ,int Top, string filedSelect, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//自定义字段
            strSql.Append(" " + filedSelect);
			strSql.Append("  FROM orderrecord a  ");			
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
            List<Fm.Entity.orderrecord> myList = new List<Fm.Entity.orderrecord>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.orderrecord model = new Fm.Entity.orderrecord();
                    
                    	                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.orderid").Count() > 0)
	                {
															model.OrderId= dr["OrderId"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.userid").Count() > 0)
	                {
															model.UserId= dr["UserId"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.username").Count() > 0)
	                {
															model.UserName= dr["UserName"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.pername").Count() > 0)
	                {
															model.PerName= dr["PerName"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.address").Count() > 0)
	                {
															model.Address= dr["Address"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.mobile").Count() > 0)
	                {
															model.Mobile= dr["Mobile"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.stateid").Count() > 0)
	                {
										if(dr["Stateid"].ToString()!="")
					{
						model.Stateid=int.Parse(dr["Stateid"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.postamount").Count() > 0)
	                {
										if(dr["PostAmount"].ToString()!="")
					{
						model.PostAmount=decimal.Parse(dr["PostAmount"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.amount").Count() > 0)
	                {
										if(dr["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dr["Amount"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.createdate").Count() > 0)
	                {
															model.Createdate= dr["Createdate"].ToString();
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