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
    public class ArticleTypeDal
    {
        //readonly WeiBoDBContext dBContext = DBContextFactory.GetContext();

        /// <summary>
        /// 获取所有作品类型
        /// </summary>
        public List<ArticleType> GetAllModel()
        {
            string sql = "select * from ArticleType";
            List<ArticleType> articleType = new List<ArticleType>();
            SqlDataReader dataReader = SqlHelper.GetReader(sql);
            while (dataReader.Read())
            {
                articleType.Add(new ArticleType()
                {
                    TypeId = Convert.ToInt32(dataReader["TypeId"]),
                    Type = dataReader["Type"].ToString()
                });
            }
            dataReader.Close();
            return articleType;
        }
    }
}
