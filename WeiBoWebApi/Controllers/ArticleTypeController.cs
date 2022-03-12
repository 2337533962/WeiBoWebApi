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
    /// 文章类型
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ArticleTypeController : ControllerBase
    {
        /// <summary>
        /// 获取所有文章类型
        /// </summary>
        [HttpGet("/type/all")]
        public IEnumerable<ArticleType> GetAllTypes()
        {
            return new ArticleTypeBll().GetAllModel();
        }
    }
}
