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
    /// 历史文章
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {

        /// <summary>
        /// 新增历史推文
        /// </summary>
        [HttpPost("/history/i")]
        public object AddHistory(History history)
        {
            if (new HistoryBll().Add(history) > 0)
                return OperResult.Succeed();
            return OperResult.Failed("历史推文添加失败!");
        }

        /// <summary>
        /// 根据Id获取用户的历史文章（可以做历史浏览）
        /// </summary>
        [HttpGet("/history/s")]
        public object GetHistoriesByUid(int uid)
        {
            return JsonConvert.SerializeObject(new HistoryBll().GetHistoriesByUid(uid));
        }
    }
}
