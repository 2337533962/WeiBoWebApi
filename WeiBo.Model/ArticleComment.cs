using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public  class ArticleComment
    {
        public int? Uid { get; set; }
        public int? ArticleId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? ContentTime { get; set; }
        public int? Fabulous { get; set; }
    }
}
