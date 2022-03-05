using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// ArticleInfo数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleInfo
    {
        /// <summary>
        /// 初始化ArticleInfo数据模型对象
        /// </summary>
        public ArticleInfo()
        {
            
        }
        /// <summary>
        /// 初始化ArticleInfo数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="articleId">articleId</param>
        public ArticleInfo(int articleId)
        {
            //给articleId字段赋值
            this.ArticleId = articleId;
        }
        /// <summary>
        /// 初始化ArticleInfo数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="articleId">articleId</param>
        /// <param name="userEquipment">userEquipment</param>
        /// <param name="content">content</param>
        /// <param name="tagId">tagId</param>
        /// <param name="permissionId">permissionId</param>
        /// <param name="forward">forward</param>
        /// <param name="fabulous">fabulous</param>
        public ArticleInfo(int? uid,int articleId,string userEquipment,string content,int? tagId,int? permissionId,int? forward,int? fabulous)
        {
            //给uid字段赋值
            this.Uid = uid;
            //给articleId字段赋值
            this.ArticleId = articleId;
            //给userEquipment字段赋值
            this.UserEquipment = userEquipment;
            //给content字段赋值
            this.Content = content;
            //给tagId字段赋值
            this.TagId = tagId;
            //给permissionId字段赋值
            this.PermissionId = permissionId;
            //给forward字段赋值
            this.Forward = forward;
            //给fabulous字段赋值
            this.Fabulous = fabulous;
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
        
        /// <summary>
        /// uid
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// articleId
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
        /// permissionId
        /// </summary>
        public int? PermissionId
        {
            get { return this._permissionId; }
            set { this._permissionId = value; }
        }
        /// <summary>
        /// forward
        /// </summary>
        public int? Forward
        {
            get { return this._forward; }
            set { this._forward = value; }
        }
        /// <summary>
        /// fabulous
        /// </summary>
        public int? Fabulous
        {
            get { return this._fabulous; }
            set { this._fabulous = value; }
        }
        
        /// <summary>
        /// 对比两个ArticleInfo数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的ArticleInfo数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成ArticleInfo数据模型对象
            ArticleInfo articleInfo = obj as ArticleInfo;
            //判断是否转换成功
            if (articleInfo == null) return false;
            //进行匹配属性的值
            return
                //判断uid是否一致
                this.Uid == articleInfo.Uid &&
                //判断articleId是否一致
                this.ArticleId == articleInfo.ArticleId &&
                //判断userEquipment是否一致
                this.UserEquipment == articleInfo.UserEquipment &&
                //判断content是否一致
                this.Content == articleInfo.Content &&
                //判断tagId是否一致
                this.TagId == articleInfo.TagId &&
                //判断permissionId是否一致
                this.PermissionId == articleInfo.PermissionId &&
                //判断forward是否一致
                this.Forward == articleInfo.Forward &&
                //判断fabulous是否一致
                this.Fabulous == articleInfo.Fabulous;
        }
        /// <summary>
        /// 将当前ArticleInfo数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将ArticleInfo数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将uid进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将articleId进行按位异或运算处理
                this.ArticleId.GetHashCode() ^
                //将userEquipment进行按位异或运算处理
                (this.UserEquipment == null ? 2147483647 : this.UserEquipment.GetHashCode()) ^
                //将content进行按位异或运算处理
                (this.Content == null ? 2147483647 : this.Content.GetHashCode()) ^
                //将tagId进行按位异或运算处理
                (this.TagId == null ? 2147483647 : this.TagId.GetHashCode()) ^
                //将permissionId进行按位异或运算处理
                (this.PermissionId == null ? 2147483647 : this.PermissionId.GetHashCode()) ^
                //将forward进行按位异或运算处理
                (this.Forward == null ? 2147483647 : this.Forward.GetHashCode()) ^
                //将fabulous进行按位异或运算处理
                (this.Fabulous == null ? 2147483647 : this.Fabulous.GetHashCode());
        }
        /// <summary>
        /// 将当前ArticleInfo数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前ArticleInfo数据模型对象转换成字符串副本
            return
                "[" +
                //将articleId转换成字符串
                this.ArticleId +
                "]";
        }
    }
}
