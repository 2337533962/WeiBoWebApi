
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace WeiBoWebApi.DAL
{

    public class UserInfoDal
    {
        /// <summary>
        /// 登录 成功返回用户信息，失败返回null
        /// </summary>
        public UserInfo Login(UserInfo userInfo)
        {

            string sql = string.Format("select * from UserInfo where account='{0}' and pwd='{1}'", userInfo.Account, userInfo.Pwd);
            DataTable dt = SqlHelper.GetTable(sql);
            UserInfo user = null;
            if (dt.Rows.Count > 0)
            {
                user = new UserInfo();
                user.Uid = SqlHelper.FromDBValue<int>(SqlHelper.FromDBValue(dt.Rows[0][0]) ?? 0);
                user.HeadPortrait = SqlHelper.FromDBValue(dt.Rows[0][1])?.ToString();

                //user.Birth = (DateTime)(SqlHelper.FromDBValue(dt.Rows[0][7]) ?? "1970-01-01");
                //user.Account = dt.Rows[0][2]?.ToString();

                // 所有从数据库拿到的数据请都使用FromDBValue<T>获取
                user.Birth = SqlHelper.FromDBValue<DateTime?>(dt.Rows[0][7]);
                user.Account = SqlHelper.FromDBValue<string>(dt.Rows[0][2]);



                user.NickName = dt.Rows[0][3]?.ToString();
                user.Name = dt.Rows[0][4]?.ToString();
                user.Pwd = dt.Rows[0][5]?.ToString();
                user.SexId = SqlHelper.FromDBValue<int>(dt.Rows[0][6] ?? 0);
                user.Follow = SqlHelper.FromDBValue<int>(dt.Rows[0][8] ?? 0);
                user.Address = dt.Rows[0][9]?.ToString();
                user.IsDelete = Convert.ToBoolean(dt.Rows[0][10] ?? false);
                user.Overdue = DateTime.Now.AddSeconds(15);
            }
            if (user!=null)
            {
                user.Token = UpdateToken(user.Uid);
            }
            
            return user;
        }

        /// <summary>
        /// 根据账号获取用户信息
        /// </summary>
        public UserInfo GetUserByAccount(string account)
        {
            string sql = string.Format("select * from UserInfo where account='{0}'", account);
            DataTable dt = SqlHelper.GetTable(sql);
            UserInfo user = null;
            if (dt.Rows.Count > 0)
            {
                user = new UserInfo();
                user.Uid = SqlHelper.FromDBValue<int>(dt.Rows[0][0]);
                user.HeadPortrait = SqlHelper.FromDBValue<string>(dt.Rows[0][1]);
                user.Account = SqlHelper.FromDBValue<string>(dt.Rows[0][2]);
                user.NickName = SqlHelper.FromDBValue<string>(dt.Rows[0][3]);
                user.Name = SqlHelper.FromDBValue<string>(dt.Rows[0][4]);
                user.Pwd = SqlHelper.FromDBValue<string>(dt.Rows[0][5]);
                user.SexId = SqlHelper.FromDBValue<int>(dt.Rows[0][6]);
                user.Birth = SqlHelper.FromDBValue<DateTime?>(dt.Rows[0][7]);
                user.Follow = SqlHelper.FromDBValue<int>(dt.Rows[0][8]);
                user.Address = SqlHelper.FromDBValue<string>(dt.Rows[0][9]);
                user.IsDelete = SqlHelper.FromDBValue<bool>(dt.Rows[0][10]);
                user.Token = SqlHelper.FromDBValue<Guid?>(dt.Rows[0][11]);
                user.Overdue = SqlHelper.FromDBValue<DateTime?>(dt.Rows[0][12]);
            }
            return user;
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        public int Add(UserInfo userInfo)
        {
            string sql = string.Format(@"insert into UserInfo values
     ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", userInfo.HeadPortrait, userInfo.Account, userInfo.NickName, userInfo.Name, userInfo.Pwd, userInfo.SexId, userInfo.Birth, userInfo.Follow, userInfo.Address, userInfo.IsDelete, Guid.NewGuid(), userInfo.Overdue);
            return SqlHelper.ExecuteNonQuery(sql);
        }


        /// <summary>
        /// 判断账号是否在数据库中存在
        /// </summary>
        public bool ExistsAccount(string account)
        {
            string sql = string.Format("select * from UserInfo where account='{0}'", account);
            SqlDataReader reader = SqlHelper.GetReader(sql);
            if (reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        public DataTable GetAllModel()
        {
            string sql = "select * from UserInfo";
            return SqlHelper.GetTable(sql);
        }

        /// <summary>
        /// 更新用户信息,Id包含在对象中，返回受影响行数
        /// </summary>
        public int Update(UserInfo info)
        {
            string sql = @"UPDATE [dbo].[UserInfo]
   SET[headPortrait] = @headPortrait
      ,[nickName] = @nickName
      ,[name] = @name
      ,[pwd] = @pwd
      ,[sexId] = @sexId
      ,[birth] = @birth
      ,[address] = @address
 WHERE uid = @uid";
            SqlParameter[] ps = new SqlParameter[] {
                new SqlParameter("headPortrait",info.HeadPortrait),
                new SqlParameter("nickName",info.NickName),
                new SqlParameter("name",info.Name),
                new SqlParameter("pwd",info.Pwd),
                new SqlParameter("sexId",info.SexId),
                new SqlParameter("birth",info.Birth),
                new SqlParameter("address",info.Address),
                new SqlParameter("uid",info.Uid)
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 登录的重载，根据验证token是否存在和是否过期，不存在和过期返回null，没过期返回对象
        /// </summary>
        public UserInfo Login(string token)
        {
            string sql = string.Format("select * from UserInfo where token='{0}' and overdue>GETDATE()", token);
            SqlDataReader reader = SqlHelper.GetReader(sql);
            UserInfo userInfo = null;
            if (reader.Read())
            {
                userInfo = new UserInfo
                {
                    Uid = SqlHelper.FromDBValue<int>(reader["Uid"]),
                    HeadPortrait = SqlHelper.FromDBValue<string>(reader["HeadPortrait"]),
                    Account = SqlHelper.FromDBValue<string>(reader["Account"]),
                    NickName = SqlHelper.FromDBValue<string>(reader["NickName"]),
                    Name = SqlHelper.FromDBValue<string>(reader["Name"]),
                    Pwd = SqlHelper.FromDBValue<string>(reader["Pwd"]),
                    SexId = SqlHelper.FromDBValue<int>(reader["SexId"]),
                    Birth = SqlHelper.FromDBValue<DateTime?>(reader["Birth"]),
                    Follow = SqlHelper.FromDBValue<int>(reader["Follow"]),
                    Address = SqlHelper.FromDBValue<string>(reader["Address"]),
                    IsDelete = SqlHelper.FromDBValue<bool>(reader["IsDelete"]),
                    Token = SqlHelper.FromDBValue<Guid?>(reader["Token"])
                    //Overdue = SqlHelper.FromDBValue<DateTime?>(reader["Overdue"]),
                };
                // 更新Token有效时间
                sql = "update UserInfo set overdue=DATEADD(mi,15,GETDATE()) where uid=@Uid";
                SqlHelper.ExecuteNonQuery(sql, new SqlParameter("Uid", userInfo.Uid));

            }

            return userInfo;
        }
        private Guid UpdateToken(int uid)
        {
            string sql = "update UserInfo set token=@token,overdue=DATEADD(mi,15,GETDATE()) where uid=@uid";
            Guid guid = Guid.NewGuid();
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("token", guid), new SqlParameter("uid", uid));
            return guid;
        }

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        public DataTable GetUserInfoById(int id)
        {
            string sql = @"SELECT  dbo.UserInfo.*, dbo.SexInfo.sex
FROM      dbo.UserInfo INNER JOIN
                   dbo.SexInfo ON dbo.UserInfo.sexId = dbo.SexInfo.sexId
				   where uid=@uid";
            return SqlHelper.GetTable(sql, new SqlParameter("uid", id));
        }

        /// <summary>
        /// 验证Token是否有效,有效返回uid，不存在或过期返回null
        /// </summary>
        public int? TokenValid(string token)
        {
            string sql = "select uid from UserInfo where token=@token and overdue>GETDATE()";
            return (int?)SqlHelper.ExecuteScalar(sql, new SqlParameter("token", token));
        }
    }


}
