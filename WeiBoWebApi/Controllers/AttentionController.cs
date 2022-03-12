using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.BLL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.Controllers
{
    /// <summary>
    /// 用户关注和粉丝
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AttentionController : ControllerBase
    {
        /// <summary>
        /// 根据用户Id获取ta关注的信息
        /// </summary>
        [HttpGet("/follow/list")]
        public IEnumerable<AttentionInfo> GetFollows(int uid)
        {
            return new AttentionInfoBll().GetFollowsByUid(uid);
        }

        /// <summary>
        /// 根据用户Id获取ta关注的数量
        /// </summary>
        [HttpGet("/follow/count")]
        public int GetFollowCount(int uid)
        {
            return new AttentionInfoBll().GetFollowCountByUid(uid);
        }

        /// <summary>
        /// 根据用户Id获取ta粉丝的信息
        /// </summary>
        [HttpGet("/fans/list")]
        public IEnumerable<AttentionInfo> GetFans(int uid)
        {
            return new AttentionInfoBll().GetFansByUid(uid);
        }

        /// <summary>
        /// 根据用户Id获取ta粉丝的数量
        /// </summary>
        [HttpGet("/fans/s")]
        public int GetFansCount(int uid)
        {
            return new AttentionInfoBll().GetFansCountByUid(uid);
        }
    }
}
