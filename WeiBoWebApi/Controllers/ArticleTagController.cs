using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.BLL;
using WeiBoWebApi.Model;
using System.Data;
using Newtonsoft.Json;

namespace WeiBoWebApi.Controllers
{
    /// <summary>
    /// 文章标签
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ArticleTagController : ControllerBase
    {
        private readonly ArticleTagBll _articleTagBll = new ArticleTagBll();

        /// <summary>
        /// 获取前n条热门标签
        /// </summary>
        [HttpGet("/tag")]
        public string GetHotTagTopN(int top) {
            return JsonConvert.SerializeObject( _articleTagBll.GetHotTagTopN(top));
        }
    }
}
