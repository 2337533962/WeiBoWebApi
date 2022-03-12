using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class ArticleTypeDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 获取所有作品类型
        /// </summary>
        public IEnumerable<ArticleType> GetAllModel()
        {
            return dBContext.ArticleTypes.ToList();
        }
    }
}
