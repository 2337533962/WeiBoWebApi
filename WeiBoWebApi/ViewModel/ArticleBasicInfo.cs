using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.ViewModel
{
    /// <summary>
    /// 新增文章
    /// </summary>
    public class ArticleBasicInfo
    {
        /// <summary>
        /// 发布人
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 用户设备
        /// </summary>
        public string UserEquipment { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 文章权限
        /// </summary>
        public int? PermissionId { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? ReleaseTime { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int? TypeId { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string[] imgs { get; set; }
        /// <summary>
        /// 视频
        /// </summary>
        public string[] vdos { get; set; }
    }
}