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
    /// ArticlePermission数据访问对象
    /// </summary>
    public partial class ArticlePermissionDal
    {
        /// <summary>
        /// 实例化ArticlePermission数据访问对象
        /// </summary>
        public ArticlePermissionDal()
        {
            
        }
        /// <summary>
        /// 查询得到ArticlePermission表中所有信息
        /// </summary>
        /// <returns>查询到的所有ArticlePermission数据模型对象集合</returns>
        public List<ArticlePermission> GetAllModel()
        {
            //创建存储查找到的ArticlePermission表中信息集合
            List<ArticlePermission> list = new List<ArticlePermission>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select permissionId,permission From ArticlePermission;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个ArticlePermission数据模型对象
                        ArticlePermission articlePermission = new ArticlePermission();
                        //存储查询到的permissionId数据
                        articlePermission.PermissionId = sqlReader.GetInt32(0);
                        //存储查询到的permission数据
                        articlePermission.Permission = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将ArticlePermission数据模型对象存储到集合中
                        list.Add(articlePermission);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的ArticlePermission数据模型对象数据存入数据库，并将自动编号值存入，传入ArticlePermission数据模型对象中
        /// </summary>
        /// <param name="articlePermission">要进行添加到数据库的ArticlePermission数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(ArticlePermission articlePermission)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将permission存入
                new SqlParameter("@permission",SqlDbType.NVarChar,40){Value = articlePermission.Permission ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Insert Into ArticlePermission(permission) OutPut Inserted.permissionId Values(@permission);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成permissionId
                    articlePermission.PermissionId = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个ArticlePermission数据模型对象
        /// </summary>
        /// <param name="permissionId">permissionId</param>
        /// <returns>如果查找到此记录就返回ArticlePermission数据模型对象，否则返回null</returns>
        public ArticlePermission GetModel(int permissionId)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将permissionId存入
                new SqlParameter("@permissionId",SqlDbType.Int,4){Value = permissionId}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select Top 1 permissionId,permission From ArticlePermission Where permissionId = @permissionId;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个ArticlePermission数据模型对象
                    ArticlePermission articlePermission = new ArticlePermission();
                    //存储查询到的permissionId数据
                    articlePermission.PermissionId = sqlReader.GetInt32(0);
                    //存储查询到的permission数据
                    articlePermission.Permission = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                    //将ArticlePermission数据模型对象返回
                    return articlePermission;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="permissionId">permissionId</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int permissionId)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将permissionId存入
                new SqlParameter("@permissionId",SqlDbType.Int,4){Value = permissionId}
            };
            //执行一条按照permissionId删除记录语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery("Delete From ArticlePermission Where permissionId = @permissionId;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="permissionId">permissionId</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int permissionId)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@permissionId",SqlDbType.Int,4){Value = permissionId}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From ArticlePermission Where permissionId = @permissionId;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="articlePermission">ArticlePermission</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(ArticlePermission articlePermission)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将permissionId存入
                new SqlParameter("@permissionId",SqlDbType.Int,4){Value = articlePermission.PermissionId},
                //将permission存入
                new SqlParameter("@permission",SqlDbType.NVarChar,40){Value = articlePermission.Permission ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return SqlDataBase.ExecuteNonQuery("Update ArticlePermission Set permission = @permission Where permissionId = @permissionId;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="articlePermission">验证的ArticlePermission数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(ArticlePermission articlePermission)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将permissionId存入
                new SqlParameter("@permissionId",SqlDbType.Int,4){Value = articlePermission.PermissionId},
                //将permission存入
                new SqlParameter("@permission",SqlDbType.NVarChar,40){Value = articlePermission.Permission ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From ArticlePermission Where permissionId = @permissionId And permission = @permission;", sqlParameters) > 0;
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
                    ? "Select Count(*) From ArticlePermission;"
                    : "Select Count(*) From ArticlePermission Where " + where;
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
                    ? "Delete From ArticlePermission;"
                    : "Delete From ArticlePermission Where " + where;
            //执行删除语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<ArticlePermission> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<ArticlePermission> list = new List<ArticlePermission>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select permissionId,permission From ArticlePermission;"
                    : "Select permissionId,permission From ArticlePermission Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个ArticlePermission数据模型对象
                        ArticlePermission articlePermission = new ArticlePermission();
                        //存储查询到的permissionId数据
                        articlePermission.PermissionId = sqlReader.GetInt32(0);
                        //存储查询到的permission数据
                        articlePermission.Permission = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将ArticlePermission数据模型对象存储到集合中
                        list.Add(articlePermission);
                    }
                }
            }
            //返回查找到的ArticlePermission对象的集合
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
                    ? "Select Count(*) From ArticlePermission;"
                    : "Select Count(*) From ArticlePermission Where " + where;
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
        /// <returns>查询到的ArticlePermission数据模型对象集合</returns>
        public List<ArticlePermission> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储ArticlePermission数据模型对象的集合
            List<ArticlePermission> list = new List<ArticlePermission>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From ArticlePermission) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From ArticlePermission Where " +
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
                        //创建一个ArticlePermission数据模型对象
                        ArticlePermission articlePermission = new ArticlePermission();
                        //存储查询到的permissionId数据
                        articlePermission.PermissionId = sqlReader.GetInt32(0);
                        //存储查询到的permission数据
                        articlePermission.Permission = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将ArticlePermission数据模型对象存储到集合中
                        list.Add(articlePermission);
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
        /// <returns>查询到的ArticlePermission数据模型对象集合</returns>
        public List<ArticlePermission> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的ArticlePermission数据模型对象集合</returns>
        public List<ArticlePermission> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
