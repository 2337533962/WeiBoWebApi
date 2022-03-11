using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.DAL.Context
{
    public partial class UserBehavior
    {
        public int? Uid { get; set; }
        public int? UserBehavior1 { get; set; }

        public virtual UserInfo UidNavigation { get; set; }
        public virtual ArticleTag UserBehavior1Navigation { get; set; }
    }
}
