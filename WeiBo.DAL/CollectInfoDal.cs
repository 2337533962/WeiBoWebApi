using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class CollectInfoDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 新增收藏
        /// </summary>
        public int Add(CollectInfo collectInfo)
        {
            dBContext.CollectInfos.Add(collectInfo);
            return dBContext.SaveChanges();
        }
        /// <summary>
        /// 根据uid获取收藏
        /// </summary>
        public IEnumerable<CollectInfo> GetCollectsByUid(int uid)
        {
            return dBContext.CollectInfos.Where(c => c.Uid == uid);
        }
    }
}
