using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public sealed class SlideshowService : BaseService<cmsSlideshow>
    {
        #region 私有构造函数，防止实例化
        private SlideshowService()
        {
        }
        #endregion

        #region 实现单例模式
        static SlideshowService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new SlideshowService();
                }
            }
        }

        public static SlideshowService GetInstance()
        {
            return (SlideshowService)instance;
        }
        #endregion

        /// <summary>
        /// 获取某种语言下的幻灯片列表
        /// </summary>
        /// <param name="lngId"></param>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public List<cmsSlideshow> GetListByLangId(long lngId, bool? isEnabled = null)
        {
            WhereClipBuilder wcb = new WhereClipBuilder(cmsSlideshow._.LangId == lngId);
            if (isEnabled.HasValue) wcb.And(cmsSlideshow._.IsEnabled == isEnabled.Value);

            return GetList(wcb.ToWhereClip(), cmsSlideshow._.OrderNo.Asc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsSlideshow m = GetModel(id);
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
            cmsSlideshow m = GetModel(id);
            if (m != null)
            {
                m.Attach();
                m.IsEnabled = (m.IsEnabled == 0 ? 1 : 0);
                return UpdateModel(m);
            }
            return 0;
        }


    }
}
