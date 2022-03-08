using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 作品信息表数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleInfo
    {
        /// <summary>
        /// 初始化作品信息表数据模型对象
        /// </summary>
        public ArticleInfo()
        {
            
        }
        /// <summary>
        /// 初始化作品信息表数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="articleId">作品Id</param>
        public ArticleInfo(int articleId)
        {
            //给作品Id字段赋值
            this.ArticleId = articleId;
        }
        /// <summary>
        /// 初始化作品信息表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="articleId">作品Id</param>
        /// <param name="userEquipment">用户设备</param>
        /// <param name="content">内容</param>
        /// <param name="tagId">标签Id</param>
        /// <param name="permissionId">权限Id</param>
        /// <param name="forward">转发</param>
        /// <param name="fabulous">点赞</param>
        /// <param name="releaseTime">发布时间</param>
        public ArticleInfo(int? uid,int articleId,string userEquipment,string content,int? tagId,int? permissionId,int? forward,int? fabulous,DateTime? releaseTime)
        {
            //给用户Id字段赋值
            this.Uid = uid;
            //给作品Id字段赋值
            this.ArticleId = articleId;
            //给用户设备字段赋值
            this.UserEquipment = userEquipment;
            //给内容字段赋值
            this.Content = content;
            //给标签Id字段赋值
            this.TagId = tagId;
            //给权限Id字段赋值
            this.PermissionId = permissionId;
            //给转发字段赋值
            this.Forward = forward;
            //给点赞字段赋值
            this.Fabulous = fabulous;
            //给发布时间字段赋值
            this.ReleaseTime = releaseTime;
        }
        
		//属性存储数据的变量
        private int? _uid;
        private int _articleId;
        private string _userEquipment;
        private string _content;
        private int? _tagId;
        private int? _permissionId;
        private int? _forward;
        private int? _fabulous;
        private DateTime? _releaseTime;
        
        /// <summary>
        /// 用户Id
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// 作品Id
        /// </summary>
        public int ArticleId
        {
            get { return this._articleId; }
            set { this._articleId = value; }
        }
        /// <summary>
        /// 用户设备
        /// </summary>
        public string UserEquipment
        {
            get { return this._userEquipment; }
            set { this._userEquipment = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return this._content; }
            set { this._content = value; }
        }
        /// <summary>
        /// 标签Id
        /// </summary>
        public int? TagId
        {
            get { return this._tagId; }
            set { this._tagId = value; }
        }
        /// <summary>
        /// 权限Id
        /// </summary>
        public int? PermissionId
        {
            get { return this._permissionId; }
            set { this._permissionId = value; }
        }
        /// <summary>
        /// 转发
        /// </summary>
        public int? Forward
        {
            get { return this._forward; }
            set { this._forward = value; }
        }
        /// <summary>
        /// 点赞
        /// </summary>
        public int? Fabulous
        {
            get { return this._fabulous; }
            set { this._fabulous = value; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? ReleaseTime
        {
            get { return this._releaseTime; }
            set { this._releaseTime = value; }
        }
        
        /// <summary>
        /// 对比两个作品信息表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的作品信息表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成作品信息表数据模型对象
            ArticleInfo articleInfo = obj as ArticleInfo;
            //判断是否转换成功
            if (articleInfo == null) return false;
            //进行匹配属性的值
            return
                //判断用户Id是否一致
                this.Uid == articleInfo.Uid &&
                //判断作品Id是否一致
                this.ArticleId == articleInfo.ArticleId &&
                //判断用户设备是否一致
                this.UserEquipment == articleInfo.UserEquipment &&
                //判断内容是否一致
                this.Content == articleInfo.Content &&
                //判断标签Id是否一致
                this.TagId == articleInfo.TagId &&
                //判断权限Id是否一致
                this.PermissionId == articleInfo.PermissionId &&
                //判断转发是否一致
                this.Forward == articleInfo.Forward &&
                //判断点赞是否一致
                this.Fabulous == articleInfo.Fabulous &&
                //判断发布时间是否一致
                this.ReleaseTime == articleInfo.ReleaseTime;
        }
        /// <summary>
        /// 将当前作品信息表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将作品信息表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将用户Id进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将作品Id进行按位异或运算处理
                this.ArticleId.GetHashCode() ^
                //将用户设备进行按位异或运算处理
                (this.UserEquipment == null ? 2147483647 : this.UserEquipment.GetHashCode()) ^
                //将内容进行按位异或运算处理
                (this.Content == null ? 2147483647 : this.Content.GetHashCode()) ^
                //将标签Id进行按位异或运算处理
                (this.TagId == null ? 2147483647 : this.TagId.GetHashCode()) ^
                //将权限Id进行按位异或运算处理
                (this.PermissionId == null ? 2147483647 : this.PermissionId.GetHashCode()) ^
                //将转发进行按位异或运算处理
                (this.Forward == null ? 2147483647 : this.Forward.GetHashCode()) ^
                //将点赞进行按位异或运算处理
                (this.Fabulous == null ? 2147483647 : this.Fabulous.GetHashCode()) ^
                //将发布时间进行按位异或运算处理
                (this.ReleaseTime == null ? 2147483647 : this.ReleaseTime.GetHashCode());
        }
        /// <summary>
        /// 将当前作品信息表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前作品信息表数据模型对象转换成字符串副本
            return
                "[" +
                //将作品Id转换成字符串
                this.ArticleId +
                "]";
        }
    }
}
