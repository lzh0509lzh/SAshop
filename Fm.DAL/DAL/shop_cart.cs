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
    /// shop_cart数据访问层类
    /// </summary>
	public partial class shop_cart
	{ 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DBHelper myHelperMySQL ,Fm.Entity.shop_cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into shop_cart(");			
            strSql.Append("Cartid,UserId,ProductId,CartNum");
			strSql.Append(") values (");
            strSql.Append("@Cartid,@UserId,@ProductId,@CartNum");            
            strSql.Append(") ");            
            	
			MySqlParameter[] parameters = {
			            new MySqlParameter("@Cartid", model.Cartid)  ,
                                    new MySqlParameter("@UserId", model.UserId)  ,
                                    new MySqlParameter("@ProductId", model.ProductId)  ,
                                    new MySqlParameter("@CartNum", model.CartNum)              
            };
            
            myHelperMySQL.ExecuteNonQuery(strSql.ToString(),parameters);		
		}
		
		/// <summary>
		/// 更新一条数据(所有字段)
		/// </summary>
		public int Update(DBHelper myHelperMySQL ,Fm.Entity.shop_cart model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update shop_cart set ");
			                        
            strSql.Append(" Cartid = @Cartid , ");                                    
            strSql.Append(" UserId = @UserId , ");                                    
            strSql.Append(" ProductId = @ProductId , ");                                    
            strSql.Append(" CartNum = @CartNum  ");                        			
			MySqlParameter[] parameters = {
			            new MySqlParameter("@Cartid", model.Cartid)  ,
                                    new MySqlParameter("@UserId", model.UserId)  ,
                                    new MySqlParameter("@ProductId", model.ProductId)  ,
                                    new MySqlParameter("@CartNum", model.CartNum)               
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
            strSql.Append("update shop_cart set ");
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
			strSql.Append("delete from shop_cart ");
			
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
			strSql.Append("  FROM shop_cart  ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            List<Fm.Entity.shop_cart> myList = new List<Fm.Entity.shop_cart>();
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
		public List<Fm.Entity.shop_cart> GetList(DBHelper myHelperMySQL ,int Top, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" a.Cartid, a.UserId, a.ProductId, a.CartNum  ");			
			strSql.Append("  FROM shop_cart a ");
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
            List<Fm.Entity.shop_cart> myList = new List<Fm.Entity.shop_cart>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.shop_cart model = new Fm.Entity.shop_cart();
                    
                    										if(dr["Cartid"].ToString()!="")
					{
						model.Cartid=int.Parse(dr["Cartid"].ToString());
					}
																																													model.UserId= dr["UserId"].ToString();
																																								model.ProductId= dr["ProductId"].ToString();
																																			if(dr["CartNum"].ToString()!="")
					{
						model.CartNum=int.Parse(dr["CartNum"].ToString());
					}
																														
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
		public List<Fm.Entity.shop_cart> GetList(DBHelper myHelperMySQL ,int Top, string filedSelect, string strWhere, string filedOrder, MySqlParameter[] parameters)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//自定义字段
            strSql.Append(" " + filedSelect);
			strSql.Append("  FROM shop_cart a  ");			
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
            List<Fm.Entity.shop_cart> myList = new List<Fm.Entity.shop_cart>();
            using (MySqlDataReader dr = myHelperMySQL.ExecuteReader(strSql.ToString(), parameters))
            {
                while (dr.Read())
                {
                    Fm.Entity.shop_cart model = new Fm.Entity.shop_cart();
                    
                    	                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.cartid").Count() > 0)
	                {
										if(dr["Cartid"].ToString()!="")
					{
						model.Cartid=int.Parse(dr["Cartid"].ToString());
					}
																														} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.userid").Count() > 0)
	                {
															model.UserId= dr["UserId"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.productid").Count() > 0)
	                {
															model.ProductId= dr["ProductId"].ToString();
																									} 
						                if (filedSelect.ToLower().Split(',').Where(x => x.Trim() == "a.cartnum").Count() > 0)
	                {
										if(dr["CartNum"].ToString()!="")
					{
						model.CartNum=int.Parse(dr["CartNum"].ToString());
					}
																														} 
					
                    myList.Add(model);
                }
                dr.Close();
            }
            return myList;
		}

	}
}