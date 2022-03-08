using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 二级评论表数据模型对象
    /// </summary>
    [Serializable]
    public partial class SecondComment
    {
        /// <summary>
        /// 初始化二级评论表数据模型对象
        /// </summary>
        public SecondComment()
        {
            
        }
        /// <summary>
        /// 初始化二级评论表数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="secondCommentId">二级评论Id</param>
        public SecondComment(int secondCommentId)
        {
            //给二级评论Id字段赋值
            this.SecondCommentId = secondCommentId;
        }
        /// <summary>
        /// 初始化二级评论表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="commentId">一级评论Id</param>
        /// <param name="secondCommentId">二级评论Id</param>
        /// <param name="content">内容</param>
        /// <param name="contentTime">评论时间</param>
        /// <param name="fabulous">点赞</param>
        public SecondComment(int? commentId,int secondCommentId,string content,DateTime? contentTime,int? fabulous)
        {
            //给一级评论Id字段赋值
            this.CommentId = commentId;
            //给二级评论Id字段赋值
            this.SecondCommentId = secondCommentId;
            //给内容字段赋值
            this.Content = content;
            //给评论时间字段赋值
            this.ContentTime = contentTime;
            //给点赞字段赋值
            this.Fabulous = fabulous;
        }
        
		//属性存储数据的变量
        private int? _commentId;
        private int _secondCommentId;
        private string _content;
        private DateTime? _contentTime;
        private int? _fabulous;
        
        /// <summary>
        /// 一级评论Id
        /// </summary>
        public int? CommentId
        {
            get { return this._commentId; }
            set { this._commentId = value; }
        }
        /// <summary>
        /// 二级评论Id
        /// </summary>
        public int SecondCommentId
        {
            get { return this._secondCommentId; }
            set { this._secondCommentId = value; }
        }
        /// <summary>
        /// 内容
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
        /// 对比两个二级评论表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的二级评论表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成二级评论表数据模型对象
            SecondComment secondComment = obj as SecondComment;
            //判断是否转换成功
            if (secondComment == null) return false;
            //进行匹配属性的值
            return
                //判断一级评论Id是否一致
                this.CommentId == secondComment.CommentId &&
                //判断二级评论Id是否一致
                this.SecondCommentId == secondComment.SecondCommentId &&
                //判断内容是否一致
                this.Content == secondComment.Content &&
                //判断评论时间是否一致
                this.ContentTime == secondComment.ContentTime &&
                //判断点赞是否一致
                this.Fabulous == secondComment.Fabulous;
        }
        /// <summary>
        /// 将当前二级评论表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将二级评论表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将一级评论Id进行按位异或运算处理
                (this.CommentId == null ? 2147483647 : this.CommentId.GetHashCode()) ^
                //将二级评论Id进行按位异或运算处理
                this.SecondCommentId.GetHashCode() ^
                //将内容进行按位异或运算处理
                (this.Content == null ? 2147483647 : this.Content.GetHashCode()) ^
                //将评论时间进行按位异或运算处理
                (this.ContentTime == null ? 2147483647 : this.ContentTime.GetHashCode()) ^
                //将点赞进行按位异或运算处理
                (this.Fabulous == null ? 2147483647 : this.Fabulous.GetHashCode());
        }
        /// <summary>
        /// 将当前二级评论表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前二级评论表数据模型对象转换成字符串副本
            return
                "[" +
                //将二级评论Id转换成字符串
                this.SecondCommentId +
                "]";
        }
    }
}
