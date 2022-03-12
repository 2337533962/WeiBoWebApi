using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public partial class ArticleImg
    {
        public int? ArticleId { get; set; }
        public string ImgUrl { get; set; }

        public virtual ArticleInfo Article { get; set; }
    }
}
