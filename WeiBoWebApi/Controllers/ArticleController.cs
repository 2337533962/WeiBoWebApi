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
        [HttpPost("/rticle/insert")]
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
        /// <param name="articleInfo"></param>
        /// <returns></returns>
        [HttpGet]
        public object Update(ArticleInfo articleInfo) {
            return OperResult.Failed("还没有做，你别急！");
        }
    }
}
