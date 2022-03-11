using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.DAL.Context
{
    public partial class SexInfo
    {
        public SexInfo()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public int SexId { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
