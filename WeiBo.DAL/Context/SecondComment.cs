using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.DAL.Context
{
    public partial class SecondComment
    {
        public int? CommentId { get; set; }
        public int SecondCommentId { get; set; }
        public string Content { get; set; }
        public DateTime? ContentTime { get; set; }
        public int? Fabulous { get; set; }

        public virtual ArticleComment Comment { get; set; }
    }
}
