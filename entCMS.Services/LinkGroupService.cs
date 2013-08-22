using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class LinkGroupService : BaseService<cmsLinkGroup>
    {
        #region 私有构造函数，防止实例化
        private LinkGroupService()
        {
        }
        #endregion

        #region 实现单例模式
        static LinkGroupService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new LinkGroupService();
                }
            }
        }

        public static LinkGroupService GetInstance()
        {
            return (LinkGroupService)instance;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsLinkGroup> GetEnabledList()
        {
            return GetList(cmsLinkGroup._.IsEnabled == 1, cmsLinkGroup._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lngId"></param>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public List<cmsLinkGroup> GetList(long? lngId, int? isEnabled)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (lngId.HasValue) wcb.And(cmsLinkGroup._.LangId == lngId.Value);
            if (isEnabled.HasValue) wcb.And(cmsLinkGroup._.IsEnabled == isEnabled.Value);

            return GetList(wcb.ToWhereClip(), cmsLinkGroup._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsLinkGroup> GetList(int pageIndex, int pageSize, ref int recordCount)
        {
            return GetList(null, cmsLinkGroup._.OrderNo.Asc, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsLinkGroup m = Get(id);
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
        public int Enable(string id)
        {
            cmsLinkGroup m = Get(id);
            if (m != null)
            {
                m.Attach();
                m.IsEnabled = m.IsEnabled.HasValue ? (m.IsEnabled.Value == 0 ? 1 : 0) : 1;
                return UpdateModel(m);
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public cmsLinkGroup Get(string id)
        {
            return GetModelWithWhere(cmsLinkGroup._.Id == id);
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
