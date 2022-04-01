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
    public class CollectInfoDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 新增收藏
        /// </summary>
        public int Add(int? uid, int articleId)
        {
            string sql = @"insert into CollectInfo values
            (@uid, @articleId)";
            return SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("uid", uid),
                new SqlParameter("articleId", articleId));
        }
        /// <summary>
        /// 根据uid获取收藏
        /// </summary>
        public DataTable GetCollectsByUid(int uid)
        {
            string sql = @"select c.articleId from CollectInfo c join UserInfo u on c.uid=u.uid
join ArticleInfo a on a.articleId=c.articleId where c.uid=
" + @uid;
            return SqlHelper.GetTable(sql);
        }

        /// <summary>
        /// 移除收藏
        /// </summary>
        public int Remove(int? uid, int articleId)
        {
            string sql = "delete CollectInfo where uid=@uid and articleId=@articleId";
            return SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("uid", uid),
                new SqlParameter("articleId", articleId));

        }
    }
}
