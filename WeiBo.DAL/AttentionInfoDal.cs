using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.DAL
{
    public class AttentionInfoDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 根据uid获取用户关注列表
        /// </summary>
        public DataTable GetFollowsByUid(int uid)
        {
            string sql = string.Format(@"select * from AttentionInfo as a,UserInfo as b where  a.followToId=b.uid  and followId={0}", @uid);
            return SqlHelper.GetTable(sql);

        }
        /// <summary>
        /// 根据uid获取用户粉丝列表
        /// </summary>
        public DataTable GetFansByUid(int uid)
        {
            string sql = "select * from AttentionInfo as a,UserInfo as b where  a.followId=b.uid  and followToId=" + uid;
            return SqlHelper.GetTable(sql);
        }
        /// <summary>
        /// 根据uid获取用户关注数量
        /// </summary>
        public int GetFollowCountByUid(int uid)
        {
            string sql = @"select count(followToId) as FollowNum from AttentionInfo as a,UserInfo as b where  a.followToId=b.uid  and followId=" + uid;
            DataTable dt = SqlHelper.GetTable(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        /// <summary>
        /// 根据uid获取用户粉丝数量
        /// </summary>
        public int GetFansCountByUid(int uid)
        {
            string sql = @" select Count(followId) as FollowToNum  from AttentionInfo as a,UserInfo as b where a.followId = b.uid  and followToId = 3" + uid;
            DataTable dt = SqlHelper.GetTable(sql);
            return Convert.ToInt32(dt.Rows[0][0]);

        }
    }
}
