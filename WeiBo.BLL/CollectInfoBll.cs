using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    public class CollectInfoBll
    {
        private readonly CollectInfoDal _collectInfoDal = new CollectInfoDal();
        public int Add(CollectInfo collectInfo)
        {
            return _collectInfoDal.Add(collectInfo);
        }

        public IEnumerable<CollectInfo> GetCollectsByUid(int uid)
        {
            return _collectInfoDal.GetCollectsByUid(uid);
        }
    }
}
