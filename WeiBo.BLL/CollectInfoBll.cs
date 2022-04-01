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
    public class CollectInfoBll
    {
        private readonly CollectInfoDal _collectInfoDal = new CollectInfoDal();

        /// <summary>
        /// 新增收藏
        /// </summary>
        public int Add(int? uid, int articleId)
        {
            return _collectInfoDal.Add(uid, articleId);
        }
        /// <summary>
        /// 移除收藏
        /// </summary>
        public int Remove(int? uid, int articleId)
        {
            return _collectInfoDal.Remove(uid, articleId);
        }

        /// <summary>
        /// 获取用户的收藏
        /// </summary>
        public DataTable GetCollectsByUid(int uid)
        {
            return _collectInfoDal.GetCollectsByUid(uid);
        }
    }
}
