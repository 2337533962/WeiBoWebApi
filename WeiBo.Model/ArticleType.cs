using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// ArticleType数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleType
    {
        /// <summary>
        /// 初始化ArticleType数据模型对象
        /// </summary>
        public ArticleType()
        {
            
        }
        /// <summary>
        /// 初始化ArticleType数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="typeId">typeId</param>
        public ArticleType(int typeId)
        {
            //给typeId字段赋值
            this.TypeId = typeId;
        }
        /// <summary>
        /// 初始化ArticleType数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="typeId">typeId</param>
        /// <param name="type">type</param>
        public ArticleType(int typeId,string type)
        {
            //给typeId字段赋值
            this.TypeId = typeId;
            //给type字段赋值
            this.Type = type;
        }
        
		//属性存储数据的变量
        private int _typeId;
        private string _type;
        
        /// <summary>
        /// typeId
        /// </summary>
        public int TypeId
        {
            get { return this._typeId; }
            set { this._typeId = value; }
        }
        /// <summary>
        /// type
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        
        /// <summary>
        /// 对比两个ArticleType数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的ArticleType数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成ArticleType数据模型对象
            ArticleType articleType = obj as ArticleType;
            //判断是否转换成功
            if (articleType == null) return false;
            //进行匹配属性的值
            return
                //判断typeId是否一致
                this.TypeId == articleType.TypeId &&
                //判断type是否一致
                this.Type == articleType.Type;
        }
        /// <summary>
        /// 将当前ArticleType数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将ArticleType数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将typeId进行按位异或运算处理
                this.TypeId.GetHashCode() ^
                //将type进行按位异或运算处理
                (this.Type == null ? 2147483647 : this.Type.GetHashCode());
        }
        /// <summary>
        /// 将当前ArticleType数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前ArticleType数据模型对象转换成字符串副本
            return
                "[" +
                //将typeId转换成字符串
                this.TypeId +
                "]";
        }
    }
}
