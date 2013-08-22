using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class NewsTopicService : BaseService<cmsNewsTopic>
    {
        #region 私有构造函数，防止实例化
        private NewsTopicService()
        {
        }
        #endregion

        #region 实现单例模式
        static NewsTopicService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new NewsTopicService();
                }
            }
        }

        public static NewsTopicService GetInstance()
        {
            return (NewsTopicService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsNewsTopic> GetList(int pageIndex, int pageSize, ref int recordCount)
        {
            return GetList(null, cmsNewsTopic._.Id.Desc, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsNewsTopic m = Get(id);
            if (m != null)
            {
                m.Attach();
                m.SortNo = order;
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
            cmsNewsTopic m = Get(id);
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
        public cmsNewsTopic Get(string id)
        {
            return GetModelWithWhere(cmsNewsTopic._.Id == id);
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
