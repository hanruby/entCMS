using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using System.Data;
using Hxj.Data;

namespace entCMS.Services
{
    public class LinkService : BaseService<cmsLink>
    {
        #region 私有构造函数，防止实例化
        private LinkService()
        {
        }
        #endregion

        #region 实现单例模式
        static LinkService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new LinkService();
                }
            }
        }

        public static LinkService GetInstance()
        {
            return (LinkService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(WhereClip where, int pageIndex, int pageSize, ref int recordCount)
        {
            FromSection fs = GetFromSection(null, null)
                .LeftJoin<cmsLinkGroup>(cmsLinkGroup._.Id == cmsLink._.GroupId)
                .Select(cmsLink._.All, cmsLinkGroup._.Name.As("TypeName"))
                .Where(where)
                .OrderBy(cmsLink._.GroupId.Asc && cmsLink._.OrderNo.Asc && cmsLink._.Id.Desc);
            recordCount = fs.Count();

            return fs
                .Page(pageSize, pageIndex)
                .ToDataTable();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int pageIndex, int pageSize, ref int recordCount)
        {
            FromSection fs = GetFromSection(null, null)
                .LeftJoin<cmsLinkGroup>(cmsLinkGroup._.Id == cmsLink._.GroupId)
                .Select(cmsLink._.All, cmsLinkGroup._.Name.As("TypeName"))
                .OrderBy(cmsLink._.GroupId.Asc && cmsLink._.OrderNo.Asc && cmsLink._.Id.Desc);
            recordCount = fs.Count();

            return fs
                .Page(pageSize, pageIndex)
                .ToDataTable();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsLink> GetList(int pageIndex, int pageSize, ref int recordCount)
        {
            return GetList(null, cmsLink._.OrderNo.Asc, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsLink m = Get(id);
            if (m != null)
            {
                m.Attach();
                m.OrderNo = order;
                return UpdateModel(m);
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public cmsLink Get(string id)
        {
            return GetModelWithWhere(cmsLink._.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            return DeleteModel(id);
        }
    }
}
