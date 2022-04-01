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
    public class ArticleTagDal
    {
        /// <summary>
        /// 获取前n条热门标签
        /// </summary>
        public DataTable GetHotTagTopN(int top)
        {
            string sql = @"select top (@topN) a.tagId,atag.tag from
(select ai.tagId, count(ai.tagId) as num from ArticleInfo as ai
                                         group by ai.tagId) as a
join ArticleTag atag
on a.tagId = atag.tagId
order by num desc";
            return SqlHelper.GetTable(sql, new SqlParameter("topN", top));
        }

        /// <summary>
        /// 如果存在Tag返回TagId，如果不存在新增Tag返回TagId
        /// </summary>
        public int? GetTagId(string tag)
        {
           
            string sql = @"if not exists (select * from ArticleTag where tag like @tag)
begin
INSERT INTO[ArticleTag] VALUES(@tag) SELECT @@IDENTITY
end
else
                begin
                select tagId from ArticleTag where tag like @tag
end";

            object a= ( SqlHelper.ExecuteScalar(sql, new SqlParameter("tag", tag)));
            return Convert.ToInt32(a);
        }
    }
}