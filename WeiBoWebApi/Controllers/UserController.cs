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
        /// 获取所有性别信息
        /// </summary>
        [HttpGet("/sex/all")]
        public IEnumerable<SexInfo> GetAllSexInfo()
        {
            return new SexInfoBll().GetAllModel();
        }

        /// <summary>
        /// 根据性别id获取性别值
        /// </summary>
        [HttpGet("/sex")]
        public object GetSexBySexId(int sexId) {
            return new SexInfoBll().GetModel(sexId);
        }

        /// <summary>
        /// 根据用户Id获取ta关注的信息
        /// </summary>
        [HttpGet("/follow/list/s")]
        public IEnumerable<AttentionInfo> GetAttentionInfos(int uid) {
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
