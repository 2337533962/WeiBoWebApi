using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly AttentionInfoBll _attentionInfoBll = new AttentionInfoBll();

        /// <summary>
        /// 根据用户Id获取ta关注的信息
        /// </summary>
        [HttpGet("/follow/list")]
        public object GetFollows(int uid)
        {
            return JsonConvert.SerializeObject(_attentionInfoBll.GetFollowsByUid(uid));
        }

        /// <summary>
        /// 根据用户Id获取ta关注的数量
        /// </summary>
        [HttpGet("/follow/count")]
        public int GetFollowCount(int uid)
        {
            return _attentionInfoBll.GetFollowCountByUid(uid);
        }

        /// <summary>
        /// 根据用户Id获取ta粉丝的信息
        /// </summary>
        [HttpGet("/fans/list")]
        public object GetFans(int uid)
        {
            return JsonConvert.SerializeObject(_attentionInfoBll.GetFansByUid(uid));
        }

        /// <summary>
        /// 根据用户Id获取ta粉丝的数量
        /// </summary>
        [HttpGet("/fans/count")]
        public int GetFansCount(int uid)
        {
            return _attentionInfoBll.GetFansCountByUid(uid);
        }


        /// <summary>
        /// 新增关注
        /// </summary>
        [HttpPost("/follow")]
        public string Add(AttentionInfo attentionInfo)
        {
            if (_attentionInfoBll.Add(attentionInfo) > 0)
                return JsonConvert.SerializeObject(OperResult.Succeed("新增成功!"));
            return JsonConvert.SerializeObject(OperResult.Succeed("新增失败!"));
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        [HttpDelete("/follow")]
        public string Remove(AttentionInfo attentionInfo) {
            if (_attentionInfoBll.Remove(attentionInfo) > 0)
                return JsonConvert.SerializeObject(OperResult.Succeed("操作成功!"));
            return JsonConvert.SerializeObject(OperResult.Succeed("操作失败!"));
        }
    }
}
