using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.DAL
{
    public class CollectInfoDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 新增收藏
        /// </summary>
        public int Add(CollectInfo collectInfo)
        {
            string sql = string.Format(@"insert into CollectInfo values
            ({0}, {1})", @collectInfo.Uid, @collectInfo.ArticleId);
            return SqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 根据uid获取收藏
        /// </summary>
        public DataTable GetCollectsByUid(int uid)
        {
            string sql = @"select * from CollectInfo c join UserInfo u on c.uid=u.uid
join ArticleInfo a on a.articleId = c.articleId where c.uid = "+@uid;
            return SqlHelper.GetTable(sql);
        }
    }
}
