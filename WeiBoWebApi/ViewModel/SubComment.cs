using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.ViewModel
{
    /// <summary>
    /// 二级评论
    /// </summary>
    public class SubComment :Comment
    {
        /// <summary>
        /// 父评论id，即父亲的id
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// 被评论者id
        /// </summary>
        public int ToId { get; set; }
        /// <summary>
        /// 被评论者昵称
        /// </summary>
        public string ToName { get; set; }
        /// <summary>
        /// 被评论者头像
        /// </summary>
        public string ToAvatar { get; set; }
    }
}
