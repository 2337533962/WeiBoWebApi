using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// SecondComment数据模型对象
    /// </summary>
    [Serializable]
    public partial class SecondComment
    {
        /// <summary>
        /// 初始化SecondComment数据模型对象
        /// </summary>
        public SecondComment()
        {
            
        }
        /// <summary>
        /// 初始化SecondComment数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="secondCommentId">secondCommentId</param>
        public SecondComment(int secondCommentId)
        {
            //给secondCommentId字段赋值
            this.SecondCommentId = secondCommentId;
        }
        /// <summary>
        /// 初始化SecondComment数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="commentId">commentId</param>
        /// <param name="secondCommentId">secondCommentId</param>
        /// <param name="content">content</param>
        /// <param name="contentTime">contentTime</param>
        /// <param name="fabulous">fabulous</param>
        public SecondComment(int? commentId,int secondCommentId,string content,DateTime? contentTime,int? fabulous)
        {
            //给commentId字段赋值
            this.CommentId = commentId;
            //给secondCommentId字段赋值
            this.SecondCommentId = secondCommentId;
            //给content字段赋值
            this.Content = content;
            //给contentTime字段赋值
            this.ContentTime = contentTime;
            //给fabulous字段赋值
            this.Fabulous = fabulous;
        }
        
		//属性存储数据的变量
        private int? _commentId;
        private int _secondCommentId;
        private string _content;
        private DateTime? _contentTime;
        private int? _fabulous;
        
        /// <summary>
        /// commentId
        /// </summary>
        public int? CommentId
        {
            get { return this._commentId; }
            set { this._commentId = value; }
        }
        /// <summary>
        /// secondCommentId
        /// </summary>
        public int SecondCommentId
        {
            get { return this._secondCommentId; }
            set { this._secondCommentId = value; }
        }
        /// <summary>
        /// content
        /// </summary>
        public string Content
        {
            get { return this._content; }
            set { this._content = value; }
        }
        /// <summary>
        /// contentTime
        /// </summary>
        public DateTime? ContentTime
        {
            get { return this._contentTime; }
            set { this._contentTime = value; }
        }
        /// <summary>
        /// fabulous
        /// </summary>
        public int? Fabulous
        {
            get { return this._fabulous; }
            set { this._fabulous = value; }
        }
        
        /// <summary>
        /// 对比两个SecondComment数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的SecondComment数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成SecondComment数据模型对象
            SecondComment secondComment = obj as SecondComment;
            //判断是否转换成功
            if (secondComment == null) return false;
            //进行匹配属性的值
            return
                //判断commentId是否一致
                this.CommentId == secondComment.CommentId &&
                //判断secondCommentId是否一致
                this.SecondCommentId == secondComment.SecondCommentId &&
                //判断content是否一致
                this.Content == secondComment.Content &&
                //判断contentTime是否一致
                this.ContentTime == secondComment.ContentTime &&
                //判断fabulous是否一致
                this.Fabulous == secondComment.Fabulous;
        }
        /// <summary>
        /// 将当前SecondComment数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将SecondComment数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将commentId进行按位异或运算处理
                (this.CommentId == null ? 2147483647 : this.CommentId.GetHashCode()) ^
                //将secondCommentId进行按位异或运算处理
                this.SecondCommentId.GetHashCode() ^
                //将content进行按位异或运算处理
                (this.Content == null ? 2147483647 : this.Content.GetHashCode()) ^
                //将contentTime进行按位异或运算处理
                (this.ContentTime == null ? 2147483647 : this.ContentTime.GetHashCode()) ^
                //将fabulous进行按位异或运算处理
                (this.Fabulous == null ? 2147483647 : this.Fabulous.GetHashCode());
        }
        /// <summary>
        /// 将当前SecondComment数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前SecondComment数据模型对象转换成字符串副本
            return
                "[" +
                //将secondCommentId转换成字符串
                this.SecondCommentId +
                "]";
        }
    }
}
