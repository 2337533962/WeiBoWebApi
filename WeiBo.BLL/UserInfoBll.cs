using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Commons;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.BLL
{
    public class UserInfoBll
    {
        private readonly UserInfoDal _userInfoDal = new UserInfoDal();

        public UserInfo Login(UserInfo userInfo)
        {
            userInfo.Pwd = new SHAEncryption().SHA1Encrypt(userInfo.Pwd);
            return _userInfoDal.Login(userInfo);
        }

        public DataTable GetAllModel()
        {
            return _userInfoDal.GetAllModel();
        }

        public bool ExistsAccount(string account)
        {
            return _userInfoDal.ExistsAccount(account);
        }

        public int Add(UserInfo userInfo)
        {
            if (ExistsAccount(userInfo.Account)) { return 0; }
            userInfo.Pwd = new SHAEncryption().SHA1Encrypt(userInfo.Pwd);
            userInfo.Follow = 0;
            userInfo.IsDelete = false;
            userInfo.NickName = "用户" + new Random().Next(5000000, 10000000).ToString("X");
            userInfo.SexId = 3;
            return _userInfoDal.Add(userInfo);
        }

        public UserInfo GetUserByAccount(string account)
        {
            return _userInfoDal.GetUserByAccount(account);
        }

        /// <summary>
        /// 更新用户信息,Id包含在对象中，返回受影响行数
        /// </summary>
        public int Update(UserInfo info)
        {
            return _userInfoDal.Update(info);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 登录的重载，根据验证token是否存在和是否过期，不存在和过期返回null，没过期返回对象
        /// </summary>
        public UserInfo Login(string token)
        {
            return _userInfoDal.Login(token);
            //throw new NotImplementedException();

            // 登陆成功过期时间也要加15或30分钟！
        }
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        public DataTable GetUserInfoById(int id)
        {
            return _userInfoDal.GetUserInfoById(id);
        }

        /// <summary>
        /// 验证Token是否有效,有效返回uid，不存在或过期返回null
        /// </summary>
        public int? TokenValid(string token) {
            return _userInfoDal.TokenValid(token);
        }
    }
}