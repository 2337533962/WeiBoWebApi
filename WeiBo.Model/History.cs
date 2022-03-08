using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 历史推文表数据模型对象
    /// </summary>
    [Serializable]
    public partial class History
    {
        /// <summary>
        /// 初始化历史推文表数据模型对象
        /// </summary>
        public History()
        {
            
        }
        /// <summary>
        /// 初始化历史推文表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="articleId">历史文章Id</param>
        public History(int? uid,int? articleId)
        {
            //给用户Id字段赋值
            this.Uid = uid;
            //给历史文章Id字段赋值
            this.ArticleId = articleId;
        }
        
		//属性存储数据的变量
        private int? _uid;
        private int? _articleId;
        
        /// <summary>
        /// 用户Id
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// 历史文章Id
        /// </summary>
        public int? ArticleId
        {
            get { return this._articleId; }
            set { this._articleId = value; }
        }
        
        /// <summary>
        /// 对比两个历史推文表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的历史推文表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成历史推文表数据模型对象
            History history = obj as History;
            //判断是否转换成功
            if (history == null) return false;
            //进行匹配属性的值
            return
                //判断用户Id是否一致
                this.Uid == history.Uid &&
                //判断历史文章Id是否一致
                this.ArticleId == history.ArticleId;
        }
        /// <summary>
        /// 将当前历史推文表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将历史推文表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将用户Id进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将历史文章Id进行按位异或运算处理
                (this.ArticleId == null ? 2147483647 : this.ArticleId.GetHashCode());
        }
        /// <summary>
        /// 将当前历史推文表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前历史推文表数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
