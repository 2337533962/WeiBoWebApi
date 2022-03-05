﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiBoWebApi.Model
{
    /// <summary>
    /// ArticleVideo数据模型对象
    /// </summary>
    [Serializable]
    public partial class ArticleVideo
    {
        /// <summary>
        /// 初始化ArticleVideo数据模型对象
        /// </summary>
        public ArticleVideo()
        {
            
        }
        /// <summary>
        /// 初始化ArticleVideo数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="articleId">articleId</param>
        /// <param name="videoUrl">videoUrl</param>
        public ArticleVideo(int? articleId,string videoUrl)
        {
            //给articleId字段赋值
            this.ArticleId = articleId;
            //给videoUrl字段赋值
            this.VideoUrl = videoUrl;
        }
        
		//属性存储数据的变量
        private int? _articleId;
        private string _videoUrl;
        
        /// <summary>
        /// articleId
        /// </summary>
        public int? ArticleId
        {
            get { return this._articleId; }
            set { this._articleId = value; }
        }
        /// <summary>
        /// videoUrl
        /// </summary>
        public string VideoUrl
        {
            get { return this._videoUrl; }
            set { this._videoUrl = value; }
        }
        
        /// <summary>
        /// 对比两个ArticleVideo数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的ArticleVideo数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成ArticleVideo数据模型对象
            ArticleVideo articleVideo = obj as ArticleVideo;
            //判断是否转换成功
            if (articleVideo == null) return false;
            //进行匹配属性的值
            return
                //判断articleId是否一致
                this.ArticleId == articleVideo.ArticleId &&
                //判断videoUrl是否一致
                this.VideoUrl == articleVideo.VideoUrl;
        }
        /// <summary>
        /// 将当前ArticleVideo数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将ArticleVideo数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将articleId进行按位异或运算处理
                (this.ArticleId == null ? 2147483647 : this.ArticleId.GetHashCode()) ^
                //将videoUrl进行按位异或运算处理
                (this.VideoUrl == null ? 2147483647 : this.VideoUrl.GetHashCode());
        }
        /// <summary>
        /// 将当前ArticleVideo数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前ArticleVideo数据模型对象转换成字符串副本
            return
                "[" +
                "]";
        }
    }
}
