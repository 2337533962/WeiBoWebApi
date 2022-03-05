﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WeiBoWebApi.DAL;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.BLL
{
    /// <summary>
    /// SecondComment业务逻辑对象
    /// </summary>
    public partial class SecondCommentBll
    {
        /// <summary>
        /// SecondComment数据访问对象
        /// </summary>
        private readonly SecondCommentDal _secondCommentDal = new SecondCommentDal();
        /// <summary>
        /// 实例化SecondComment业务逻辑对象
        /// </summary>
        public SecondCommentBll()
        {
            
        }
        /// <summary>
        /// 查询得到SecondComment表中所有信息
        /// </summary>
        /// <returns>查询到的所有SecondComment数据模型对象集合</returns>
        public List<SecondComment> GetAllModel()
        {
            //调用数据库访问层查询表中所有信息方法并将查询结果返回
            return this._secondCommentDal.GetAllModel();
        }
        /// <summary>
        /// 将传入的SecondComment数据模型对象数据存入数据库，并将自动编号值存入，传入SecondComment数据模型对象中
        /// </summary>
        /// <param name="secondComment">要进行添加到数据库的SecondComment数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(SecondComment secondComment)
        {
            //调用数据访问层的添加方法并返回是否添加成功
            return this._secondCommentDal.Add(secondComment);
        }
        /// <summary>
        /// 根据主键获取一条记录返回一个SecondComment数据模型对象
        /// </summary>
        /// <param name="secondCommentId">secondCommentId</param>
        /// <returns>如果查找到此记录就返回SecondComment数据模型对象，否则返回null</returns>
        public SecondComment GetModel(int secondCommentId)
        {
            //调用数据访问层查询方法并将查询结果返回
            return this._secondCommentDal.GetModel(secondCommentId);
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="secondCommentId">secondCommentId</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(int secondCommentId)
        {
            //调用数据访问层删除方法删除指定元素并返回是否删除成功
            return this._secondCommentDal.Delete(secondCommentId);
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="secondCommentId">secondCommentId</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(int secondCommentId)
        {
            //调用数据访问层判断是否有此记录方法并返回结果
            return this._secondCommentDal.Exists(secondCommentId);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="secondComment">SecondComment</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(SecondComment secondComment)
        {
            //调用数据访问层更新数据方法并将更新结果返回
            return this._secondCommentDal.Update(secondComment);
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="secondComment">验证的SecondComment数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(SecondComment secondComment)
        {
            //调用数据访问层的判断是否有此记录方法并返回判断结果
            return this._secondCommentDal.Exists(secondComment);
        }
        /// <summary>
        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>
        /// <param name="sqlParameters">SQL参数对象</param>
        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>
        public bool Exists(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层方法
            return this._secondCommentDal.Exists(where, sqlParameters);
        }
        /// <summary>
        /// 自定义删除
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>是否删除成功，为true成功，为false失败</returns>
        public bool Delete(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层的自定义删除方法并返回删除结果
            return this._secondCommentDal.Delete(where, sqlParameters);
        }
        /// <summary>
        /// 自定义查找
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<SecondComment> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层的自定义查找方法并将查找结果返回
            return this._secondCommentDal.GetModelList(where,sqlParameters);
        }
        /// <summary>
        /// 自定义查询出匹配记录有多少条
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>匹配记录数量</returns>
        public int GetCount(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层自定义查询出匹配记录有多少条方法并将结果返回
            return this._secondCommentDal.GetCount(where,sqlParameters);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的SecondComment数据模型对象集合</returns>
        public List<SecondComment> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法并将查询到的数据返回
            return this._secondCommentDal.GetListByPage(where,orderby,isDesc,startIndex,endIndex,sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的SecondComment数据模型对象集合</returns>
        public List<SecondComment> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法
            return this._secondCommentDal.GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="allItmeCount">总共有多少条记录</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的SecondComment数据模型对象集合</returns>
        public List<SecondComment> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法
            return this._secondCommentDal.GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, out allItmeCount, sqlParameters);
        }
    }
}
