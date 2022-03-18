using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace WeiBoWebApi.DAL
{
   
    public class ArticleInfoDal
    {
        /// <summary>
        /// 获取所有作品信息
        /// </summary>
        public List<ArticleInfo> GetAllModel()
        {
            string sql = "select * from ArticleInfo";
            List<ArticleInfo> articleInfos = new List<ArticleInfo>();
            SqlDataReader dataReader = SqlHelper.GetReader(sql);
            while (dataReader.Read())
            {
                articleInfos.Add(new ArticleInfo()
                {
                    Uid = Convert.ToInt32(dataReader["Uid"]),
                    ArticleId=Convert.ToInt32(dataReader["ArticleId"]),
                    UserEquipment=dataReader["UserEquipment"].ToString(),
                    Content=dataReader["Content"].ToString(),
                    TagId= Convert.ToInt32(dataReader["TagId"]),
                    PermissionId= Convert.ToInt32(dataReader["PermissionId"]),
                    Forward= Convert.ToInt32(dataReader["Forward"]),
                    Fabulous= Convert.ToInt32(dataReader["Fabulous"]),
                    ReleaseTime=Convert.ToDateTime(dataReader["ReleaseTime"])
                });
            }
            dataReader.Close();
            return articleInfos;
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        public int Add(ArticleInfo articleInfo)
        {
            string sql = string.Format(@"insert into ArticleInfo values
           ({0}, '{1}', '{2}',
           {3}, {4}, {5}, {6}, '{7}')", @articleInfo.ArticleId, @articleInfo.UserEquipment, @articleInfo.Content, @articleInfo.TagId, @articleInfo.PermissionId, @articleInfo.Forward, @articleInfo.Fabulous, @articleInfo.ReleaseTime);
            return SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
