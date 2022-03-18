using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;

namespace WeiBoWebApi.DAL
{
    public class SexInfoDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 获取所有性别
        /// </summary>
        public DataTable GetAllModel()
        {
            string sql = "select * from SexInfo";
            return SqlHelper.GetTable(sql);
        }
        /// <summary>
        /// 根据性别Id返回性别信息
        /// </summary>
        public SexInfo GetSexInfoById(int sexId)
        {
            SexInfo sex = new SexInfo();
            string sql = "select * from SexInfo where sexId=" + sexId;
            DataTable dt = SqlHelper.GetTable(sql);
            sex.SexId =Convert.ToInt32( dt.Rows[0][0]);
            sex.Sex = dt.Rows[0][1].ToString();
            return sex;
        }
    }
}
