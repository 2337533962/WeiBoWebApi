using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 作品图片表数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleImg
    {
        /// <summary>
        /// 初始化作品图片表数据模型对象
        /// </summary>
        public ArticleImg()
        {
            
        }
        /// <summary>
        /// 初始化作品图片表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="articleId">作品Id</param>
        /// <param name="imgUrl">图片路径</param>
        public ArticleImg(int? articleId,string imgUrl)
        {
            //给作品Id字段赋值
            this.ArticleId = articleId;
            //给图片路径字段赋值
            this.ImgUrl = imgUrl;
        }
        
		//属性存储数据的变量
        private int? _articleId;
        private string _imgUrl;
        
        /// <summary>
        /// 作品Id
        /// </summary>
        public int? ArticleId
        {
            get { return this._articleId; }
            set { this._articleId = value; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgUrl
        {
            get { return this._imgUrl; }
            set { this._imgUrl = value; }
        }
        
        /// <summary>
        /// 对比两个作品图片表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的作品图片表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成作品图片表数据模型对象
            ArticleImg articleImg = obj as ArticleImg;
            //判断是否转换成功
            if (articleImg == null) return false;
            //进行匹配属性的值
            return
                //判断作品Id是否一致
                this.ArticleId == articleImg.ArticleId &&
                //判断图片路径是否一致
                this.ImgUrl == articleImg.ImgUrl;
        }
        /// <summary>
        /// 将当前作品图片表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将作品图片表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将作品Id进行按位异或运算处理
                (this.ArticleId == null ? 2147483647 : this.ArticleId.GetHashCode()) ^
                //将图片路径进行按位异或运算处理
                (this.ImgUrl == null ? 2147483647 : this.ImgUrl.GetHashCode());
        }
        /// <summary>
        /// 将当前作品图片表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前作品图片表数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
