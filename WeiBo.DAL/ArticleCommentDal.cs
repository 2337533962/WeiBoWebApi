using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WeiBoWebApi.DAL
{
    public class ArticleCommentDal
    {
        /// <summary>
        /// 根据评论id获取子评论
        /// </summary>
        public DataTable GetSubCommentById(int id)
        {
            string sql = @"SELECT  dbo.SecondComment.secondCommentId, dbo.SecondComment.commentId, dbo.ArticleComment.uid, 
                   dbo.UserInfo.nickName, dbo.UserInfo.headPortrait, dbo.SecondComment.[content], dbo.SecondComment.contentTime, 
                   dbo.SecondComment.fabulous
FROM      dbo.SecondComment INNER JOIN
                   dbo.ArticleComment ON dbo.SecondComment.commentId = dbo.ArticleComment.commentId INNER JOIN
                   dbo.UserInfo ON dbo.ArticleComment.uid = dbo.UserInfo.uid where SecondComment.commentId = @commentId";
            return SqlHelper.GetTable(sql,
                new SqlParameter("commentId", id));
        }

        /// <summary>
        /// 根据文章id获取一条评论
        /// </summary>
        public DataTable GetCommentById(int id)
        {
            string sql = @"SELECT  dbo.ArticleComment.commentId, dbo.ArticleComment.articleId, dbo.ArticleComment.contentTime, dbo.ArticleComment.uid, 
                   dbo.UserInfo.nickName, dbo.UserInfo.headPortrait, dbo.ArticleComment.fabulous, dbo.ArticleComment.[content]
FROM dbo.ArticleComment INNER JOIN
                   dbo.ArticleInfo ON dbo.ArticleComment.articleId = dbo.ArticleInfo.articleId INNER JOIN
                   dbo.UserInfo ON dbo.ArticleComment.uid = dbo.UserInfo.uid AND dbo.ArticleInfo.uid = dbo.UserInfo.uid where ArticleComment.articleId = @articleId";
            return SqlHelper.GetTable(sql,
                new SqlParameter("articleId", id));
        }

    }
}
