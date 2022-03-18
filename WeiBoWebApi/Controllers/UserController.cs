using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using WeiBoWebApi.BLL;
using WeiBoWebApi.ViewModel;
using Newtonsoft.Json;

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
        /// 注册用户
        /// </summary>
        [HttpPost("/user/registe")]
        public object Registe(UserRegisteOrLogin user)
        {
            if (string.IsNullOrEmpty(user.Account))
                return OperResult.Failed("账号不能为空！");
            if (string.IsNullOrEmpty(user.Password))
                return OperResult.Failed("密码不能为空！");

            UserInfoBll userInfoBll = new UserInfoBll();
            UserInfo userInfo = new UserInfo
            {
                Account = user.Account,
                Pwd = user.Password
            };

            if (userInfoBll.Add(userInfo) > 0)
                return OperResult.Succeed("注册成功！");
            return OperResult.Failed("账号已存在！");

        }

        /// <summary>
        /// 登录
        /// </summary>
        [HttpPost("/user/login")]
        public object Login(UserRegisteOrLogin user)
        {
            if (string.IsNullOrEmpty(user.Account))
                return OperResult.Failed("账号不能为空！");
            if (string.IsNullOrEmpty(user.Password))
                return OperResult.Failed("密码不能为空！");
            UserInfo userInfo = new UserInfo()
            {
                Account = user.Account,
                Pwd = user.Password
            };
            UserInfo info = new UserInfoBll().Login(userInfo);
            if (info == null) return OperResult.Failed("账号或密码有误！");
            UserBasicInfo basicInfo = new UserBasicInfo
            {
                Uid = (int)info.Uid,
                Account = info.Account,
                Address = info.Address,
                Birth = info.Birth,
                HeadPortrait = info.HeadPortrait,
                Name = info.Name,
                NickName = info.NickName,
                Sex = new SexInfoBll().GetSexInfoById((int)info.SexId).Sex,
                Token = info.Token.ToString(),
                Fans = new AttentionInfoBll().GetFansCountByUid(info.Uid),
                Follow = new AttentionInfoBll().GetFollowCountByUid(info.Uid)
            };
            return OperResult.Succeed(basicInfo);
        }


        //[HttpPost("/user/edit")]
        //public object UserEdit(UserEdit userEdit)
        //{
        //    UserInfo info = new UserInfo
        //    {
        //        Uid = userEdit.Uid,
        //        Address = userEdit.Address,
        //        Birth = userEdit.Birth,
        //        HeadPortrait = userEdit.HeadPortrait,
        //        Name = userEdit.Name,
        //        NickName = userEdit.NickName,
        //        Pwd = userEdit.Pwd,
        //        SexId = userEdit.SexId
        //    };

        //}

        /// <summary>
        /// 获取所有用户信息(仅供测试使用)
        /// </summary>
        [HttpGet("/user/all")]
        public object GetAllUsers()
        {
            return JsonConvert.SerializeObject(new UserInfoBll().GetAllModel());
        }

        /// <summary>
        /// 根据账号获取指定用户信息(仅供测试使用)
        /// </summary>
        [HttpGet("/user/{account}")]
        public object GetUserByAccount(string account)
        {
            return new UserInfoBll().GetUserByAccount(account);
        }
    }
}
