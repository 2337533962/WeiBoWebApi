using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 关注信息表数据模型对象
    /// </summary>
    [Serializable]
    public partial class AttentionInfo
    {
        /// <summary>
        /// 初始化关注信息表数据模型对象
        /// </summary>
        public AttentionInfo()
        {
            
        }
        /// <summary>
        /// 初始化关注信息表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="followId">关注人</param>
        /// <param name="followToId">被关注人</param>
        public AttentionInfo(int? followId,int? followToId)
        {
            //给关注人字段赋值
            this.FollowId = followId;
            //给被关注人字段赋值
            this.FollowToId = followToId;
        }
        
		//属性存储数据的变量
        private int? _followId;
        private int? _followToId;
        
        /// <summary>
        /// 关注人
        /// </summary>
        public int? FollowId
        {
            get { return this._followId; }
            set { this._followId = value; }
        }
        /// <summary>
        /// 被关注人
        /// </summary>
        public int? FollowToId
        {
            get { return this._followToId; }
            set { this._followToId = value; }
        }
        
        /// <summary>
        /// 对比两个关注信息表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的关注信息表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成关注信息表数据模型对象
            AttentionInfo attentionInfo = obj as AttentionInfo;
            //判断是否转换成功
            if (attentionInfo == null) return false;
            //进行匹配属性的值
            return
                //判断关注人是否一致
                this.FollowId == attentionInfo.FollowId &&
                //判断被关注人是否一致
                this.FollowToId == attentionInfo.FollowToId;
        }
        /// <summary>
        /// 将当前关注信息表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将关注信息表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将关注人进行按位异或运算处理
                (this.FollowId == null ? 2147483647 : this.FollowId.GetHashCode()) ^
                //将被关注人进行按位异或运算处理
                (this.FollowToId == null ? 2147483647 : this.FollowToId.GetHashCode());
        }
        /// <summary>
        /// 将当前关注信息表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前关注信息表数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
