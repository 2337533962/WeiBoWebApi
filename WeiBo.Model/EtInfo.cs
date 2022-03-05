using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// EtInfo数据模型对象
    /// </summary>
    [Serializable]
    public partial class EtInfo
    {
        /// <summary>
        /// 初始化EtInfo数据模型对象
        /// </summary>
        public EtInfo()
        {
            
        }
        /// <summary>
        /// 初始化EtInfo数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="et">et</param>
        /// <param name="etTo">etTo</param>
        /// <param name="etTime">etTime</param>
        public EtInfo(int? et,int? etTo,DateTime? etTime)
        {
            //给et字段赋值
            this.Et = et;
            //给etTo字段赋值
            this.EtTo = etTo;
            //给etTime字段赋值
            this.EtTime = etTime;
        }
        
		//属性存储数据的变量
        private int? _et;
        private int? _etTo;
        private DateTime? _etTime;
        
        /// <summary>
        /// et
        /// </summary>
        public int? Et
        {
            get { return this._et; }
            set { this._et = value; }
        }
        /// <summary>
        /// etTo
        /// </summary>
        public int? EtTo
        {
            get { return this._etTo; }
            set { this._etTo = value; }
        }
        /// <summary>
        /// etTime
        /// </summary>
        public DateTime? EtTime
        {
            get { return this._etTime; }
            set { this._etTime = value; }
        }
        
        /// <summary>
        /// 对比两个EtInfo数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的EtInfo数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成EtInfo数据模型对象
            EtInfo etInfo = obj as EtInfo;
            //判断是否转换成功
            if (etInfo == null) return false;
            //进行匹配属性的值
            return
                //判断et是否一致
                this.Et == etInfo.Et &&
                //判断etTo是否一致
                this.EtTo == etInfo.EtTo &&
                //判断etTime是否一致
                this.EtTime == etInfo.EtTime;
        }
        /// <summary>
        /// 将当前EtInfo数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将EtInfo数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将et进行按位异或运算处理
                (this.Et == null ? 2147483647 : this.Et.GetHashCode()) ^
                //将etTo进行按位异或运算处理
                (this.EtTo == null ? 2147483647 : this.EtTo.GetHashCode()) ^
                //将etTime进行按位异或运算处理
                (this.EtTime == null ? 2147483647 : this.EtTime.GetHashCode());
        }
        /// <summary>
        /// 将当前EtInfo数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前EtInfo数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
