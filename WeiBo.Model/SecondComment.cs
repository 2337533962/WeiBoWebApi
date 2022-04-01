using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public class SecondComment
    {
        public int Uid { get; set; }
        public int? CommentId { get; set; }
        public int SecondCommentId { get; set; }
        public string Content { get; set; }
        public DateTime? ContentTime { get; set; }
        public int? Fabulous { get; set; }
    }
}
