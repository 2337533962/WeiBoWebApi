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
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 新增用户行为
        /// </summary>
        public int Add(UserBehavior userBehavior)
        {
            dBContext.UserBehaviors.Add(userBehavior);
            return dBContext.SaveChanges();
        }
    }
}
