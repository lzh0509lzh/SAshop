/*         
*│版权所有：Dream1993
*│创建人：Lee        
*/  
using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Fm.Entity{
	/// <summary>
    /// log：实体类
    /// </summary>
	[Serializable]
	public class log
	{   
      			private int _id;
		/// <summary>
		/// id
        /// </summary>
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
				private string _writer;
		/// <summary>
		/// 作者
        /// </summary>
        public string Writer
        {
            get{ return _writer; }
            set{ _writer = value; }
        }        
				private string _projectname;
		/// <summary>
		/// 项目名称
        /// </summary>
        public string ProjectName
        {
            get{ return _projectname; }
            set{ _projectname = value; }
        }        
				private string _content;
		/// <summary>
		/// 内容
        /// </summary>
        public string Content
        {
            get{ return _content; }
            set{ _content = value; }
        }        
				private string _createtime;
		/// <summary>
		/// 时间
        /// </summary>
        public string CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		   
	}
}