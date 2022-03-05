using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// SexInfo数据模型对象
    /// </summary>
    [Serializable]
    public partial class SexInfo
    {
        /// <summary>
        /// 初始化SexInfo数据模型对象
        /// </summary>
        public SexInfo()
        {
            
        }
        /// <summary>
        /// 初始化SexInfo数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="sexId">sexId</param>
        public SexInfo(int sexId)
        {
            //给sexId字段赋值
            this.SexId = sexId;
        }
        /// <summary>
        /// 初始化SexInfo数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="sexId">sexId</param>
        /// <param name="sex">sex</param>
        public SexInfo(int sexId,string sex)
        {
            //给sexId字段赋值
            this.SexId = sexId;
            //给sex字段赋值
            this.Sex = sex;
        }
        
		//属性存储数据的变量
        private int _sexId;
        private string _sex;
        
        /// <summary>
        /// sexId
        /// </summary>
        public int SexId
        {
            get { return this._sexId; }
            set { this._sexId = value; }
        }
        /// <summary>
        /// sex
        /// </summary>
        public string Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }
        
        /// <summary>
        /// 对比两个SexInfo数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的SexInfo数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成SexInfo数据模型对象
            SexInfo sexInfo = obj as SexInfo;
            //判断是否转换成功
            if (sexInfo == null) return false;
            //进行匹配属性的值
            return
                //判断sexId是否一致
                this.SexId == sexInfo.SexId &&
                //判断sex是否一致
                this.Sex == sexInfo.Sex;
        }
        /// <summary>
        /// 将当前SexInfo数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将SexInfo数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将sexId进行按位异或运算处理
                this.SexId.GetHashCode() ^
                //将sex进行按位异或运算处理
                (this.Sex == null ? 2147483647 : this.Sex.GetHashCode());
        }
        /// <summary>
        /// 将当前SexInfo数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前SexInfo数据模型对象转换成字符串副本
            return
                "[" +
                //将sexId转换成字符串
                this.SexId +
                "]";
        }
    }
}
