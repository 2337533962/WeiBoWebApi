using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.DAL.Context
{
    public partial class AttentionInfo
    {
        public int? FollowId { get; set; }
        public int? FollowToId { get; set; }
    }
}
