using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    public class UserBehaviorBll
    {
        private readonly UserBehaviorDal _userBehaviorDal = new UserBehaviorDal();
        public int Add(UserBehavior userBehavior)
        {
            return _userBehaviorDal.Add(userBehavior);
        }
    }
}
