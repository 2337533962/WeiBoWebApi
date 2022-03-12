using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    public class AttentionInfoBll
    {
        private readonly AttentionInfoDal _attentionInfoDal = new AttentionInfoDal();
        public IEnumerable<AttentionInfo> GetFollowsByUid(int uid)
        {
            return _attentionInfoDal.GetFollowsByUid(uid);
        }

        public int GetFollowCountByUid(int uid)
        {
            return _attentionInfoDal.GetFollowCountByUid(uid);
        }

        public IEnumerable<AttentionInfo> GetFansByUid(int uid)
        {
            return _attentionInfoDal.GetFansByUid(uid);
        }

        public int GetFansCountByUid(int uid)
        {
            return _attentionInfoDal.GetFansCountByUid(uid);
        }
    }
}
