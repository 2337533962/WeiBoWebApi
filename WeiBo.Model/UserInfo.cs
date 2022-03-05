using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// UserInfo数据模型对象
    /// </summary>
    [Serializable]
    public partial class UserInfo
    {
        /// <summary>
        /// 初始化UserInfo数据模型对象
        /// </summary>
        public UserInfo()
        {
            
        }
        /// <summary>
        /// 初始化UserInfo数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="uid">uid</param>
        public UserInfo(int uid)
        {
            //给uid字段赋值
            this.Uid = uid;
        }
        /// <summary>
        /// 初始化UserInfo数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="headPortrait">headPortrait</param>
        /// <param name="account">account</param>
        /// <param name="nickName">nickName</param>
        /// <param name="name">name</param>
        /// <param name="pwd">pwd</param>
        /// <param name="sexId">sexId</param>
        /// <param name="birth">birth</param>
        /// <param name="follow">follow</param>
        /// <param name="address">address</param>
        /// <param name="isDelete">isDelete</param>
        /// <param name="token">token</param>
        public UserInfo(int uid,string headPortrait,string account,string nickName,string name,string pwd,int? sexId,DateTime? birth,int? follow,string address,bool? isDelete,Guid? token)
        {
            //给uid字段赋值
            this.Uid = uid;
            //给headPortrait字段赋值
            this.HeadPortrait = headPortrait;
            //给account字段赋值
            this.Account = account;
            //给nickName字段赋值
            this.NickName = nickName;
            //给name字段赋值
            this.Name = name;
            //给pwd字段赋值
            this.Pwd = pwd;
            //给sexId字段赋值
            this.SexId = sexId;
            //给birth字段赋值
            this.Birth = birth;
            //给follow字段赋值
            this.Follow = follow;
            //给address字段赋值
            this.Address = address;
            //给isDelete字段赋值
            this.IsDelete = isDelete;
            //给token字段赋值
            this.Token = token;
        }
        
		//属性存储数据的变量
        private int _uid;
        private string _headPortrait;
        private string _account;
        private string _nickName;
        private string _name;
        private string _pwd;
        private int? _sexId;
        private DateTime? _birth;
        private int? _follow;
        private string _address;
        private bool? _isDelete;
        private Guid? _token;
        
        /// <summary>
        /// uid
        /// </summary>
        public int Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// headPortrait
        /// </summary>
        public string HeadPortrait
        {
            get { return this._headPortrait; }
            set { this._headPortrait = value; }
        }
        /// <summary>
        /// account
        /// </summary>
        public string Account
        {
            get { return this._account; }
            set { this._account = value; }
        }
        /// <summary>
        /// nickName
        /// </summary>
        public string NickName
        {
            get { return this._nickName; }
            set { this._nickName = value; }
        }
        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// pwd
        /// </summary>
        public string Pwd
        {
            get { return this._pwd; }
            set { this._pwd = value; }
        }
        /// <summary>
        /// sexId
        /// </summary>
        public int? SexId
        {
            get { return this._sexId; }
            set { this._sexId = value; }
        }
        /// <summary>
        /// birth
        /// </summary>
        public DateTime? Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }
        /// <summary>
        /// follow
        /// </summary>
        public int? Follow
        {
            get { return this._follow; }
            set { this._follow = value; }
        }
        /// <summary>
        /// address
        /// </summary>
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        /// <summary>
        /// isDelete
        /// </summary>
        public bool? IsDelete
        {
            get { return this._isDelete; }
            set { this._isDelete = value; }
        }
        /// <summary>
        /// token
        /// </summary>
        public Guid? Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        
        /// <summary>
        /// 对比两个UserInfo数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的UserInfo数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成UserInfo数据模型对象
            UserInfo userInfo = obj as UserInfo;
            //判断是否转换成功
            if (userInfo == null) return false;
            //进行匹配属性的值
            return
                //判断uid是否一致
                this.Uid == userInfo.Uid &&
                //判断headPortrait是否一致
                this.HeadPortrait == userInfo.HeadPortrait &&
                //判断account是否一致
                this.Account == userInfo.Account &&
                //判断nickName是否一致
                this.NickName == userInfo.NickName &&
                //判断name是否一致
                this.Name == userInfo.Name &&
                //判断pwd是否一致
                this.Pwd == userInfo.Pwd &&
                //判断sexId是否一致
                this.SexId == userInfo.SexId &&
                //判断birth是否一致
                this.Birth == userInfo.Birth &&
                //判断follow是否一致
                this.Follow == userInfo.Follow &&
                //判断address是否一致
                this.Address == userInfo.Address &&
                //判断isDelete是否一致
                this.IsDelete == userInfo.IsDelete &&
                //判断token是否一致
                this.Token == userInfo.Token;
        }
        /// <summary>
        /// 将当前UserInfo数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将UserInfo数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将uid进行按位异或运算处理
                this.Uid.GetHashCode() ^
                //将headPortrait进行按位异或运算处理
                (this.HeadPortrait == null ? 2147483647 : this.HeadPortrait.GetHashCode()) ^
                //将account进行按位异或运算处理
                (this.Account == null ? 2147483647 : this.Account.GetHashCode()) ^
                //将nickName进行按位异或运算处理
                (this.NickName == null ? 2147483647 : this.NickName.GetHashCode()) ^
                //将name进行按位异或运算处理
                (this.Name == null ? 2147483647 : this.Name.GetHashCode()) ^
                //将pwd进行按位异或运算处理
                (this.Pwd == null ? 2147483647 : this.Pwd.GetHashCode()) ^
                //将sexId进行按位异或运算处理
                (this.SexId == null ? 2147483647 : this.SexId.GetHashCode()) ^
                //将birth进行按位异或运算处理
                (this.Birth == null ? 2147483647 : this.Birth.GetHashCode()) ^
                //将follow进行按位异或运算处理
                (this.Follow == null ? 2147483647 : this.Follow.GetHashCode()) ^
                //将address进行按位异或运算处理
                (this.Address == null ? 2147483647 : this.Address.GetHashCode()) ^
                //将isDelete进行按位异或运算处理
                (this.IsDelete == null ? 2147483647 : this.IsDelete.GetHashCode()) ^
                //将token进行按位异或运算处理
                (this.Token == null ? 2147483647 : this.Token.GetHashCode());
        }
        /// <summary>
        /// 将当前UserInfo数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前UserInfo数据模型对象转换成字符串副本
            return
                "[" +
                //将uid转换成字符串
                this.Uid +
                "]";
        }
    }
}
