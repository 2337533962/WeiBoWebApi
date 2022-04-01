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
    /// 性别
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SexController : ControllerBase
    {
        /// <summary>
        /// 获取所有性别信息
        /// </summary>
        [HttpGet("/sex/all")]
        public string GetAllSexInfo()
        {
            return JsonConvert.SerializeObject(OperResult.Succeed(new SexInfoBll().GetAllModel()));
        }

        /// <summary>
        /// 根据性别id获取性别值
        /// </summary>
        [HttpGet("/sex")]
        public string GetSexBySexId(int sexId)
        {
            return JsonConvert.SerializeObject(OperResult.Succeed(new SexInfoBll().GetSexInfoById(sexId)));
        }
    }
}
