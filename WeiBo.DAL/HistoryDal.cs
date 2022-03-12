using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class HistoryDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();
        /// <summary>
        /// 新增历史文章
        /// </summary>
        public int Add(History history)
        {
            dBContext.Histories.Add(history);
            return dBContext.SaveChanges();
        }
        /// <summary>
        /// 根据uid获取用户的历史文章
        /// </summary>
        public IEnumerable<History> GetHistoriesByUid(int uid)
        {
            return dBContext.Histories.Where(h => h.Uid == uid).ToList();
        }
    }
}
