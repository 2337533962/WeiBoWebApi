using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class ArticleInfoDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 获取所有作品信息
        /// </summary>
        public IEnumerable<ArticleInfo> GetAllModel()
        {
            return dBContext.ArticleInfos.ToList();
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        public int Add(ArticleInfo articleInfo)
        {
            dBContext.ArticleInfos.Add(articleInfo);
            return dBContext.SaveChanges();
        }
    }
}
