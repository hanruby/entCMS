using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class JobService : BaseService<cmsJob>
    {
        #region 私有构造函数，防止实例化
        private JobService()
        {
        }
        #endregion

        #region 实现单例模式
        static JobService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new JobService();
                }
            }
        }

        public static JobService GetInstance()
        {
            return (JobService)instance;
        }
        #endregion
        /// <summary>
        /// 取全部有效工作岗位
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsJob> GetValidList(long langId, int pageIndex, int pageSize, ref int recordCount)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsJob._.LangId == langId);
            wcb.And(cmsJob._.IsEnabled == 1 && (cmsJob._.EndTime.IsNull() || cmsJob._.EndTime>DateTime.Now));

            return GetList(wcb.ToWhereClip(), cmsJob._.OrderNo.Asc, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsJob m = GetModel(id);
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
            cmsJob m = GetModel(id);
            if (m != null)
            {
                m.Attach();
                m.IsEnabled = m.IsEnabled == 0 ? 1 : 0;
                return UpdateModel(m);
            }
            return 0;
        }
    }
}
