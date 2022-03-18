using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.ViewModel
{
    /// <summary>
    /// 修改用户
    /// </summary>
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class UserEdit
    {
        public int Uid { get; set; }
        public string HeadPortrait { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int? SexId { get; set; }
        public DateTime? Birth { get; set; }
        public string Address { get; set; }
    }
}
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
