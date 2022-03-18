using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    public class ArticleTypeBll
    {
        private readonly ArticleTypeDal _articleTypeDal = new ArticleTypeDal();
        public List<ArticleType> GetAllModel()
        {
            return _articleTypeDal.GetAllModel();
        }
    }
}
