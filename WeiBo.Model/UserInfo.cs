using System;
using System.Collections.Generic;

#nullable disable

namespace WeiBoWebApi.Model
{
    public class UserInfo
    {
        public int Uid { get; set; }
        public string HeadPortrait { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int? SexId { get; set; }
        public DateTime? Birth { get; set; }
        public int? Follow { get; set; }
        public string Address { get; set; }
        public bool? IsDelete { get; set; }
        public Guid? Token { get; set; }
        public DateTime? Overdue { get; set; }
    }
}
