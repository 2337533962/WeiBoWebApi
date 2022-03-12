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
    /// 收藏
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CollectController : ControllerBase
    {

        /// <summary>
        /// 新增收藏
        /// </summary>
        [HttpPost("/collectInfo")]
        public object AddCollectInfo(CollectInfo collectInfo)
        {
            if (new CollectInfoBll().Add(collectInfo)>0)
                return OperResult.Succeed();
            return OperResult.Failed("新增收藏失败!");
        }

        /// <summary>
        /// 根据用户的id获取用户的收藏集合
        /// </summary>
        [HttpGet("/collectInfo")]
        public IEnumerable<CollectInfo> GetCollectInfosByUid(int uid)
        {
            return new CollectInfoBll().GetCollectsByUid(uid);
        }
    }
}
