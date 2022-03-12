using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public partial class ArticleComment
    {
        public ArticleComment()
        {
            SecondComments = new HashSet<SecondComment>();
        }

        public int? Uid { get; set; }
        public int? ArticleId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? ContentTime { get; set; }
        public int? Fabulous { get; set; }

        public virtual ArticleInfo Article { get; set; }
        public virtual UserInfo UidNavigation { get; set; }
        public virtual ICollection<SecondComment> SecondComments { get; set; }
    }
}
