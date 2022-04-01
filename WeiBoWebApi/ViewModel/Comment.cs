using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.ViewModel
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 文章的id
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// 评论者id
        /// </summary>
        public int FromId { get; set; }
        /// <summary>
        /// 评论者昵称
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        /// 评论者头像
        /// </summary>
        public string FromAvatar { get; set; }
        /// <summary>
        /// 点赞人数
        /// </summary>
        public int LikeNum { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 回复，或子评论
        /// </summary>
        public string Reply { get; set; }
    }
}
