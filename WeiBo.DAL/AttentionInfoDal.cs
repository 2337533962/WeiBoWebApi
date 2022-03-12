using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class AttentionInfoDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 根据uid获取用户关注列表
        /// </summary>
        public IEnumerable<AttentionInfo> GetFollowsByUid(int uid)
        {
            return dBContext.AttentionInfos.Where(o => o.FollowId == uid).ToList();
        }
        /// <summary>
        /// 根据uid获取用户粉丝列表
        /// </summary>
        public IEnumerable<AttentionInfo> GetFansByUid(int uid)
        {
            return dBContext.AttentionInfos.Where(o => o.FollowToId == uid).ToList();
        }
        /// <summary>
        /// 根据uid获取用户关注数量
        /// </summary>
        public int GetFollowCountByUid(int uid)
        {
            return dBContext.AttentionInfos.Where(o => o.FollowId == uid).Count();
        }
        /// <summary>
        /// 根据uid获取用户粉丝数量
        /// </summary>
        public int GetFansCountByUid(int uid)
        {
            return dBContext.AttentionInfos.Where(o => o.FollowToId == uid).Count();
        }
    }
}
