using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
* 所有响应类 必须派生于 响应基类，
* 自建响应类 命名规则：DataResponse_表名
* 列表类 命名规则 DataList_表名
*/
namespace Fm.Entity
{
    /// <summary>
    ///基类--响应类 
    /// </summary>
    [Serializable]
    public class BaseDataResponse
    {
        private bool _Result;
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        private string _Msg;
        /// <summary>
        /// 提示信息
        /// </summary>	
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }
    }

    /// <summary>
    ///基类--响应类 -分页
    /// </summary>
    [Serializable]
    public class BaseDataResponseByPage
    {
        private bool _Result;
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        private string _Msg;
        /// <summary>
        /// 提示信息
        /// </summary>	
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }
        
        private int _pageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
            }
        }

        
        private int _recordCount;
        /// <summary>
        /// 记录数
        /// </summary>
        public int recordCount
        {
            get
            {
                return _recordCount;
            }
            set
            {
                _recordCount = value;
            }
        }


    }

    #region 命名示例
    /// <summary>
    /// 自建响应类
    /// </summary>
    [Serializable]
    public class DataResponse_TableName
    {
        public List<DataList_TableName> list { get; set; }
    }
    /// <summary>
    /// 列表类
    /// </summary>
    [Serializable]
    public class DataList_TableName { }
    #endregion
}
