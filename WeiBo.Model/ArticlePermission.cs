using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 作品权限表数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticlePermission
    {
        /// <summary>
        /// 初始化作品权限表数据模型对象
        /// </summary>
        public ArticlePermission()
        {
            
        }
        /// <summary>
        /// 初始化作品权限表数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="permissionId">权限Id</param>
        public ArticlePermission(int permissionId)
        {
            //给权限Id字段赋值
            this.PermissionId = permissionId;
        }
        /// <summary>
        /// 初始化作品权限表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="permissionId">权限Id</param>
        /// <param name="permission">权限</param>
        public ArticlePermission(int permissionId,string permission)
        {
            //给权限Id字段赋值
            this.PermissionId = permissionId;
            //给权限字段赋值
            this.Permission = permission;
        }
        
		//属性存储数据的变量
        private int _permissionId;
        private string _permission;
        
        /// <summary>
        /// 权限Id
        /// </summary>
        public int PermissionId
        {
            get { return this._permissionId; }
            set { this._permissionId = value; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        public string Permission
        {
            get { return this._permission; }
            set { this._permission = value; }
        }
        
        /// <summary>
        /// 对比两个作品权限表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的作品权限表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成作品权限表数据模型对象
            ArticlePermission articlePermission = obj as ArticlePermission;
            //判断是否转换成功
            if (articlePermission == null) return false;
            //进行匹配属性的值
            return
                //判断权限Id是否一致
                this.PermissionId == articlePermission.PermissionId &&
                //判断权限是否一致
                this.Permission == articlePermission.Permission;
        }
        /// <summary>
        /// 将当前作品权限表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将作品权限表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将权限Id进行按位异或运算处理
                this.PermissionId.GetHashCode() ^
                //将权限进行按位异或运算处理
                (this.Permission == null ? 2147483647 : this.Permission.GetHashCode());
        }
        /// <summary>
        /// 将当前作品权限表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前作品权限表数据模型对象转换成字符串副本
            return
                "[" +
                //将权限Id转换成字符串
                this.PermissionId +
                "]";
        }
    }
}
