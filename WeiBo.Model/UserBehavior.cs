using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public partial class UserBehavior
    {
        public int? Uid { get; set; }
        public int? Behavior { get; set; }

        public virtual UserInfo UidNavigation { get; set; }
        public virtual ArticleTag BehaviorNavigation { get; set; }
    }
}
