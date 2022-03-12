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
    /// 用户行为
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserBehaviorController : ControllerBase
    {

        /// <summary>
        /// 新增用户行为
        /// </summary>
        [HttpPost("/behavior")]
        public object AddUserBehavior(UserBehavior userBehavior)
        {
            if (new UserBehaviorBll().Add(userBehavior) > 0)
                return OperResult.Succeed();
            return OperResult.Failed("新增行为失败!");
        }

    }
}
