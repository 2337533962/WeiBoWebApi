using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using WeiBoWebApi.BLL;
using WeiBoWebApi.ViewModel;
using WeiBoWebApi.Commons;

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
        public IEnumerable<UserInfo> GetAllUsers()
        {
            return new UserInfoBll().GetAllModel();
        }

        /// <summary>
        /// 根据账号获取指定用户信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("/user/s")]
        public object GetUserByAccount(string a)
        {
            UserInfoBll userInfoBll = new UserInfoBll();
            if (userInfoBll.ExistsThisAccount(a))
            {
                return userInfoBll.GetAccountCorrespondingModel(a);
            }
            return null;

        }

        /// <summary>
        /// 注册用户
        /// </summary>
        [HttpPost("/user/i")]
        public object RegisteUser(UserRegiste userRegiste)
        {
            if (string.IsNullOrEmpty(userRegiste.Account))
                return OperResult.Failed("账号不能为空！");
            if (string.IsNullOrEmpty(userRegiste.Password))
                return OperResult.Failed("密码不能为空！");
            UserInfoBll userInfoBll = new UserInfoBll();
            if (!userInfoBll.ExistsThisAccount(userRegiste.Account))
            {
                UserInfo userInfo = new UserInfo
                {
                    Account = userRegiste.Account,
                    Pwd = new SHAEncryption().SHA1Encrypt(userRegiste.Password),
                    Follow = 0,
                    IsDelete = false,
                    NickName = "用户" + new Random().Next(5000000, 10000000).ToString("X"),
                    SexId = 3
                };
                if (userInfoBll.Add(userInfo))
                    return OperResult.Succeed();
            }
            return OperResult.Failed("账号已存在！");

        }

        /// <summary>
        /// 根据用户Id获取ta关注的信息
        /// </summary>
        [HttpGet("/follow/list/s")]
        public IEnumerable<AttentionInfo> GetAttentionInfos(int uid)
        {
            return new AttentionInfoBll().GetModelList("followId=@uid",
                new System.Data.SqlClient.SqlParameter("uid", uid));
        }

        /// <summary>
        /// 根据用户Id获取ta关注的数量
        /// </summary>
        [HttpGet("/follow/s")]
        public int GetFollowNum(int uid)
        {
            return new AttentionInfoBll().GetModelList("followId=@uid",
                new System.Data.SqlClient.SqlParameter("uid", uid)).Count;
        }

        /// <summary>
        /// 根据用户Id获取ta粉丝的信息
        /// </summary>
        [HttpGet("/fans/list/s")]
        public IEnumerable<AttentionInfo> GetFansList(int uid)
        {
            return new AttentionInfoBll().GetModelList("followToId=@uid",
                new System.Data.SqlClient.SqlParameter("uid", uid));
        }

        /// <summary>
        /// 根据用户Id获取ta粉丝的数量
        /// </summary>
        [HttpGet("/fans/s")]
        public int GetFansCount(int uid)
        {
            return new AttentionInfoBll().GetModelList("followToId=@uid",
                new System.Data.SqlClient.SqlParameter("uid", uid)).Count;
        }

    }
}
