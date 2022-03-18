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
    public class HistoryBll
    {
        private readonly HistoryDal _historyDal = new HistoryDal();
        public int Add(History history)
        {
            return _historyDal.Add(history);
        }

        public DataTable GetHistoriesByUid(int uid)
        {
            return _historyDal.GetHistoriesByUid(uid);
        }
    }
}
