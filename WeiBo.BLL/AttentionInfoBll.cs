using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.BLL
{
    public class AttentionInfoBll
    {
        private readonly AttentionInfoDal _attentionInfoDal = new AttentionInfoDal();
        public DataTable GetFollowsByUid(int uid)
        {
            return _attentionInfoDal.GetFollowsByUid(uid);
        }

        public DataTable GetFansByUid(int uid)
        {
            return _attentionInfoDal.GetFansByUid(uid);
        }

        public int GetFollowCountByUid(int uid)
        {
            return _attentionInfoDal.GetFollowCountByUid(uid);
        }

        public int GetFansCountByUid(int uid)
        {
            return _attentionInfoDal.GetFansCountByUid(uid);
        }
    }
}
