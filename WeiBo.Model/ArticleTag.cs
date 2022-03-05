using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// ArticleTag数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleTag
    {
        /// <summary>
        /// 初始化ArticleTag数据模型对象
        /// </summary>
        public ArticleTag()
        {
            
        }
        /// <summary>
        /// 初始化ArticleTag数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="tagId">tagId</param>
        public ArticleTag(int tagId)
        {
            //给tagId字段赋值
            this.TagId = tagId;
        }
        /// <summary>
        /// 初始化ArticleTag数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="tagId">tagId</param>
        /// <param name="tag">tag</param>
        public ArticleTag(int tagId,string tag)
        {
            //给tagId字段赋值
            this.TagId = tagId;
            //给tag字段赋值
            this.Tag = tag;
        }
        
		//属性存储数据的变量
        private int _tagId;
        private string _tag;
        
        /// <summary>
        /// tagId
        /// </summary>
        public int TagId
        {
            get { return this._tagId; }
            set { this._tagId = value; }
        }
        /// <summary>
        /// tag
        /// </summary>
        public string Tag
        {
            get { return this._tag; }
            set { this._tag = value; }
        }
        
        /// <summary>
        /// 对比两个ArticleTag数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的ArticleTag数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成ArticleTag数据模型对象
            ArticleTag articleTag = obj as ArticleTag;
            //判断是否转换成功
            if (articleTag == null) return false;
            //进行匹配属性的值
            return
                //判断tagId是否一致
                this.TagId == articleTag.TagId &&
                //判断tag是否一致
                this.Tag == articleTag.Tag;
        }
        /// <summary>
        /// 将当前ArticleTag数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将ArticleTag数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将tagId进行按位异或运算处理
                this.TagId.GetHashCode() ^
                //将tag进行按位异或运算处理
                (this.Tag == null ? 2147483647 : this.Tag.GetHashCode());
        }
        /// <summary>
        /// 将当前ArticleTag数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前ArticleTag数据模型对象转换成字符串副本
            return
                "[" +
                //将tagId转换成字符串
                this.TagId +
                "]";
        }
    }
}
