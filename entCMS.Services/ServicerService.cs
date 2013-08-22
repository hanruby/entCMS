using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class ServicerService : BaseService<cmsServicer>
    {
        #region 私有构造函数，防止实例化
        private ServicerService()
        {
        }
        #endregion

        #region 实现单例模式
        static ServicerService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new ServicerService();
                }
            }
        }

        public static ServicerService GetInstance()
        {
            return (ServicerService)instance;
        }
        #endregion

        /// <summary>
        /// 根据语言获取客服列表
        /// </summary>
        /// <param name="lngId"></param>
        /// <returns></returns>
        public List<cmsServicer> GetListByLang(long lngId)
        {
            return GetList(cmsServicer._.LangId == lngId && cmsServicer._.IsEnabled == 1, cmsServicer._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsServicer m = GetModel(id);
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
            cmsServicer m = GetModel(id);
            if (m != null)
            {
                m.Attach();
                m.IsEnabled = m.IsEnabled.HasValue ? (m.IsEnabled.Value == 0 ? 1 : 0) : 1;
                return UpdateModel(m);
            }
            return 0;
        }
    }
}
