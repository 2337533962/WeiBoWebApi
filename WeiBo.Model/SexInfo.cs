using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 性别信息表数据模型对象
    /// </summary>
    [Serializable]
    public partial class SexInfo
    {
        /// <summary>
        /// 初始化性别信息表数据模型对象
        /// </summary>
        public SexInfo()
        {
            
        }
        /// <summary>
        /// 初始化性别信息表数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="sexId">性别Id</param>
        public SexInfo(int sexId)
        {
            //给性别Id字段赋值
            this.SexId = sexId;
        }
        /// <summary>
        /// 初始化性别信息表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="sexId">性别Id</param>
        /// <param name="sex">性别</param>
        public SexInfo(int sexId,string sex)
        {
            //给性别Id字段赋值
            this.SexId = sexId;
            //给性别字段赋值
            this.Sex = sex;
        }
        
		//属性存储数据的变量
        private int _sexId;
        private string _sex;
        
        /// <summary>
        /// 性别Id
        /// </summary>
        public int SexId
        {
            get { return this._sexId; }
            set { this._sexId = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }
        
        /// <summary>
        /// 对比两个性别信息表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的性别信息表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成性别信息表数据模型对象
            SexInfo sexInfo = obj as SexInfo;
            //判断是否转换成功
            if (sexInfo == null) return false;
            //进行匹配属性的值
            return
                //判断性别Id是否一致
                this.SexId == sexInfo.SexId &&
                //判断性别是否一致
                this.Sex == sexInfo.Sex;
        }
        /// <summary>
        /// 将当前性别信息表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将性别信息表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将性别Id进行按位异或运算处理
                this.SexId.GetHashCode() ^
                //将性别进行按位异或运算处理
                (this.Sex == null ? 2147483647 : this.Sex.GetHashCode());
        }
        /// <summary>
        /// 将当前性别信息表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前性别信息表数据模型对象转换成字符串副本
            return
                "[" +
                //将性别Id转换成字符串
                this.SexId +
                "]";
        }
    }
}
