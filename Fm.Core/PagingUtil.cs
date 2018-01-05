//----------------------------------------------------------------
// Copyright (C) 2002-2012 Beijing 2688
// All rights reserved.
// Create by Cdt 2012-06-14 16:30:00  
/* 
 * 说明：
   List分页
 */
//----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Core
{
    /// <summary>
    /// 分页工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingUtil<T> : List<T>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int DataCount { get; set; }//总记录数
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }//总页数
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNo { get; set; }//当前页码
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize { get; set; }//每页显示记录数
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return PageNo > 1;
            }
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return PageNo < this.PageCount;
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="datalist"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        public PagingUtil(List<T> datalist, int pageSize, int pageNo)
        {
            this.PageSize = pageSize;
            this.PageNo = pageNo;
            this.DataCount = datalist.Count;
            this.PageCount = (int)Math.Ceiling((decimal)this.DataCount / PageSize);
            this.AddRange(datalist.Skip((pageNo - 1) * PageSize).Take(PageSize));
        }
    }
}
