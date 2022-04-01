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
                    Uid = SqlHelper.FromDBValue<int>(dataReader["Uid"]),
                    ArticleId = SqlHelper.FromDBValue<int>(dataReader["ArticleId"]),
                    UserEquipment = SqlHelper.FromDBValue<string>(dataReader["UserEquipment"]),
                    Content = SqlHelper.FromDBValue<string>(dataReader["Content"]),
                    TagId = SqlHelper.FromDBValue<int>(dataReader["TagId"]),
                    PermissionId = SqlHelper.FromDBValue<int>(dataReader["PermissionId"]),
                    Forward = SqlHelper.FromDBValue<int>(dataReader["Forward"]),
                    Fabulous = SqlHelper.FromDBValue<int>(dataReader["Fabulous"]),
                    ReleaseTime = SqlHelper.FromDBValue<DateTime?>(dataReader["ReleaseTime"]),
                    TypeId = SqlHelper.FromDBValue<int?>(dataReader["TypeId"])
                });
            }
            dataReader.Close();
            return articleInfos;
        }

        public int GetCommentCountById(int aid)
        {
            string sql = @"DECLARE @i INT = 0,@j INT = 0
SET @i = (SELECT COUNT(*) FROM ArticleComment WHERE articleId = @articleId)
SET @j = (SELECT COUNT(*) FROM SecondComment WHERE commentId IN(SELECT commentId FROM ArticleComment WHERE articleId = @articleId))
SELECT @i+@J AS 'count'";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql,
                new SqlParameter("articleId", aid)));
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        public int Add(ArticleInfo articleInfo, string[] imgs, string[] vdos)
        {
            string sql = @"insert into ArticleInfo(uid,userEquipment,content,tagId,permissionId,releaseTime,typeId,forward,fabulous) values(@uid,@userEquipment,@content,@tagId,@permissionId,@releaseTime,@typeId,0,0)
select @@IDENTITY";

            articleInfo.ArticleId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql,
              new SqlParameter("uid", articleInfo.Uid),
              new SqlParameter("userEquipment", articleInfo.UserEquipment),
              new SqlParameter("content", articleInfo.Content),
              new SqlParameter("tagId", articleInfo.TagId),
              new SqlParameter("permissionId", articleInfo.PermissionId),
              new SqlParameter("releaseTime", articleInfo.ReleaseTime),
              new SqlParameter("typeId", articleInfo.TypeId)
              ));


            // 新增文章 如果图片不为空就新增图片，视频不为空新增视频
            string[] sqlimg = new string[imgs.Length];
            for (int i = 0; i < imgs.Length; i++)
            {
                sqlimg[i] = "insert into ArticleImg values(" + articleInfo.ArticleId + ",'" + imgs[i] + "' )";
            }
            if (SqlHelper.Transaction(sqlimg) == -1)
            {
                return 0;
            }
            string[] sqlvideo = new string[vdos.Length];
            for (int i = 0; i < vdos.Length; i++)
            {
                sqlvideo[i] = "insert into ArticleVideo values(" + articleInfo.ArticleId + ",'" + vdos[i] + "' )";
            }
            if (SqlHelper.Transaction(sqlvideo) == -1)
            {
                return 0;
            }

            return articleInfo.ArticleId;

        }

        /// <summary>
        /// 获取分页文章，页码和一页多少篇文章
        /// </summary>
        public DataTable GetHotArticleInfosByPage(int page, int size, bool h, bool d, bool w)
        {
            string sql = "";
            if (h)
            {
                sql = @"select  top (@size) a.*, b.permission, c.tag, d.type,u.*  from ArticleInfo as a 
join ArticlePermission as b
on a.permissionId=b.permissionId
join ArticleTag as c
on a.tagId=c.tagId
join ArticleType as d
on a.typeId=d.typeId 
join UserInfo as u
on a.uid=u.uid
where DATEDIFF(MINUTE, releaseTime, GETDATE())<= 60 and DATEDIFF(MINUTE, releaseTime, GETDATE())>= 0
and articleId not in
(select top(@size * (@page - 1)) articleId from ArticleInfo where DATEDIFF(MINUTE, releaseTime, GETDATE()) <= 60 and DATEDIFF(MINUTE, releaseTime, GETDATE())>= 0)
order by fabulous desc";
            }
            if (d)
            {
                sql = @"select  top (@size) a.*, b.permission, c.tag, d.type,u.*  from ArticleInfo as a 
join ArticlePermission as b
on a.permissionId=b.permissionId
join ArticleTag as c
on a.tagId=c.tagId
join ArticleType as d
on a.typeId=d.typeId
join UserInfo as u
on a.uid=u.uid
where DATEDIFF(MINUTE, releaseTime, GETDATE())<= 60 and DATEDIFF(MINUTE, releaseTime, GETDATE())>= 0
and articleId not in
(select top(@size * (@page - 1)) articleId from ArticleInfo where DATEDIFF(MINUTE, releaseTime, GETDATE()) <= 60 and DATEDIFF(MINUTE, releaseTime, GETDATE())>= 0)
order by fabulous desc";
            }
            if (w)
            {
                sql = @"select  top (@size) a.*, b.permission, c.tag, d.type,u.*  from ArticleInfo as a 
join ArticlePermission as b
on a.permissionId=b.permissionId
join ArticleTag as c
on a.tagId=c.tagId
join ArticleType as d
on a.typeId=d.typeId
join UserInfo as u
on a.uid=u.uid
where DATEDIFF(WEEK, releaseTime, GETDATE())<= 1 and DATEDIFF(WEEK, releaseTime, GETDATE())>= 0
and articleId not in
(select top(@size * (@page - 1)) articleId from ArticleInfo where DATEDIFF(WEEK, releaseTime, GETDATE()) <= 1 and DATEDIFF(WEEK, releaseTime, GETDATE())>= 0)
order by fabulous desc";
            }
            return SqlHelper.GetTable(sql,
                new SqlParameter("page", page),
                new SqlParameter("size", size));




        }
        /// <summary>
        /// 获取最新文章，页码和一页多少篇文章
        /// </summary>
        public DataTable GetNewArticleInfosByPage(int page, int size)
        {
            string sql = @"select  top (@size) a.*, b.permission, c.tag, d.type,u.*  from ArticleInfo as a 
join ArticlePermission as b
on a.permissionId=b.permissionId
join ArticleTag as c
on a.tagId=c.tagId
join ArticleType as d
on a.typeId=d.typeId
join UserInfo as u
on a.uid=u.uid
where articleId not in(select top(@size*(@page-1)) articleId from ArticleInfo)
order by releaseTime desc";

            return SqlHelper.GetTable(sql, new SqlParameter("page", page),
                new SqlParameter("size", size));

        }

        /// <summary>
        /// 根据文章id获取文章信息
        /// </summary>
        public DataTable GetArticleInfoById(int id)
        {
            string sql = @"select * from ArticleInfo as a
join UserInfo as u on a.uid = u.uid
join ArticleTag as t on a.tagId = t.tagId
join ArticlePermission as p on a.permissionId = p.permissionId
join ArticleType as tp on a.typeId = tp.typeId where articleId=@articleId";

            return SqlHelper.GetTable(sql, new SqlParameter("articleId", id));
        }

        /// <summary>
        /// 获取类型文章，页码和一页多少篇文章
        /// </summary>
        public DataTable GetTypeArticleInfosByPage(int typeid, int page, int size)
        {
            string sql = @"select  top (@size) a.*, b.permission, c.tag, d.type,u.* from ArticleInfo as a 
join ArticlePermission as b
on a.permissionId=b.permissionId
join ArticleTag as c
on a.tagId=c.tagId
join ArticleType as d
on a.typeId=d.typeId 
join UserInfo as u
on a.uid=u.uid
where a.typeId=@typeid and a.articleId not in
(select top ((@page-1)*@size) articleId from ArticleInfo as a
join ArticleType as b
on a.typeId=b.typeId where a.typeId=@typeid)";
            return SqlHelper.GetTable(sql,
                new SqlParameter("typeid", typeid),
                new SqlParameter("size", size),
                new SqlParameter("page", page));
        }


        /// <summary>
        /// 根据文章ID获取视频
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public List<string> GetArticleVideosById(int v)
        {
            string sql = @"select a.videoUrl  from ArticleVideo as a
join ArticleInfo as b
on a.articleId=b.articleId
where a.articleId= @articleId";
            List<string> list = new List<string>();
            SqlDataReader reader = SqlHelper.GetReader(sql, new SqlParameter("articleId", v));
            while (reader.Read())
            {
                list.Add(reader["videoUrl"].ToString());
            }

            return list;

        }

        /// <summary>
        /// 根据文章ID获取图片
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public List<string> GetArticleImagesById(int v)
        {
            string sql = "select imgUrl from ArticleImg where articleId=@articleId";

            List<string> list = new List<string>();
            SqlDataReader reader = SqlHelper.GetReader(sql, new SqlParameter("articleId", v));
            while (reader.Read())
            {
                list.Add(reader["imgUrl"].ToString());
            }

            return list;

        }


    }
}

