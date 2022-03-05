using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// ArticlePermission数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticlePermission
    {
        /// <summary>
        /// 初始化ArticlePermission数据模型对象
        /// </summary>
        public ArticlePermission()
        {
            
        }
        /// <summary>
        /// 初始化ArticlePermission数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="permissionId">permissionId</param>
        public ArticlePermission(int permissionId)
        {
            //给permissionId字段赋值
            this.PermissionId = permissionId;
        }
        /// <summary>
        /// 初始化ArticlePermission数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="permissionId">permissionId</param>
        /// <param name="permission">permission</param>
        public ArticlePermission(int permissionId,string permission)
        {
            //给permissionId字段赋值
            this.PermissionId = permissionId;
            //给permission字段赋值
            this.Permission = permission;
        }
        
		//属性存储数据的变量
        private int _permissionId;
        private string _permission;
        
        /// <summary>
        /// permissionId
        /// </summary>
        public int PermissionId
        {
            get { return this._permissionId; }
            set { this._permissionId = value; }
        }
        /// <summary>
        /// permission
        /// </summary>
        public string Permission
        {
            get { return this._permission; }
            set { this._permission = value; }
        }
        
        /// <summary>
        /// 对比两个ArticlePermission数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的ArticlePermission数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成ArticlePermission数据模型对象
            ArticlePermission articlePermission = obj as ArticlePermission;
            //判断是否转换成功
            if (articlePermission == null) return false;
            //进行匹配属性的值
            return
                //判断permissionId是否一致
                this.PermissionId == articlePermission.PermissionId &&
                //判断permission是否一致
                this.Permission == articlePermission.Permission;
        }
        /// <summary>
        /// 将当前ArticlePermission数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将ArticlePermission数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将permissionId进行按位异或运算处理
                this.PermissionId.GetHashCode() ^
                //将permission进行按位异或运算处理
                (this.Permission == null ? 2147483647 : this.Permission.GetHashCode());
        }
        /// <summary>
        /// 将当前ArticlePermission数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前ArticlePermission数据模型对象转换成字符串副本
            return
                "[" +
                //将permissionId转换成字符串
                this.PermissionId +
                "]";
        }
    }
}
