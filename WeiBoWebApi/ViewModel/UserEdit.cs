using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.ViewModel
{
    /// <summary>
    /// 修改用户
    /// </summary>
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
