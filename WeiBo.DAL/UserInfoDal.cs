using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    /// <summary>
    /// UserInfo数据访问对象
    /// </summary>
    public partial class UserInfoDal
    {
        /// <summary>
        /// 实例化UserInfo数据访问对象
        /// </summary>
        public UserInfoDal()
        {
            
        }
        /// <summary>
        /// 查询得到UserInfo表中所有信息
        /// </summary>
        /// <returns>查询到的所有UserInfo数据模型对象集合</returns>
        public List<UserInfo> GetAllModel()
        {
            //创建存储查找到的UserInfo表中信息集合
            List<UserInfo> list = new List<UserInfo>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select uid,headPortrait,account,nickName,name,pwd,sexId,birth,follow,address,isDelete,token From UserInfo;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个UserInfo数据模型对象
                        UserInfo userInfo = new UserInfo();
                        //存储查询到的uid数据
                        userInfo.Uid = sqlReader.GetInt32(0);
                        //存储查询到的headPortrait数据
                        userInfo.HeadPortrait = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //存储查询到的account数据
                        userInfo.Account = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的nickName数据
                        userInfo.NickName = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的name数据
                        userInfo.Name = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的pwd数据
                        userInfo.Pwd = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //存储查询到的sexId数据
                        userInfo.SexId = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                        //存储查询到的birth数据
                        userInfo.Birth = sqlReader.IsDBNull(7) ? null : (DateTime?)sqlReader.GetDateTime(7);
                        //存储查询到的follow数据
                        userInfo.Follow = sqlReader.IsDBNull(8) ? null : (int?)sqlReader.GetInt32(8);
                        //存储查询到的address数据
                        userInfo.Address = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                        //存储查询到的isDelete数据
                        userInfo.IsDelete = sqlReader.IsDBNull(10) ? null : (bool?)sqlReader.GetBoolean(10);
                        //存储查询到的token数据
                        userInfo.Token = sqlReader.IsDBNull(11) ? null : (Guid?)sqlReader.GetGuid(11);
                        //将UserInfo数据模型对象存储到集合中
                        list.Add(userInfo);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的UserInfo数据模型对象数据存入数据库，并将自动编号值存入，传入UserInfo数据模型对象中
        /// </summary>
        /// <param name="userInfo">要进行添加到数据库的UserInfo数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(UserInfo userInfo)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将headPortrait存入
                new SqlParameter("@headPortrait",SqlDbType.NVarChar,100){Value = userInfo.HeadPortrait ?? (object)DBNull.Value},
                //将account存入
                new SqlParameter("@account",SqlDbType.NVarChar,100){Value = userInfo.Account ?? (object)DBNull.Value},
                //将nickName存入
                new SqlParameter("@nickName",SqlDbType.NVarChar,100){Value = userInfo.NickName ?? (object)DBNull.Value},
                //将name存入
                new SqlParameter("@name",SqlDbType.NVarChar,100){Value = userInfo.Name ?? (object)DBNull.Value},
                //将pwd存入
                new SqlParameter("@pwd",SqlDbType.NVarChar,100){Value = userInfo.Pwd ?? (object)DBNull.Value},
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = userInfo.SexId ?? (object)DBNull.Value},
                //将birth存入
                new SqlParameter("@birth",SqlDbType.Date,20){Value = userInfo.Birth ?? (object)DBNull.Value},
                //将follow存入
                new SqlParameter("@follow",SqlDbType.Int,4){Value = userInfo.Follow ?? (object)DBNull.Value},
                //将address存入
                new SqlParameter("@address",SqlDbType.NVarChar,100){Value = userInfo.Address ?? (object)DBNull.Value},
                //将isDelete存入
                new SqlParameter("@isDelete",SqlDbType.Bit,1){Value = userInfo.IsDelete ?? (object)DBNull.Value},
                //将token存入
                new SqlParameter("@token",SqlDbType.UniqueIdentifier,16){Value = userInfo.Token ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Insert Into UserInfo(headPortrait,account,nickName,name,pwd,sexId,birth,follow,address,isDelete,token) OutPut Inserted.uid Values(@headPortrait,@account,@nickName,@name,@pwd,@sexId,@birth,@follow,@address,@isDelete,@token);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成uid
                    userInfo.Uid = sqlReader.GetInt32(0);
                    //返回添加成功
                    return true;
                }
                else
                {
                    //返回添加失败
                    return false;
                }
            }
        }
        /// <summary>
        /// 根据主键获取一条记录返回一个UserInfo数据模型对象
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns>如果查找到此记录就返回UserInfo数据模型对象，否则返回null</returns>
        public UserInfo GetModel(int uid)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将uid存入
                new SqlParameter("@uid",SqlDbType.Int,4){Value = uid}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select Top 1 uid,headPortrait,account,nickName,name,pwd,sexId,birth,follow,address,isDelete,token From UserInfo Where uid = @uid;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个UserInfo数据模型对象
                    UserInfo userInfo = new UserInfo();
                    //存储查询到的uid数据
                    userInfo.Uid = sqlReader.GetInt32(0);
                    //存储查询到的headPortrait数据
                    userInfo.HeadPortrait = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                    //存储查询到的account数据
                    userInfo.Account = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                    //存储查询到的nickName数据
                    userInfo.NickName = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                    //存储查询到的name数据
                    userInfo.Name = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                    //存储查询到的pwd数据
                    userInfo.Pwd = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                    //存储查询到的sexId数据
                    userInfo.SexId = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                    //存储查询到的birth数据
                    userInfo.Birth = sqlReader.IsDBNull(7) ? null : (DateTime?)sqlReader.GetDateTime(7);
                    //存储查询到的follow数据
                    userInfo.Follow = sqlReader.IsDBNull(8) ? null : (int?)sqlReader.GetInt32(8);
                    //存储查询到的address数据
                    userInfo.Address = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                    //存储查询到的isDelete数据
                    userInfo.IsDelete = sqlReader.IsDBNull(10) ? null : (bool?)sqlReader.GetBoolean(10);
                    //存储查询到的token数据
                    userInfo.Token = sqlReader.IsDBNull(11) ? null : (Guid?)sqlReader.GetGuid(11);
                    //将UserInfo数据模型对象返回
                    return userInfo;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int uid)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将uid存入
                new SqlParameter("@uid",SqlDbType.Int,4){Value = uid}
            };
            //执行一条按照uid删除记录语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery("Delete From UserInfo Where uid = @uid;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int uid)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@uid",SqlDbType.Int,4){Value = uid}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From UserInfo Where uid = @uid;", sqlParameters) > 0;
        }
        /// <summary>
        /// 根据account获取一条记录
        /// </summary>
        /// <param name="account">account</param>
        /// <returns>如果查找到此记录就返回UserInfo数据模型对象，否则返回null</returns>
        public UserInfo GetAccountCorrespondingModel(string account)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将account存入
                new SqlParameter("@account",SqlDbType.NVarChar,100){Value = account ?? (object)DBNull.Value}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select Top 1 uid,headPortrait,account,nickName,name,pwd,sexId,birth,follow,address,isDelete,token From UserInfo Where account = @account;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个UserInfo数据模型对象
                    UserInfo userInfo = new UserInfo();
                    //存储查询到的uid数据
                    userInfo.Uid = sqlReader.GetInt32(0);
                    //存储查询到的headPortrait数据
                    userInfo.HeadPortrait = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                    //存储查询到的account数据
                    userInfo.Account = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                    //存储查询到的nickName数据
                    userInfo.NickName = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                    //存储查询到的name数据
                    userInfo.Name = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                    //存储查询到的pwd数据
                    userInfo.Pwd = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                    //存储查询到的sexId数据
                    userInfo.SexId = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                    //存储查询到的birth数据
                    userInfo.Birth = sqlReader.IsDBNull(7) ? null : (DateTime?)sqlReader.GetDateTime(7);
                    //存储查询到的follow数据
                    userInfo.Follow = sqlReader.IsDBNull(8) ? null : (int?)sqlReader.GetInt32(8);
                    //存储查询到的address数据
                    userInfo.Address = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                    //存储查询到的isDelete数据
                    userInfo.IsDelete = sqlReader.IsDBNull(10) ? null : (bool?)sqlReader.GetBoolean(10);
                    //存储查询到的token数据
                    userInfo.Token = sqlReader.IsDBNull(11) ? null : (Guid?)sqlReader.GetGuid(11);
                    //将UserInfo数据模型对象返回
                    return userInfo;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 删除account所对应的一条记录
        /// </summary>
        /// <param name="account">account</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool DeleteAccountCorrespondingTakeNotes(string account)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将account存入
                new SqlParameter("@account",SqlDbType.NVarChar,100){Value = account ?? (object)DBNull.Value}
            };
            //执行一条按照account删除记录语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery("Delete From UserInfo Where account = @account;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否存在此account对应的记录
        /// </summary>
        /// <param name="account">account</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool ExistsThisAccount(string account)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@account",SqlDbType.NVarChar,100){Value = account ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From UserInfo Where account = @account;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="userInfo">UserInfo</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(UserInfo userInfo)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将uid存入
                new SqlParameter("@uid",SqlDbType.Int,4){Value = userInfo.Uid},
                //将headPortrait存入
                new SqlParameter("@headPortrait",SqlDbType.NVarChar,100){Value = userInfo.HeadPortrait ?? (object)DBNull.Value},
                //将account存入
                new SqlParameter("@account",SqlDbType.NVarChar,100){Value = userInfo.Account ?? (object)DBNull.Value},
                //将nickName存入
                new SqlParameter("@nickName",SqlDbType.NVarChar,100){Value = userInfo.NickName ?? (object)DBNull.Value},
                //将name存入
                new SqlParameter("@name",SqlDbType.NVarChar,100){Value = userInfo.Name ?? (object)DBNull.Value},
                //将pwd存入
                new SqlParameter("@pwd",SqlDbType.NVarChar,100){Value = userInfo.Pwd ?? (object)DBNull.Value},
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = userInfo.SexId ?? (object)DBNull.Value},
                //将birth存入
                new SqlParameter("@birth",SqlDbType.Date,20){Value = userInfo.Birth ?? (object)DBNull.Value},
                //将follow存入
                new SqlParameter("@follow",SqlDbType.Int,4){Value = userInfo.Follow ?? (object)DBNull.Value},
                //将address存入
                new SqlParameter("@address",SqlDbType.NVarChar,100){Value = userInfo.Address ?? (object)DBNull.Value},
                //将isDelete存入
                new SqlParameter("@isDelete",SqlDbType.Bit,1){Value = userInfo.IsDelete ?? (object)DBNull.Value},
                //将token存入
                new SqlParameter("@token",SqlDbType.UniqueIdentifier,16){Value = userInfo.Token ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return SqlDataBase.ExecuteNonQuery("Update UserInfo Set headPortrait = @headPortrait,account = @account,nickName = @nickName,name = @name,pwd = @pwd,sexId = @sexId,birth = @birth,follow = @follow,address = @address,isDelete = @isDelete,token = @token Where uid = @uid;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="userInfo">验证的UserInfo数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(UserInfo userInfo)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将uid存入
                new SqlParameter("@uid",SqlDbType.Int,4){Value = userInfo.Uid},
                //将headPortrait存入
                new SqlParameter("@headPortrait",SqlDbType.NVarChar,100){Value = userInfo.HeadPortrait ?? (object)DBNull.Value},
                //将account存入
                new SqlParameter("@account",SqlDbType.NVarChar,100){Value = userInfo.Account ?? (object)DBNull.Value},
                //将nickName存入
                new SqlParameter("@nickName",SqlDbType.NVarChar,100){Value = userInfo.NickName ?? (object)DBNull.Value},
                //将name存入
                new SqlParameter("@name",SqlDbType.NVarChar,100){Value = userInfo.Name ?? (object)DBNull.Value},
                //将pwd存入
                new SqlParameter("@pwd",SqlDbType.NVarChar,100){Value = userInfo.Pwd ?? (object)DBNull.Value},
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = userInfo.SexId ?? (object)DBNull.Value},
                //将birth存入
                new SqlParameter("@birth",SqlDbType.Date,20){Value = userInfo.Birth ?? (object)DBNull.Value},
                //将follow存入
                new SqlParameter("@follow",SqlDbType.Int,4){Value = userInfo.Follow ?? (object)DBNull.Value},
                //将address存入
                new SqlParameter("@address",SqlDbType.NVarChar,100){Value = userInfo.Address ?? (object)DBNull.Value},
                //将isDelete存入
                new SqlParameter("@isDelete",SqlDbType.Bit,1){Value = userInfo.IsDelete ?? (object)DBNull.Value},
                //将token存入
                new SqlParameter("@token",SqlDbType.UniqueIdentifier,16){Value = userInfo.Token ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From UserInfo Where uid = @uid And headPortrait = @headPortrait And account = @account And nickName = @nickName And name = @name And pwd = @pwd And sexId = @sexId And birth = @birth And follow = @follow And address = @address And isDelete = @isDelete And token = @token;", sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>
        /// <param name="sqlParameters">SQL参数对象</param>
        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>
        public bool Exists(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Count(*) From UserInfo;"
                    : "Select Count(*) From UserInfo Where " + where;
            //返回执行完成所得到的数据集合数量并判断是否有超过一条？
            return (int)SqlDataBase.ExecuteScalar(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义删除【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>是否删除成功，为true成功，为false失败</returns>
        public bool Delete(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Delete From UserInfo;"
                    : "Delete From UserInfo Where " + where;
            //执行删除语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<UserInfo> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<UserInfo> list = new List<UserInfo>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select uid,headPortrait,account,nickName,name,pwd,sexId,birth,follow,address,isDelete,token From UserInfo;"
                    : "Select uid,headPortrait,account,nickName,name,pwd,sexId,birth,follow,address,isDelete,token From UserInfo Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个UserInfo数据模型对象
                        UserInfo userInfo = new UserInfo();
                        //存储查询到的uid数据
                        userInfo.Uid = sqlReader.GetInt32(0);
                        //存储查询到的headPortrait数据
                        userInfo.HeadPortrait = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //存储查询到的account数据
                        userInfo.Account = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的nickName数据
                        userInfo.NickName = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的name数据
                        userInfo.Name = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的pwd数据
                        userInfo.Pwd = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //存储查询到的sexId数据
                        userInfo.SexId = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                        //存储查询到的birth数据
                        userInfo.Birth = sqlReader.IsDBNull(7) ? null : (DateTime?)sqlReader.GetDateTime(7);
                        //存储查询到的follow数据
                        userInfo.Follow = sqlReader.IsDBNull(8) ? null : (int?)sqlReader.GetInt32(8);
                        //存储查询到的address数据
                        userInfo.Address = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                        //存储查询到的isDelete数据
                        userInfo.IsDelete = sqlReader.IsDBNull(10) ? null : (bool?)sqlReader.GetBoolean(10);
                        //存储查询到的token数据
                        userInfo.Token = sqlReader.IsDBNull(11) ? null : (Guid?)sqlReader.GetGuid(11);
                        //将UserInfo数据模型对象存储到集合中
                        list.Add(userInfo);
                    }
                }
            }
            //返回查找到的UserInfo对象的集合
            return list;
        }
        /// <summary>
        /// 自定义查询出匹配记录有多少条【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>匹配记录数量</returns>
        public int GetCount(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Count(*) From UserInfo;"
                    : "Select Count(*) From UserInfo Where " + where;
            //返回执行完成所得到的数据集合
            return (int)SqlDataBase.ExecuteScalar(sql, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="startIndex">开始索引【从零开始】</param>
        /// <param name="endIndex">结束索引【包括当前索引指向记录】</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的UserInfo数据模型对象集合</returns>
        public List<UserInfo> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储UserInfo数据模型对象的集合
            List<UserInfo> list = new List<UserInfo>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From UserInfo) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From UserInfo Where " +
                    //将条件存入内查询，而非外查询！！！
                    where +
                    ") As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() + ";";
            //执行查找语句
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个UserInfo数据模型对象
                        UserInfo userInfo = new UserInfo();
                        //存储查询到的uid数据
                        userInfo.Uid = sqlReader.GetInt32(0);
                        //存储查询到的headPortrait数据
                        userInfo.HeadPortrait = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //存储查询到的account数据
                        userInfo.Account = sqlReader.IsDBNull(2) ? null : (string)sqlReader.GetString(2);
                        //存储查询到的nickName数据
                        userInfo.NickName = sqlReader.IsDBNull(3) ? null : (string)sqlReader.GetString(3);
                        //存储查询到的name数据
                        userInfo.Name = sqlReader.IsDBNull(4) ? null : (string)sqlReader.GetString(4);
                        //存储查询到的pwd数据
                        userInfo.Pwd = sqlReader.IsDBNull(5) ? null : (string)sqlReader.GetString(5);
                        //存储查询到的sexId数据
                        userInfo.SexId = sqlReader.IsDBNull(6) ? null : (int?)sqlReader.GetInt32(6);
                        //存储查询到的birth数据
                        userInfo.Birth = sqlReader.IsDBNull(7) ? null : (DateTime?)sqlReader.GetDateTime(7);
                        //存储查询到的follow数据
                        userInfo.Follow = sqlReader.IsDBNull(8) ? null : (int?)sqlReader.GetInt32(8);
                        //存储查询到的address数据
                        userInfo.Address = sqlReader.IsDBNull(9) ? null : (string)sqlReader.GetString(9);
                        //存储查询到的isDelete数据
                        userInfo.IsDelete = sqlReader.IsDBNull(10) ? null : (bool?)sqlReader.GetBoolean(10);
                        //存储查询到的token数据
                        userInfo.Token = sqlReader.IsDBNull(11) ? null : (Guid?)sqlReader.GetGuid(11);
                        //将UserInfo数据模型对象存储到集合中
                        list.Add(userInfo);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的UserInfo数据模型对象集合</returns>
        public List<UserInfo> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
        {
            //得到开始索引
            int beginIndex = pageIndex * pageItemCount;
            //得到结束索引
            int endIndex = (beginIndex + pageItemCount) - 1;
            //调用分页获取数据方法并返回结果
            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="allItmeCount">总共有多少条记录</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的UserInfo数据模型对象集合</returns>
        public List<UserInfo> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
        {
            //得到总记录条数
            allItmeCount = this.GetCount(where, SqlDataBase.CopySqlParameters(sqlParameters));
            //得到开始索引
            int beginIndex = pageIndex * pageItemCount;
            //得到结束索引
            int endIndex = (beginIndex + pageItemCount) - 1;
            //调用分页获取数据方法并返回结果
            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);
        }
    }
}
