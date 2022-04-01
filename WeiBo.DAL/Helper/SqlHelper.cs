using System;
//引用表的命名空间
using System.Data;
//引用关于sql的命名空间
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace WeiBoWebApi.DAL
{

    public class SqlHelper//在class前面加上public   公共的
    {
        //直接把所以的方法写成静态的方法
        //静态方法：就是可以直接通过类名调用，而不需要创建一个对象
        //dallogin dl=new dallogin();
        //dl点出来的方法，我们称之为非静态方法
        //dallogin点出来的方法称之为静态方法;

        public static string connstr = "server=.;integrated Security=true;database=WeiBoDB;";
        //第一个方法   通常作用于绑定表     查询一张表里面的多条数据，并显示出来
        /// <summary>
        /// 返回的是第一张表
        /// </summary>
        /// <param name="sql">传入sql语句</param>
        /// <param name="type">指定命令形式</param>
        /// <param name="pms">参数数组</param>
        /// <returns></returns>
        public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pms)
        {
            //创建sql连接
            SqlConnection conn = new SqlConnection(connstr);
            //打开数据库
            conn.Open();
            //创建一个sql执行命令对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;//指定我们传到sql里面执行的语句是一个sql语句还是存储过程
            if (pms != null)
            {
                //如果pms不为空，在去判断里面的每一个参数是否有值，如果有就传进去，没有就跳过
                foreach (SqlParameter item in pms)
                {
                    if (item != null)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);//接收的
            DataSet ds = new DataSet();//适配器就相当于一个中转站
            sda.Fill(ds, "sa");//把接收出来的表命一个别名并给适配器
            conn.Close();//由于表已经给了适配器，所以数据库暂时用不到了，关闭
                         //由于我们在数据库当中查的是一张表，所以我们在程序中也要用一张表来接收
                         //.net当中的表也叫datatable
            DataTable dt = ds.Tables["sa"];
            return dt;
        }

        public static DataTable GetTable(string sql, params SqlParameter[] pms)
        {
            return GetTable(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// 返回首行首页，一般作用于查询返回结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pms"></param>
        ///params 不限长度的 加上他之后，我们传递参数的时候，可以传一个数组，也可以传递一系列参数
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pms)
        {
            //创建sql连接
            SqlConnection conn = new SqlConnection(connstr);
            //打开数据库
            conn.Open();
            //创建一个sql执行命令对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;//指定我们传到sql里面执行的语句是一个sql语句还是存储过程
            if (pms != null)
            {
                //如果pms不为空，在去判断里面的每一个参数是否有值，如果有就传进去，没有就跳过
                foreach (SqlParameter item in pms)
                {
                    if (item != null)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
            }
            Object o = cmd.ExecuteScalar();
            conn.Close();
            return o;
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            return ExecuteScalar(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// 返回受影响行数，一般用于增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pms)
        {
            //创建sql连接
            SqlConnection conn = new SqlConnection(connstr);
            //打开数据库
            conn.Open();
            //创建一个sql执行命令对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;//指定我们传到sql里面执行的语句是一个sql语句还是存储过程
            if (pms != null)
            {
                //如果pms不为空，在去判断里面的每一个参数是否有值，如果有就传进去，没有就跳过
                foreach (SqlParameter item in pms)
                {
                    if (item != null)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// 查询一个结果，然后以一个游标的形式返回出来
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, CommandType type, params SqlParameter[] pms)
        {
            //创建sql连接
            SqlConnection conn = new SqlConnection(connstr);
            //打开数据库
            conn.Open();
            //创建一个sql执行命令对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;//指定我们传到sql里面执行的语句是一个sql语句还是存储过程
            if (pms != null)
            {
                //如果pms不为空，在去判断里面的每一个参数是否有值，如果有就传进去，没有就跳过
                foreach (SqlParameter item in pms)
                {
                    if (item != null)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
            }
            //把查询出来的结果当成一个游标返回出去
            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return sdr;
        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] pms)
        {
            return GetReader(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// 将要传入数据库的空值转成DBnull.Value
        /// </summary>
        /// <param name="value">要传入的值</param>
        /// <returns>返回对象，如值为空则转为DBnull，不为空返回原值</returns>
        public static object ToDBValue(object value)
        {
            return value == null ? DBNull.Value : value;
        }
        /// <summary>
        /// 将要获取到的数据库的空值转成null
        /// </summary>
        /// <param name="value">数据库的值</param>
        /// <returns>返回对象，如值为DBnull则转为null，不为空返回原值</returns>
        public static object FromDBValue(object value)
        {
            return value == DBNull.Value ? null : value;
        }
        /// <summary>
        /// 如果从数据库中获取的值是DBNull，则返回该类型的默认值，否则转换后的自身
        /// </summary>
        public static T FromDBValue<T>(object value)
        {
            return value == DBNull.Value || value == null ? default : (T)value;
        }

        public static int Transaction(string[] sql,params SqlParameter[] ps)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            //启动一个事务。
            SqlTransaction myTran = con.BeginTransaction();
            //为事务创建一个命令，注意我们执行双条命令，第一次执行当然成功。我们再执行一次，失败。
            //第三次我们改其中一个命令，另一个不改，这时候事务会报错，这就是事务机制。
            SqlCommand myCom = new SqlCommand();
            myCom.Connection = con;
            myCom.Transaction = myTran;
            try
            {
                for (int i = 0; i < sql.Length; i++)
                {
                    myCom.CommandText = sql[i];
                    myCom.ExecuteNonQuery();
                }
                myTran.Commit();
                return sql.Length;

            }
            catch (Exception Ex)
            {
                myTran.Rollback();
                //创建并且返回异常的错误信息
                return -1;
            }
            finally
            {
                con.Close();
            }

        }
    }
}