using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// Behavior数据模型对象
    /// </summary>
    [Serializable]
    public partial class UserBehavior
    {
        /// <summary>
        /// 初始化Behavior数据模型对象
        /// </summary>
        public UserBehavior()
        {
            
        }
        /// <summary>
        /// 初始化Behavior数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="behavior">behavior</param>
        public UserBehavior(int? uid,int? behavior)
        {
            //给uid字段赋值
            this.Uid = uid;
            //给behavior字段赋值
            this.Behavior = behavior;
        }
        
		//属性存储数据的变量
        private int? _uid;
        private int? _behavior;
        
        /// <summary>
        /// uid
        /// </summary>
        public int? Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// behavior
        /// </summary>
        public int? Behavior
        {
            get { return this._behavior; }
            set { this._behavior = value; }
        }
        
        /// <summary>
        /// 对比两个Behavior数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的Behavior数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成Behavior数据模型对象
            UserBehavior behavior = obj as UserBehavior;
            //判断是否转换成功
            if (behavior == null) return false;
            //进行匹配属性的值
            return
                //判断uid是否一致
                this.Uid == behavior.Uid &&
                //判断behavior是否一致
                this.Behavior == behavior.Behavior;
        }
        /// <summary>
        /// 将当前Behavior数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将Behavior数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将uid进行按位异或运算处理
                (this.Uid == null ? 2147483647 : this.Uid.GetHashCode()) ^
                //将behavior进行按位异或运算处理
                (this.Behavior == null ? 2147483647 : this.Behavior.GetHashCode());
        }
        /// <summary>
        /// 将当前Behavior数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前Behavior数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
