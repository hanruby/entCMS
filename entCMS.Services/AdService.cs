using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class AdService : BaseService<cmsAd>
    {
        #region 私有构造函数，防止实例化
        private AdService()
        {
        }
        #endregion

        #region 实现单例模式
        static AdService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new AdService();
                }
            }
        }

        public static AdService GetInstance()
        {
            return (AdService)instance;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsAd m = GetModel(id);
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
            cmsAd m = GetModel(id);
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
