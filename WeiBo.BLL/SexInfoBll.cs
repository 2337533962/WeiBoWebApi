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
    public class SexInfoBll
    {
        private readonly SexInfoDal _sexInfoDal = new SexInfoDal();
        public DataTable GetAllModel()
        {
            return _sexInfoDal.GetAllModel();
        }

        public SexInfo GetSexInfoById(int sexId)
        {
            return _sexInfoDal.GetSexInfoById(sexId);
        }
    }
}
