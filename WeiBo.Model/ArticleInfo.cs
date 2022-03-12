using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public partial class ArticleInfo
    {
        public ArticleInfo()
        {
            ArticleComments = new HashSet<ArticleComment>();
        }

        public int? Uid { get; set; }
        public int ArticleId { get; set; }
        public string UserEquipment { get; set; }
        public string Content { get; set; }
        public int? TagId { get; set; }
        public int? PermissionId { get; set; }
        public int? Forward { get; set; }
        public int? Fabulous { get; set; }
        public DateTime? ReleaseTime { get; set; }

        public virtual ArticlePermission Permission { get; set; }
        public virtual ArticleTag Tag { get; set; }
        public virtual UserInfo UidNavigation { get; set; }
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    }
}
