using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.DAL.Context
{
    public partial class ArticleTag
    {
        public ArticleTag()
        {
            ArticleInfos = new HashSet<ArticleInfo>();
        }

        public int TagId { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<ArticleInfo> ArticleInfos { get; set; }
    }
}
