using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 用户行为表数据模型对象
    /// </summary>
    [Serializable]
    public partial class UserBehavior
    {
        /// <summary>
        /// 初始化用户行为表数据模型对象
        /// </summary>
        public UserBehavior()
        {
            
        }
        /// <summary>
        /// 初始化用户行为表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="userBehavior">行为</param>
        public UserBehavior(int? uid,int? userBehavior)
        {
            //给用户Id字段赋值
            this.Uid = uid;
            //给行为字段赋值
            this.Behavior = userBehavior;
        }
        
		//属性存储数据的变量
        private int? _uid;
        private int? _userBehavior;
        
        /// <summary>
        /// 用户Id
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// 行为
        /// </summary>
        public int? Behavior
        {
            get { return this._userBehavior; }
            set { this._userBehavior = value; }
        }
        
        /// <summary>
        /// 对比两个用户行为表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的用户行为表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成用户行为表数据模型对象
            UserBehavior userBehavior = obj as UserBehavior;
            //判断是否转换成功
            if (userBehavior == null) return false;
            //进行匹配属性的值
            return
                //判断用户Id是否一致
                this.Uid == userBehavior.Uid &&
                //判断行为是否一致
                this.Behavior == userBehavior.Behavior;
        }
        /// <summary>
        /// 将当前用户行为表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将用户行为表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将用户Id进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将行为进行按位异或运算处理
                (this.Behavior == null ? 2147483647 : this.Behavior.GetHashCode());
        }
        /// <summary>
        /// 将当前用户行为表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前用户行为表数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
