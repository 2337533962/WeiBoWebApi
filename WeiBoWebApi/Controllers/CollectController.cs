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
    /// 收藏
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CollectController : ControllerBase
    {
        private readonly CollectInfoBll _collectInfoBll = new CollectInfoBll();
        private readonly UserInfoBll _userInfoBll = new UserInfoBll();

        /// <summary>
        /// 根据用户的id获取用户的收藏集合
        /// </summary>
        [HttpGet("/collectInfo")]
        public string GetCollectInfosByUid(int id)
        {
            return JsonConvert.SerializeObject(OperResult.Succeed(_collectInfoBll.GetCollectsByUid(id)));
        }
        /// <summary>
        /// 新增收藏
        /// </summary>
        [HttpPost("/collectInfo")]
        public string Add(string token, int articleId)
        {
            //获取uid
            int? uid = _userInfoBll.TokenValid(token);
            if (uid == null) return JsonConvert.SerializeObject(OperResult.Failed("token已失效!"));
            if (_collectInfoBll.Add(uid, articleId) > 0)
                return JsonConvert.SerializeObject(OperResult.Succeed("操作成功!"));
            return JsonConvert.SerializeObject(OperResult.Failed("操作失败!"));
        }

        /// <summary>
        /// 移除收藏
        /// </summary>
        [HttpDelete("/collectInfo")]
        public string Remove(string token, int articleId)
        {
            int? uid = _userInfoBll.TokenValid(token);
            if (uid == null) return JsonConvert.SerializeObject(OperResult.Failed("token已失效!"));
            if (_collectInfoBll.Remove(uid, articleId) > 0)
                return JsonConvert.SerializeObject(OperResult.Succeed("操作成功!"));
            return JsonConvert.SerializeObject(OperResult.Failed("操作失败!"));
        }

    }
}
