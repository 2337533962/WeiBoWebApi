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
    /// SexInfo数据访问对象
    /// </summary>
    public partial class SexInfoDal
    {
        /// <summary>
        /// 实例化SexInfo数据访问对象
        /// </summary>
        public SexInfoDal()
        {
            
        }
        /// <summary>
        /// 查询得到SexInfo表中所有信息
        /// </summary>
        /// <returns>查询到的所有SexInfo数据模型对象集合</returns>
        public List<SexInfo> GetAllModel()
        {
            //创建存储查找到的SexInfo表中信息集合
            List<SexInfo> list = new List<SexInfo>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select sexId,sex From SexInfo;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个SexInfo数据模型对象
                        SexInfo sexInfo = new SexInfo();
                        //存储查询到的sexId数据
                        sexInfo.SexId = sqlReader.GetInt32(0);
                        //存储查询到的sex数据
                        sexInfo.Sex = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将SexInfo数据模型对象存储到集合中
                        list.Add(sexInfo);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的SexInfo数据模型对象数据存入数据库，并将自动编号值存入，传入SexInfo数据模型对象中
        /// </summary>
        /// <param name="sexInfo">要进行添加到数据库的SexInfo数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(SexInfo sexInfo)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将sex存入
                new SqlParameter("@sex",SqlDbType.NVarChar,20){Value = sexInfo.Sex ?? (object)DBNull.Value}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Insert Into SexInfo(sex) OutPut Inserted.sexId Values(@sex);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成sexId
                    sexInfo.SexId = sqlReader.GetInt32(0);
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
        /// 根据主键获取一条记录返回一个SexInfo数据模型对象
        /// </summary>
        /// <param name="sexId">sexId</param>
        /// <returns>如果查找到此记录就返回SexInfo数据模型对象，否则返回null</returns>
        public SexInfo GetModel(int sexId)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = sexId}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select Top 1 sexId,sex From SexInfo Where sexId = @sexId;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个SexInfo数据模型对象
                    SexInfo sexInfo = new SexInfo();
                    //存储查询到的sexId数据
                    sexInfo.SexId = sqlReader.GetInt32(0);
                    //存储查询到的sex数据
                    sexInfo.Sex = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                    //将SexInfo数据模型对象返回
                    return sexInfo;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="sexId">sexId</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int sexId)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = sexId}
            };
            //执行一条按照sexId删除记录语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery("Delete From SexInfo Where sexId = @sexId;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="sexId">sexId</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int sexId)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = sexId}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From SexInfo Where sexId = @sexId;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sexInfo">SexInfo</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(SexInfo sexInfo)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = sexInfo.SexId},
                //将sex存入
                new SqlParameter("@sex",SqlDbType.NVarChar,20){Value = sexInfo.Sex ?? (object)DBNull.Value}
            };
            //执行更新语句，并返回是否更新完成
            return SqlDataBase.ExecuteNonQuery("Update SexInfo Set sex = @sex Where sexId = @sexId;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="sexInfo">验证的SexInfo数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(SexInfo sexInfo)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将sexId存入
                new SqlParameter("@sexId",SqlDbType.Int,4){Value = sexInfo.SexId},
                //将sex存入
                new SqlParameter("@sex",SqlDbType.NVarChar,20){Value = sexInfo.Sex ?? (object)DBNull.Value}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From SexInfo Where sexId = @sexId And sex = @sex;", sqlParameters) > 0;
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
                    ? "Select Count(*) From SexInfo;"
                    : "Select Count(*) From SexInfo Where " + where;
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
                    ? "Delete From SexInfo;"
                    : "Delete From SexInfo Where " + where;
            //执行删除语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<SexInfo> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<SexInfo> list = new List<SexInfo>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select sexId,sex From SexInfo;"
                    : "Select sexId,sex From SexInfo Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个SexInfo数据模型对象
                        SexInfo sexInfo = new SexInfo();
                        //存储查询到的sexId数据
                        sexInfo.SexId = sqlReader.GetInt32(0);
                        //存储查询到的sex数据
                        sexInfo.Sex = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将SexInfo数据模型对象存储到集合中
                        list.Add(sexInfo);
                    }
                }
            }
            //返回查找到的SexInfo对象的集合
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
                    ? "Select Count(*) From SexInfo;"
                    : "Select Count(*) From SexInfo Where " + where;
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
        /// <returns>查询到的SexInfo数据模型对象集合</returns>
        public List<SexInfo> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储SexInfo数据模型对象的集合
            List<SexInfo> list = new List<SexInfo>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From SexInfo) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From SexInfo Where " +
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
                        //创建一个SexInfo数据模型对象
                        SexInfo sexInfo = new SexInfo();
                        //存储查询到的sexId数据
                        sexInfo.SexId = sqlReader.GetInt32(0);
                        //存储查询到的sex数据
                        sexInfo.Sex = sqlReader.IsDBNull(1) ? null : (string)sqlReader.GetString(1);
                        //将SexInfo数据模型对象存储到集合中
                        list.Add(sexInfo);
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
        /// <returns>查询到的SexInfo数据模型对象集合</returns>
        public List<SexInfo> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
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
        /// <returns>查询到的SexInfo数据模型对象集合</returns>
        public List<SexInfo> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
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
