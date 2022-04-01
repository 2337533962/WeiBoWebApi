using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;
using WeiBoWebApi.DAL;

namespace WeiBoWebApi.BLL
{
    public class ArticleTagBll
    {
        private readonly ArticleTagDal _articletagdal = new ArticleTagDal();
        /// <summary>
        /// 获取前n条热门标签
        /// </summary>
        public DataTable GetHotTagTopN(int top)
        {
            return _articletagdal.GetHotTagTopN(top);
        }
        /// <summary>
        /// 如果存在Tag返回TagId，如果不存在新增Tag返回TagId
        /// </summary>
        public int? GetTagId(string tag)
        {
            /* 可以这么写但是好像会出什么问题的SQL
            string sql = "INSERT INTO [ArticleTag] VALUES ('今天星期四了！') SELECT @@IDENTITY";
            */
            return _articletagdal.GetTagId(tag);
        }
    }
}
