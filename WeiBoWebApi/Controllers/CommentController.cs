using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.BLL;
using WeiBoWebApi.ViewModel;

namespace WeiBoWebApi.Controllers
{

    /// <summary>
    /// 评论
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ArticleCommentBll _articleCommentBll = new ArticleCommentBll();

        /// <summary>
        /// 根据文章ID获取评论
        /// </summary>
        [HttpGet]
        public string GetCommentsById(int id)
        {
            // 文章评论可能有多条
            DataTable dtComment = _articleCommentBll.GetCommentById(id);

            List<Comment> comments = new List<Comment>();
            // 遍历每一条文章评论
            for (int i = 0; i < dtComment.Rows.Count; i++)
            {
                // 获取里面的子评论
                DataTable dtSubComments = _articleCommentBll.GetSubCommentById(id);

                Comment comment = new Comment
                {
                    /*
                     * 此处dtComment.Rows[0][""] 列名未填写
                     */
                    Content = dtComment.Rows[i]["content"].ToString(),
                    date = Convert.ToDateTime(dtComment.Rows[i]["contentTime"]),
                    FromAvatar = dtComment.Rows[i]["headPortrait"].ToString(),
                    FromName = dtComment.Rows[i]["nickName"].ToString(),
                    FromId = Convert.ToInt32(dtComment.Rows[i]["uid"]),
                    Id = Convert.ToInt32(dtComment.Rows[i]["commentId"]),
                    LikeNum = Convert.ToInt32(dtComment.Rows[i]["fabulous"]),
                    OwnerId = Convert.ToInt32(dtComment.Rows[i]["articleId"]),
                    Reply = JsonConvert.SerializeObject(dtSubComments)

                    /*
                    * 此处dtComment.Rows[0][""] 列名未填写
                    */
                };
                comments.Add(comment);
            }
            return JsonConvert.SerializeObject(comments);
        }
    }
}
