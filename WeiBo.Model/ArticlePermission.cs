using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public partial class ArticlePermission
    {
        public ArticlePermission()
        {
            ArticleInfos = new HashSet<ArticleInfo>();
        }

        public int PermissionId { get; set; }
        public string Permission { get; set; }

        public virtual ICollection<ArticleInfo> ArticleInfos { get; set; }
    }
}
