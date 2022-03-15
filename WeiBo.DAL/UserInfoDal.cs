using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class UserInfoDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 登录 成功返回用户信息，失败返回null
        /// </summary>
        public UserInfo Login(UserInfo userInfo)
        {
            UserInfo user = dBContext.UserInfos.FirstOrDefault(u => u.Account == userInfo.Account && u.Pwd == userInfo.Pwd);
            if (user != null)
            {
                user.Token = Guid.NewGuid();
                user.Overdue = DateTime.Now.AddSeconds(15);
                dBContext.Update(user);
                dBContext.SaveChanges();
            }
            return user;
        }

        /// <summary>
        /// 根据账号获取用户信息
        /// </summary>
        public UserInfo GetUserByAccount(string account)
        {
            return dBContext.UserInfos.Where(u => u.Account == account).FirstOrDefault();
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        public int Add(UserInfo userInfo)
        {
            dBContext.UserInfos.Add(userInfo);
            return dBContext.SaveChanges();
        }

        /// <summary>
        /// 判断账号是否在数据库中存在
        /// </summary>
        public bool ExistsAccount(string account)
        {
            return dBContext.UserInfos.Where(u => u.Account == account).ToList().Count > 0;
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        public IEnumerable<UserInfo> GetAllModel()
        {
            return dBContext.UserInfos.ToList();
        }
    }
}
