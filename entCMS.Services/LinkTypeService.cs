using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class LinkTypeService : BaseService<cmsLinkGroup>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsLinkGroup> GetLinkTypes()
        {
            return GetList(cmsLinkGroup._.IsEnabled == 1, cmsLinkGroup._.OrderNo.Asc);
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
            return GetModel(cmsLinkGroup._.Id == id);
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
