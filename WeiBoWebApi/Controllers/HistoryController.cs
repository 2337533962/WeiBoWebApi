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
        private readonly HistoryBll _historyBll = new HistoryBll();

        /// <summary>
        /// 新增历史推文
        /// </summary>
        [HttpPost("/history")]
        public string AddHistory(History history)
        {
            if (_historyBll.Add(history) > 0)
                return JsonConvert.SerializeObject(OperResult.Succeed("添加成功!"));
            return JsonConvert.SerializeObject(OperResult.Failed("历史推文添加失败!"));
        }

        /// <summary>
        /// 根据Id获取用户的历史文章（可以做历史浏览）
        /// </summary>
        [HttpGet("/history")]
        public string GetHistoriesByUid(int uid)
        {
            return JsonConvert.SerializeObject(OperResult.Succeed(_historyBll.GetHistoriesByUid(uid)));
        }
    }
}
