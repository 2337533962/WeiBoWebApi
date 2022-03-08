using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// @信息表数据模型对象
    /// </summary>
    [Serializable]
    public partial class EtInfo
    {
        /// <summary>
        /// 初始化@信息表数据模型对象
        /// </summary>
        public EtInfo()
        {
            
        }
        /// <summary>
        /// 初始化@信息表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="et">@人</param>
        /// <param name="etTo">被@人</param>
        /// <param name="etTime">@时间</param>
        public EtInfo(int? et,int? etTo,DateTime? etTime)
        {
            //给@人字段赋值
            this.Et = et;
            //给被@人字段赋值
            this.EtTo = etTo;
            //给@时间字段赋值
            this.EtTime = etTime;
        }
        
		//属性存储数据的变量
        private int? _et;
        private int? _etTo;
        private DateTime? _etTime;
        
        /// <summary>
        /// @人
        /// </summary>
        public int? Et
        {
            get { return this._et; }
            set { this._et = value; }
        }
        /// <summary>
        /// 被@人
        /// </summary>
        public int? EtTo
        {
            get { return this._etTo; }
            set { this._etTo = value; }
        }
        /// <summary>
        /// @时间
        /// </summary>
        public DateTime? EtTime
        {
            get { return this._etTime; }
            set { this._etTime = value; }
        }
        
        /// <summary>
        /// 对比两个@信息表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的@信息表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成@信息表数据模型对象
            EtInfo etInfo = obj as EtInfo;
            //判断是否转换成功
            if (etInfo == null) return false;
            //进行匹配属性的值
            return
                //判断@人是否一致
                this.Et == etInfo.Et &&
                //判断被@人是否一致
                this.EtTo == etInfo.EtTo &&
                //判断@时间是否一致
                this.EtTime == etInfo.EtTime;
        }
        /// <summary>
        /// 将当前@信息表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将@信息表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将@人进行按位异或运算处理
                (this.Et == null ? 2147483647 : this.Et.GetHashCode()) ^
                //将被@人进行按位异或运算处理
                (this.EtTo == null ? 2147483647 : this.EtTo.GetHashCode()) ^
                //将@时间进行按位异或运算处理
                (this.EtTime == null ? 2147483647 : this.EtTime.GetHashCode());
        }
        /// <summary>
        /// 将当前@信息表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前@信息表数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
