using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class UserBehaviorDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 新增用户行为
        /// </summary>
        public int Add(UserBehavior userBehavior)
        {
           string sql=string.Format(@"insert into UserBehavior values
               ({0}, {1})",userBehavior.Uid,userBehavior.Behavior);
            return SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
