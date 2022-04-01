using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.DAL;

namespace WeiBoWebApi.BLL
{
    public class ArticleCommentBll
    {
        private readonly ArticleCommentDal _articleCommentDal = new ArticleCommentDal();
        /// <summary>
        /// 根据评论id获取子评论
        /// </summary>
        public DataTable GetSubCommentById(int id)
        {
            //id: '34523244545',  //主键id
            //commentId: 'comment0001',  //父评论id，即父亲的id
            //fromId: 'observer223432',  //评论者id
            //fromName: '夕阳红',  //评论者昵称
            //fromAvatar: 'https://wx4.sinaimg.cn/mw690/69e273f8gy1ft1541dmb7j215o0qv7wh.jpg', //评论者头像
            //toId: 'errhefe232213',  //被评论者id
            //toName: '犀利的评论家',  //被评论者昵称
            //toAvatar: 'http://ww4.sinaimg.cn/bmiddle/006DLFVFgy1ft0j2pddjuj30v90uvagf.jpg',  //被评论者头像
            //content: '赞同，很靠谱，水平很高',  //评论内容
            //date: '2018-07-05 08:35'   //评论时间
            //likeNum: 3, //点赞人数
            return _articleCommentDal.GetSubCommentById(id);
        }

        /// <summary>
        /// 根据文章id获取一条评论
        /// </summary>
        public DataTable GetCommentById(int id)
        {
            //id: 'comment0001', //主键id
            //date: '2018-07-05 08:30',  //评论时间
            //ownerId: 'talents100020', //文章的id
            //fromId: 'errhefe232213',  //评论者id
            //fromName: '犀利的评论家',   //评论者昵称
            //fromAvatar: 'http://ww4.sinaimg.cn/bmiddle/006DLFVFgy1ft0j2pddjuj30v90uvagf.jpg', //评论者头像
            //likeNum: 3, //点赞人数
            //content: '非常靠谱的程序员',  //评论内容
            return _articleCommentDal.GetCommentById(id);
        }
    }
}
