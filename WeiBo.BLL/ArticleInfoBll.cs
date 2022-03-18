using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    public class ArticleInfoBll
    {
        private readonly ArticleInfoDal _articleInfoDal = new ArticleInfoDal();
        public List<ArticleInfo> GetAllModel()
        {
            return _articleInfoDal.GetAllModel();
        }

        public int Add(ArticleInfo articleInfo)
        {
            return _articleInfoDal.Add(articleInfo);
        }
    }
}
