using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using System.Data;
using Hxj.Data;

namespace entCMS.Services
{
    public class ProductService : BaseService<cmsProduct>
    {
        #region 私有构造函数，防止实例化
        private ProductService()
        {
        }
        #endregion

        #region 实现单例模式
        static ProductService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new ProductService();
                }
            }
        }

        public static ProductService GetInstance()
        {
            return (ProductService)instance;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="isLike"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetList(string nodecode, bool isLike, int pageIndex, int pageSize, ref int recordCount)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsProduct._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsProduct._.NodeCode.BeginWith(nodecode));
                }
            }

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsProduct._.NodeCode)
                .Select(cmsProduct._.All, cmsNewsCatalog._.NodeName)
                .OrderBy(cmsProduct._.IsTop.Desc && cmsProduct._.EditTime.Desc);

            recordCount = fs.Count();

            return fs.Page(pageSize, pageIndex).ToDataTable();
        }
        /// <summary>
        /// 根据栏目编号获取推荐到首页的列表
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="top"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public DataTable GetIndexList(string nodecode, int top, bool isLike)
        {
            if (top <= 0 || top > 10) top = 10;
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsProduct._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsProduct._.NodeCode.BeginWith(nodecode));
                }
            }
            wcb.And(cmsProduct._.IsIndex == 1); // 推荐到首页的

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsProduct._.NodeCode)
                .Select(cmsProduct._.All, cmsNewsCatalog._.NodeName)
                .Top(top)
                .OrderBy(cmsProduct._.IsTop.Desc && cmsProduct._.EditTime.Desc);

            return fs.ToDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int EnableIndex(string gid)
        {
            cmsProduct n = GetModel(gid);
            if (n != null)
            {
                n.Attach();

                n.IsIndex = (n.IsIndex.Value == 0) ? 1 : 0;

                return UpdateModel(n);
            }
            return 0;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int EnableTop(string gid)
        {
            cmsProduct n = GetModel(gid);
            if (n != null)
            {
                n.Attach();

                n.IsTop = (n.IsTop.Value == 0) ? 1 : 0;

                return UpdateModel(n);
            }
            return 0;

        }

        public int CopyTo(string[] ids, string[] nodes)
        {
            if (ids.Length == 0) throw new Exception("被复制的产品未选择！");
            if (nodes.Length == 0) throw new Exception("要复制到的栏目未选择！");

            int r = 0;

            try
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = 0; j < ids.Length; j++)
                    {
                        string sql = @"insert into cmsProduct(RGuid,NodeCode,Title,Content,Summary,SmallPic,Hits,AddTime,AddUser,EditTime,EditUser,OrderNo,IsIndex,IsTop,ProductNo,Model,Parameter1,Parameter2,Parameter3,Parameter4,Parameter5)
                                   select '{0}','{1}',Title,Content,Summary,Tags,Author,Source,SmallPic,Hits,AddTime,AddUser,EditTime,EditUser,OrderNo,IsIndex,IsTop,IsAudit,AuditTime,AuditUser,AuditComment from cmsNews 
                                   where 1=1 and Id='{2}'";
                        sql = string.Format(sql, Guid.NewGuid().ToString(), nodes[i], ids[j]);
                        r = DBSession.CurrentSession.FromSql(sql).ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }

        public int MoveTo(string[] ids, string[] nodes)
        {
            if (ids.Length == 0) throw new Exception("被移动的产品未选择！");
            if (nodes.Length == 0) throw new Exception("要移动到的栏目未选择！");

            int r = 0;

            try
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    string sql = @"update cmsNews set nodecode='{0}' where 1=1 and Id in ('{1}')";
                    sql = string.Format(sql, nodes[i], string.Join("','", ids).Replace("'0',", ""));

                    r = DBSession.CurrentSession.FromSql(sql).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
    }
}
