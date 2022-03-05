using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// CollectInfo数据模型对象
    /// </summary>
    [Serializable]
    public partial class CollectInfo
    {
        /// <summary>
        /// 初始化CollectInfo数据模型对象
        /// </summary>
        public CollectInfo()
        {
            
        }
        /// <summary>
        /// 初始化CollectInfo数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="articleId">articleId</param>
        public CollectInfo(int? uid,int? articleId)
        {
            //给uid字段赋值
            this.Uid = uid;
            //给articleId字段赋值
            this.ArticleId = articleId;
        }
        
		//属性存储数据的变量
        private int? _uid;
        private int? _articleId;
        
        /// <summary>
        /// uid
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// articleId
        /// </summary>
        public int? ArticleId
        {
            get { return this._articleId; }
            set { this._articleId = value; }
        }
        
        /// <summary>
        /// 对比两个CollectInfo数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的CollectInfo数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成CollectInfo数据模型对象
            CollectInfo collectInfo = obj as CollectInfo;
            //判断是否转换成功
            if (collectInfo == null) return false;
            //进行匹配属性的值
            return
                //判断uid是否一致
                this.Uid == collectInfo.Uid &&
                //判断articleId是否一致
                this.ArticleId == collectInfo.ArticleId;
        }
        /// <summary>
        /// 将当前CollectInfo数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将CollectInfo数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将uid进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将articleId进行按位异或运算处理
                (this.ArticleId == null ? 2147483647 : this.ArticleId.GetHashCode());
        }
        /// <summary>
        /// 将当前CollectInfo数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前CollectInfo数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
