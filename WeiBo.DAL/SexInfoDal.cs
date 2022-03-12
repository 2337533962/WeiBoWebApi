using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    public class SexInfoDal
    {
        readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 获取所有性别
        /// </summary>
        public IEnumerable<SexInfo> GetAllModel()
        {
            return dBContext.SexInfos.ToList();
        }
        /// <summary>
        /// 根据性别Id返回性别信息
        /// </summary>
        public SexInfo GetSexInfoById(int sexId)
        {
            return dBContext.SexInfos.FirstOrDefault(s => s.SexId == sexId);
        }
    }
}
