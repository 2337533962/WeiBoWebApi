using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.DAL
{
    public class HistoryDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();
        /// <summary>
        /// 新增历史文章
        /// </summary>
        public int Add(History history)
        {
            string sql = string.Format(@"insert into History values
            ({0}, {1})", history.Uid, history.ArticleId);
            return SqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 根据uid获取用户的历史文章
        /// </summary>
        public DataTable GetHistoriesByUid(int uid)
        {
            string sql = @"select h.articleId from History h join UserInfo u on h.uid=u.uid
join ArticleInfo a on a.articleId = h.articleId where h.uid = " + uid;
            return SqlHelper.GetTable(sql);
        }
    }
}
