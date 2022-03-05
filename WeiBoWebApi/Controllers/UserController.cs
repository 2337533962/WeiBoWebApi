using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using WeiBoWebApi.BLL;
namespace WeiBoWebApi.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        [HttpGet("/user/all")]
        public IEnumerable<UserInfo> GetUsers()
        {
            return new UserInfoBll().GetAllModel();
        }

        /// <summary>
        /// 根据账号获取指定用户信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("/user/account")]
        public object GetUserByAccount(string a)
        {
            UserInfoBll userInfoBll = new UserInfoBll();
            if (userInfoBll.ExistsThisAccount(a))
            {
                return userInfoBll.GetAccountCorrespondingModel(a);
            }
            return null;

        }


    }
}
