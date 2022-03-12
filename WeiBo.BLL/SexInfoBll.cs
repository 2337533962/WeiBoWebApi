using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    public class SexInfoBll
    {
        private readonly SexInfoDal _sexInfoDal = new SexInfoDal();
        public IEnumerable<SexInfo> GetAllModel()
        {
            return _sexInfoDal.GetAllModel();
        }

        public SexInfo GetSexInfoById(int sexId)
        {
            return _sexInfoDal.GetSexInfoById(sexId);
        }
    }
}
