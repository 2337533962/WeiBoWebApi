using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WeiBoWebApi.BLL;
using WeiBoWebApi.Model;
using WeiBoWebApi.ViewModel;

namespace WeiBoWebApi.Controllers
{
    /// <summary>
    /// 文章控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleInfoBll _articleInfoBll = new ArticleInfoBll();
        private readonly ArticleTagBll _articleTagBll = new ArticleTagBll();

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns>文章列表</returns>
        [HttpGet("/rticle/all")]
        public IEnumerable<ArticleInfo> GetArticleInfos()
        {
            return _articleInfoBll.GetAllModel();
        }

        /// <summary>
        /// 获取热门文章，页码和一页多少篇文章(小时，天，周)
        /// </summary>
        [HttpGet("/rticle/hot")]
        public object GetHotArticleInfosByPage(int page, int size, bool h = true, bool d = false, bool w = false)
        {
            DataTable dt = _articleInfoBll.GetHotArticleInfosByPage(page, size, h, d, w);

            List<object> list = new List<object>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int aid = Convert.ToInt32(dt.Rows[i]["ArticleId"]); // 获取文章id

                List<string> imgs = _articleInfoBll.GetArticleImagesById(aid); // 根据文章id获取文章图片
                List<string> videos = _articleInfoBll.GetArticleVideosById(aid); // 根据文章id获取文章视频

                int count = _articleInfoBll.GetCommentCountById(aid);

                list.Add(new
                {
                    created_at = dt.Rows[i]["releaseTime"], // 发布时间
                    id = aid, // 文章id
                    user = new
                    {
                        id = dt.Rows[i]["uid"], // 用户id
                        nick_name = dt.Rows[i]["nickName"], // 用户昵称
                        screen_name = dt.Rows[i]["userEquipment"], // 用户设备
                        profile_image_url = dt.Rows[i]["headPortrait"] //头像
                    },
                    text_raw = dt.Rows[i]["content"], // 内容
                    comments_count = count, // 评论总数
                    pic_num = imgs.Count, // 图片数量
                    pic_infos = imgs,
                    tv_num = videos.Count, // 视频数量
                    tx_infos = videos
                });
            }
            return new { ok = 1, statuses = list }; ;
        }

        /// <summary>
        /// 获取最新文章，页码和一页多少篇文章
        /// </summary>
        [HttpGet("/rticle/time")]
        public object GetNewArticleInfosByPage(int page, int size)
        {
            DataTable dt = _articleInfoBll.GetNewArticleInfosByPage(page, size);

            List<object> list = new List<object>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int aid = Convert.ToInt32(dt.Rows[i]["ArticleId"]); // 获取文章id

                List<string> imgs = _articleInfoBll.GetArticleImagesById(aid); // 根据文章id获取文章图片
                List<string> videos = _articleInfoBll.GetArticleVideosById(aid); // 根据文章id获取文章视频

                int count = _articleInfoBll.GetCommentCountById(aid);

                list.Add(new
                {
                    created_at = dt.Rows[i]["releaseTime"], // 发布时间
                    id = aid, // 文章id
                    user = new
                    {
                        id = dt.Rows[i]["uid"], // 用户id
                        nick_name = dt.Rows[i]["nickName"], // 用户昵称
                        screen_name = dt.Rows[i]["userEquipment"], // 用户设备
                        profile_image_url = dt.Rows[i]["headPortrait"] //头像
                    },
                    text_raw = dt.Rows[i]["content"], // 内容
                    comments_count = count, // 评论总数
                    pic_num = imgs.Count, // 图片数量
                    pic_infos = imgs,
                    tv_num = videos.Count, // 视频数量
                    tx_infos = videos
                });
            }
            return new { ok = 1, statuses = list };
        }
        /// <summary>
        /// 获取类型文章，页码和一页多少篇文章
        /// </summary>
        [HttpGet("/rticle/type")]
        public object GetTypeArticleInfosByPage(int typeid, int page, int size)
        {
            DataTable dt = _articleInfoBll.GetTypeArticleInfosByPage(typeid, page, size);
            List<object> list = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int aid = Convert.ToInt32(dt.Rows[i]["ArticleId"]); // 获取文章id

                List<string> imgs = _articleInfoBll.GetArticleImagesById(aid); // 根据文章id获取文章图片
                List<string> videos = _articleInfoBll.GetArticleVideosById(aid); // 根据文章id获取文章视频

                int count = _articleInfoBll.GetCommentCountById(aid);

                list.Add(new
                {
                    created_at = dt.Rows[i]["releaseTime"], // 发布时间
                    id = aid, // 文章id
                    user = new
                    {
                        id = dt.Rows[i]["uid"], // 用户id
                        nick_name = dt.Rows[i]["nickName"], // 用户昵称
                        screen_name = dt.Rows[i]["userEquipment"], // 用户设备
                        profile_image_url = dt.Rows[i]["headPortrait"] //头像
                    },
                    text_raw = dt.Rows[i]["content"], // 内容
                    comments_count = count, // 评论总数
                    pic_num = imgs.Count, // 图片数量
                    pic_infos = imgs,
                    tv_num = videos.Count, // 视频数量
                    tx_infos = videos
                });
            }
            return new { ok = 1, statuses = list };
        }

        /// <summary>
        /// 根据文章id获取文章信息
        /// </summary>
        [HttpGet("/rticle")]
        public object GetArticleInfoById(int id)
        {
            DataTable dt = _articleInfoBll.GetArticleInfoById(id);
            if (dt.Rows.Count <= 0)
                return new { ok = 0, statuses = "" };

            int aid = Convert.ToInt32(dt.Rows[0]["ArticleId"]); // 获取文章id
            List<string> imgs = _articleInfoBll.GetArticleImagesById(aid); // 根据文章id获取文章图片
            List<string> videos = _articleInfoBll.GetArticleVideosById(aid); // 根据文章id获取文章视频
            int count = _articleInfoBll.GetCommentCountById(aid);
            return new
            {
                ok = 1,
                statuses = new
                {
                    created_at = dt.Rows[0]["releaseTime"], // 发布时间
                    id = aid, // 文章id
                    user = new
                    {
                        id = dt.Rows[0]["uid"], // 用户id
                        nick_name = dt.Rows[0]["nickName"], // 用户昵称
                        screen_name = dt.Rows[0]["userEquipment"], // 用户设备
                        profile_image_url = dt.Rows[0]["headPortrait"] //头像
                    },
                    text_raw = dt.Rows[0]["content"], // 内容
                    comments_count = count, // 评论总数
                    pic_num = imgs.Count, // 图片数量
                    pic_infos = imgs,
                    tv_num = videos.Count, // 视频数量
                    tx_infos = videos
                }
            };
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        [HttpPost("/rticle")]
        public object Insert(ArticleBasicInfo articleBasicInfo)
        {
            ArticleInfo info = new ArticleInfo();
            info.Uid = articleBasicInfo.Uid;
            info.UserEquipment = articleBasicInfo.UserEquipment;
            info.Content = articleBasicInfo.Content;
            info.PermissionId = articleBasicInfo.PermissionId;
            info.ReleaseTime = articleBasicInfo.ReleaseTime;
            info.TypeId = articleBasicInfo.TypeId;
            //获取TagId
            info.TagId = _articleTagBll.GetTagId(articleBasicInfo.Tag);

            if (_articleInfoBll.Add(info, articleBasicInfo.imgs, articleBasicInfo.vdos) > 0)
                return OperResult.Succeed("添加成功!");
            return OperResult.Failed("添加失败!");
        }

        // <summary>
        // 修改文章
        // </summary>
        //[HttpPut("/rticle/u")]
        //public object Update(ArticleInfo articleInfo)
        //{
        //    return OperResult.Failed("还没有做，你别急！");
        //}

    }
}
