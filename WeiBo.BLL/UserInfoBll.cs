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
            userInfo.Pwd =new SHAEncryption().SHA1Encrypt(userInfo.Pwd);
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
            if (ExistsAccount(userInfo.Account)) return 0;
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
    }
}