using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public partial class ArticleVideo
    {
        public int? ArticleId { get; set; }
        public string VideoUrl { get; set; }

        public virtual ArticleInfo Article { get; set; }
    }
}
