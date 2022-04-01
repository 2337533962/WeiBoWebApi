using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.BLL
{
    public class ArticleInfoBll
    {
        private readonly ArticleInfoDal _articleInfoDal = new ArticleInfoDal();
        public List<ArticleInfo> GetAllModel()
        {
            return _articleInfoDal.GetAllModel();
        }

        public int Add(ArticleInfo articleInfo, string[] imgs, string[] vdos)
        {
            return _articleInfoDal.Add(articleInfo,imgs,vdos);
        }

        /// <summary>
        /// 获取热门文章，页码和一页多少篇文章
        /// </summary>
        public DataTable GetHotArticleInfosByPage(int page, int size, bool h, bool d, bool w)
        {
            return _articleInfoDal.GetHotArticleInfosByPage(page, size, h, d, w);
        }

        /// <summary>
        /// 获取最新文章，页码和一页多少篇文章
        /// </summary>
        public DataTable GetNewArticleInfosByPage(int page, int size)
        {
            return _articleInfoDal.GetNewArticleInfosByPage(page, size);
        }

        /// <summary>
        /// 根据文章id获取文章信息
        /// </summary>
        public DataTable GetArticleInfoById(int id)
        {
            return _articleInfoDal.GetArticleInfoById(id);
        }

        /// <summary>
        /// 获取类型文章，页码和一页多少篇文章
        /// </summary>
        public DataTable GetTypeArticleInfosByPage(int typeid, int page, int size)
        {
            return _articleInfoDal.GetTypeArticleInfosByPage(typeid, page, size);
        }

        public int GetCommentCountById(int aid)
        {
            return _articleInfoDal.GetCommentCountById(aid);
        }

        /// <summary>
        /// 根据文章ID获取视频
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public List<string> GetArticleVideosById(int v)
        {
            return _articleInfoDal.GetArticleVideosById(v);
        }

        /// <summary>
        /// 根据文章ID获取图片
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public List<string> GetArticleImagesById(int v)
        {
            return _articleInfoDal.GetArticleImagesById(v);
        }
    }
}
