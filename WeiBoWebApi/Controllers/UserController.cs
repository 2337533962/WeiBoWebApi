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
        private readonly UserInfoBll _userInfoBll = new UserInfoBll();

        /// <summary>
        /// 注册用户
        /// </summary>
        [HttpPost("/registe")]
        public string Registe(UserRegisteOrLogin user)
        {
            UserInfo userInfo = new UserInfo
            {
                Account = user.Account,
                Pwd = user.Password
            };
            if (_userInfoBll.Add(userInfo) > 0)
                return JsonConvert.SerializeObject(
                    OperResult.Succeed("注册成功！")
                );
            return JsonConvert.SerializeObject(
                OperResult.Failed("账号已存在！")
            );
        }

        /// <summary>
        /// 使用账号密码登录
        /// </summary>
        [HttpPost("/login")]
        public string Login(UserRegisteOrLogin user)
        {
            UserInfo userInfo = new UserInfo()
            {
                Account = user.Account,
                Pwd = user.Password
            };
            UserInfo info = _userInfoBll.Login(userInfo);
            if (info == null)
                return JsonConvert.SerializeObject(
                    OperResult.Failed("账号或密码有误！")
                );
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
            return JsonConvert.SerializeObject(
                OperResult.Succeed(basicInfo)
            );
        }

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        [HttpGet("/user/id")]
        public string GetUserInfoById(int id)
        {
            return JsonConvert.SerializeObject(
                OperResult.Succeed(
                    _userInfoBll.GetUserInfoById(id)
                    )
                );
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        [HttpPut("/user/edit")]
        public string UserEdit(UserEdit userEdit)
        {
            UserInfo info = new UserInfo
            {
                Uid = userEdit.Uid,
                Address = userEdit.Address,
                Birth = userEdit.Birth,
                HeadPortrait = userEdit.HeadPortrait,
                Name = userEdit.Name,
                NickName = userEdit.NickName,
                Pwd = userEdit.Pwd,
                SexId = userEdit.SexId
            };
            if (_userInfoBll.Update(info) > 0)
                return JsonConvert.SerializeObject(
                    OperResult.Succeed("修改成功!")
                );
            return JsonConvert.SerializeObject(
                OperResult.Failed("修改失败!")
            );
        }

        /// <summary>
        /// 获取所有用户信息(仅供测试使用)
        /// </summary>
        [HttpGet("/user/all")]
        public object GetAllUsers()
        {
            return JsonConvert.SerializeObject(
                OperResult.Succeed(
                    _userInfoBll.GetAllModel()
                    )
                );
        }

        /// <summary>
        /// 根据账号获取指定用户信息(仅供测试使用)
        /// </summary>
        [HttpGet("/user/account")]
        public string GetUserByAccount(string account)
        {
            return JsonConvert.SerializeObject(
                OperResult.Succeed(
                    _userInfoBll.GetUserByAccount(account)
                    )
                );
        }
    }
}
