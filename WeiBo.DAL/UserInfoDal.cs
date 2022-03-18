
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.DAL
{
    
    public class UserInfoDal
    {
        //readonly  _dBContext = new WeiBoDBContext();

        /// <summary>
        /// 登录 成功返回用户信息，失败返回null
        /// </summary>
        public UserInfo Login(UserInfo userInfo)
        {

            string sql = string.Format("select * from UserInfo where account='{0}' and pwd='{1}'", userInfo.Account, userInfo.Pwd);
            DataTable dt = SqlHelper.GetTable(sql);
            UserInfo user = new UserInfo();
            if (dt.Rows[0][0] != null)
            {
                
                user.Uid =Convert.ToInt32( dt.Rows[0][0]);
                user.HeadPortrait = dt.Rows[0][1].ToString();
                user.Account = dt.Rows[0][2].ToString();
                user.NickName = dt.Rows[0][3].ToString();
                user.Name= dt.Rows[0][4].ToString();
                user.Pwd= dt.Rows[0][5].ToString();
                user.SexId = Convert.ToInt32(dt.Rows[0][6]);
                user.Birth = Convert.ToDateTime(dt.Rows[0][7]);
                user.Follow = Convert.ToInt32(dt.Rows[0][8]);
                user.Address = dt.Rows[0][9].ToString();
                user.IsDelete = Convert.ToBoolean(dt.Rows[0][10]);
                user.Token = (Guid?)dt.Rows[0][11];
                user.Overdue = Convert.ToDateTime(dt.Rows[0][12]);
            }
            return user;
        }

        /// <summary>
        /// 根据账号获取用户信息
        /// </summary>
        public UserInfo GetUserByAccount(string account)
        {
            string sql = string.Format("select * from UserInfo where account='{0}'",account);
            DataTable dt = SqlHelper.GetTable(sql);
            UserInfo user = new UserInfo();
            if (dt.Rows[0][0] != null)
            {

                user.Uid = Convert.ToInt32(dt.Rows[0][0]);
                user.HeadPortrait = dt.Rows[0][1].ToString();
                user.Account = dt.Rows[0][2].ToString();
                user.NickName = dt.Rows[0][3].ToString();
                user.Name = dt.Rows[0][4].ToString();
                user.Pwd = dt.Rows[0][5].ToString();
                user.SexId = Convert.ToInt32(dt.Rows[0][6]);
                user.Birth = Convert.ToDateTime(dt.Rows[0][7]);
                user.Follow = Convert.ToInt32(dt.Rows[0][8]);
                user.Address = dt.Rows[0][9].ToString();
                user.IsDelete = Convert.ToBoolean(dt.Rows[0][10]);
                user.Token = (Guid?)dt.Rows[0][11];
                user.Overdue = Convert.ToDateTime(dt.Rows[0][12]);
            }
            return user;
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        public int Add(UserInfo userInfo)
        {
            string sql = string.Format(@"insert into UserInfo values
     ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', {7}, '{8}', {9}, {10}, {11})", userInfo.HeadPortrait, userInfo.Account, userInfo.NickName, userInfo.Name, userInfo.Pwd, userInfo.SexId, userInfo.Birth, userInfo.Follow, userInfo.Address, userInfo.IsDelete, userInfo.Token, userInfo.Overdue);
            return SqlHelper.ExecuteNonQuery(sql);
        }
       

        /// <summary>
        /// 判断账号是否在数据库中存在
        /// </summary>
        public bool ExistsAccount(string account)
        {
            string sql = string.Format("select * from UserInfo where account='{0}'", account);
            DataTable dt = SqlHelper.GetTable(sql);
            if (dt.Rows[0][0]==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        public DataTable GetAllModel()
        {
            string sql = "select * from UserInfo";
            return SqlHelper.GetTable(sql);
        }
    }
}
