using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 作品评论表数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleComment
    {
        /// <summary>
        /// 初始化作品评论表数据模型对象
        /// </summary>
        public ArticleComment()
        {
            
        }
        /// <summary>
        /// 初始化作品评论表数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="commentId">评论Id</param>
        public ArticleComment(int commentId)
        {
            //给评论Id字段赋值
            this.CommentId = commentId;
        }
        /// <summary>
        /// 初始化作品评论表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="articleId">作品Id</param>
        /// <param name="commentId">评论Id</param>
        /// <param name="content">评论内容</param>
        /// <param name="contentTime">评论时间</param>
        /// <param name="fabulous">点赞</param>
        public ArticleComment(int? uid,int? articleId,int commentId,string content,DateTime? contentTime,int? fabulous)
        {
            //给用户Id字段赋值
            this.Uid = uid;
            //给作品Id字段赋值
            this.ArticleId = articleId;
            //给评论Id字段赋值
            this.CommentId = commentId;
            //给评论内容字段赋值
            this.Content = content;
            //给评论时间字段赋值
            this.ContentTime = contentTime;
            //给点赞字段赋值
            this.Fabulous = fabulous;
        }
        
		//属性存储数据的变量
        private int? _uid;
        private int? _articleId;
        private int _commentId;
        private string _content;
        private DateTime? _contentTime;
        private int? _fabulous;
        
        /// <summary>
        /// 用户Id
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// 作品Id
        /// </summary>
        public int? ArticleId
        {
            get { return this._articleId; }
            set { this._articleId = value; }
        }
        /// <summary>
        /// 评论Id
        /// </summary>
        public int CommentId
        {
            get { return this._commentId; }
            set { this._commentId = value; }
        }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content
        {
            get { return this._content; }
            set { this._content = value; }
        }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? ContentTime
        {
            get { return this._contentTime; }
            set { this._contentTime = value; }
        }
        /// <summary>
        /// 点赞
        /// </summary>
        public int? Fabulous
        {
            get { return this._fabulous; }
            set { this._fabulous = value; }
        }
        
        /// <summary>
        /// 对比两个作品评论表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的作品评论表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成作品评论表数据模型对象
            ArticleComment articleComment = obj as ArticleComment;
            //判断是否转换成功
            if (articleComment == null) return false;
            //进行匹配属性的值
            return
                //判断用户Id是否一致
                this.Uid == articleComment.Uid &&
                //判断作品Id是否一致
                this.ArticleId == articleComment.ArticleId &&
                //判断评论Id是否一致
                this.CommentId == articleComment.CommentId &&
                //判断评论内容是否一致
                this.Content == articleComment.Content &&
                //判断评论时间是否一致
                this.ContentTime == articleComment.ContentTime &&
                //判断点赞是否一致
                this.Fabulous == articleComment.Fabulous;
        }
        /// <summary>
        /// 将当前作品评论表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将作品评论表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将用户Id进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将作品Id进行按位异或运算处理
                (this.ArticleId == null ? 2147483647 : this.ArticleId.GetHashCode()) ^
                //将评论Id进行按位异或运算处理
                this.CommentId.GetHashCode() ^
                //将评论内容进行按位异或运算处理
                (this.Content == null ? 2147483647 : this.Content.GetHashCode()) ^
                //将评论时间进行按位异或运算处理
                (this.ContentTime == null ? 2147483647 : this.ContentTime.GetHashCode()) ^
                //将点赞进行按位异或运算处理
                (this.Fabulous == null ? 2147483647 : this.Fabulous.GetHashCode());
        }
        /// <summary>
        /// 将当前作品评论表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前作品评论表数据模型对象转换成字符串副本
            return
                "[" +
                //将评论Id转换成字符串
                this.CommentId +
                "]";
        }
    }
}
