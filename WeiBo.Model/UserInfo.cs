using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// 用户信息表数据模型对象
    /// </summary>
    [Serializable]
    public partial class UserInfo
    {
        /// <summary>
        /// 初始化用户信息表数据模型对象
        /// </summary>
        public UserInfo()
        {
            
        }
        /// <summary>
        /// 初始化用户信息表数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="uid">用户Id</param>
        public UserInfo(int uid)
        {
            //给用户Id字段赋值
            this.Uid = uid;
        }
        /// <summary>
        /// 初始化用户信息表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="headPortrait">头像</param>
        /// <param name="account">账号</param>
        /// <param name="nickName">昵称</param>
        /// <param name="name">姓名</param>
        /// <param name="pwd">密码</param>
        /// <param name="sexId">性别Id</param>
        /// <param name="birth">生日</param>
        /// <param name="follow">粉丝</param>
        /// <param name="address">地址</param>
        /// <param name="isDelete">是否删除</param>
        /// <param name="token">令牌</param>
        /// <param name="overdue">过期</param>
        public UserInfo(int uid,string headPortrait,string account,string nickName,string name,string pwd,int? sexId,DateTime? birth,int? follow,string address,bool? isDelete,Guid? token,DateTime? overdue)
        {
            //给用户Id字段赋值
            this.Uid = uid;
            //给头像字段赋值
            this.HeadPortrait = headPortrait;
            //给账号字段赋值
            this.Account = account;
            //给昵称字段赋值
            this.NickName = nickName;
            //给姓名字段赋值
            this.Name = name;
            //给密码字段赋值
            this.Pwd = pwd;
            //给性别Id字段赋值
            this.SexId = sexId;
            //给生日字段赋值
            this.Birth = birth;
            //给粉丝字段赋值
            this.Follow = follow;
            //给地址字段赋值
            this.Address = address;
            //给是否删除字段赋值
            this.IsDelete = isDelete;
            //给令牌字段赋值
            this.Token = token;
            //给过期字段赋值
            this.Overdue = overdue;
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
        private DateTime? _overdue;
        
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait
        {
            get { return this._headPortrait; }
            set { this._headPortrait = value; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get { return this._account; }
            set { this._account = value; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get { return this._nickName; }
            set { this._nickName = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return this._pwd; }
            set { this._pwd = value; }
        }
        /// <summary>
        /// 性别Id
        /// </summary>
        public int? SexId
        {
            get { return this._sexId; }
            set { this._sexId = value; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }
        /// <summary>
        /// 粉丝
        /// </summary>
        public int? Follow
        {
            get { return this._follow; }
            set { this._follow = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? IsDelete
        {
            get { return this._isDelete; }
            set { this._isDelete = value; }
        }
        /// <summary>
        /// 令牌
        /// </summary>
        public Guid? Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        /// <summary>
        /// 过期
        /// </summary>
        public DateTime? Overdue
        {
            get { return this._overdue; }
            set { this._overdue = value; }
        }
        
        /// <summary>
        /// 对比两个用户信息表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的用户信息表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成用户信息表数据模型对象
            UserInfo userInfo = obj as UserInfo;
            //判断是否转换成功
            if (userInfo == null) return false;
            //进行匹配属性的值
            return
                //判断用户Id是否一致
                this.Uid == userInfo.Uid &&
                //判断头像是否一致
                this.HeadPortrait == userInfo.HeadPortrait &&
                //判断账号是否一致
                this.Account == userInfo.Account &&
                //判断昵称是否一致
                this.NickName == userInfo.NickName &&
                //判断姓名是否一致
                this.Name == userInfo.Name &&
                //判断密码是否一致
                this.Pwd == userInfo.Pwd &&
                //判断性别Id是否一致
                this.SexId == userInfo.SexId &&
                //判断生日是否一致
                this.Birth == userInfo.Birth &&
                //判断粉丝是否一致
                this.Follow == userInfo.Follow &&
                //判断地址是否一致
                this.Address == userInfo.Address &&
                //判断是否删除是否一致
                this.IsDelete == userInfo.IsDelete &&
                //判断令牌是否一致
                this.Token == userInfo.Token &&
                //判断过期是否一致
                this.Overdue == userInfo.Overdue;
        }
        /// <summary>
        /// 将当前用户信息表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将用户信息表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将用户Id进行按位异或运算处理
                this.Uid.GetHashCode() ^
                //将头像进行按位异或运算处理
                (this.HeadPortrait == null ? 2147483647 : this.HeadPortrait.GetHashCode()) ^
                //将账号进行按位异或运算处理
                (this.Account == null ? 2147483647 : this.Account.GetHashCode()) ^
                //将昵称进行按位异或运算处理
                (this.NickName == null ? 2147483647 : this.NickName.GetHashCode()) ^
                //将姓名进行按位异或运算处理
                (this.Name == null ? 2147483647 : this.Name.GetHashCode()) ^
                //将密码进行按位异或运算处理
                (this.Pwd == null ? 2147483647 : this.Pwd.GetHashCode()) ^
                //将性别Id进行按位异或运算处理
                (this.SexId == null ? 2147483647 : this.SexId.GetHashCode()) ^
                //将生日进行按位异或运算处理
                (this.Birth == null ? 2147483647 : this.Birth.GetHashCode()) ^
                //将粉丝进行按位异或运算处理
                (this.Follow == null ? 2147483647 : this.Follow.GetHashCode()) ^
                //将地址进行按位异或运算处理
                (this.Address == null ? 2147483647 : this.Address.GetHashCode()) ^
                //将是否删除进行按位异或运算处理
                (this.IsDelete == null ? 2147483647 : this.IsDelete.GetHashCode()) ^
                //将令牌进行按位异或运算处理
                (this.Token == null ? 2147483647 : this.Token.GetHashCode()) ^
                //将过期进行按位异或运算处理
                (this.Overdue == null ? 2147483647 : this.Overdue.GetHashCode());
        }
        /// <summary>
        /// 将当前用户信息表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前用户信息表数据模型对象转换成字符串副本
            return
                "[" +
                //将用户Id转换成字符串
                this.Uid +
                "]";
        }
    }
}
