using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.ViewModel
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    public class UserBasicInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth { get; set; }
        /// <summary>
        /// 关注
        /// </summary>
        public int? Follow { get; set; }
        /// <summary>
        /// 粉丝
        /// </summary>
        public int? Fans { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
    }
}
