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
    /// 文章控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns>文章列表</returns>
        [HttpGet("/rticle/all")]
        public IEnumerable<ArticleInfo> GetArticleInfos()
        {
            return new ArticleInfoBll().GetAllModel();
        }

        /// <summary>
        /// 获取所有文章类型
        /// </summary>
        /// <returns>文章类型列表</returns>
        [HttpGet("/type/all")]
        public IEnumerable<ArticleType> GetArticleTypes()
        {
            return new ArticleTypeBll().GetAllModel();
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="articleInfo"></param>
        /// <returns>结果，Succeed或Failed</returns>
        [HttpPost("/rticle/i")]
        public object Insert(ArticleInfo articleInfo)
        {
            bool r = new ArticleInfoBll().Add(articleInfo);
            if (r)
                return OperResult.Succeed();
            return OperResult.Failed("添加失败!");
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        [HttpPut("/rticle/u")]
        public object Update(ArticleInfo articleInfo)
        {
            return OperResult.Failed("还没有做，你别急！");
        }

        /// <summary>
        /// 新增历史推文
        /// </summary>
        [HttpPost("/history/i")]
        public object AddHistory(History history)
        {
            if (new HistoryBll().Add(history))
                return OperResult.Succeed();
            return OperResult.Failed("历史推文添加失败!");
        }

        /// <summary>
        /// 根据Id获取用户的历史文章（可以做历史浏览）
        /// </summary>
        [HttpGet("/history/s")]
        public IEnumerable<History> GetHistoriesByUid(int uid)
        {
            return new HistoryBll().GetAllModel().FindAll(h => h.Uid == uid);
        }

        /// <summary>
        /// 新增用户行为
        /// </summary>
        [HttpPost("/behavior/i")]
        public object AddUserBehavior(UserBehavior userBehavior)
        {
            if (new UserBehaviorBll().Add(userBehavior))
                return OperResult.Succeed();
            return OperResult.Failed("新增行为失败!");
        }

        /// <summary>
        /// 新增收藏
        /// </summary>
        [HttpPost("/collectInfo/i")]
        public object AddCollectInfo(CollectInfo collectInfo)
        {
            if (new CollectInfoBll().Add(collectInfo))
                return OperResult.Succeed();
            return OperResult.Failed("新增收藏失败!");
        }

        /// <summary>
        /// 根据用户的id获取用户的收藏集合
        /// </summary>
        [HttpGet("/collectInfo/s")]
        public IEnumerable<CollectInfo> GetCollectInfosByUid(int uid)
        {
            return new CollectInfoBll().GetAllModel().FindAll(c => c.Uid == uid);
        }
    }
}
