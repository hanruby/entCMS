using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class NewsTopicRelService : BaseService<cmsNewsTopicRel>
    {
        #region 私有构造函数，防止实例化
        private NewsTopicRelService()
        {
        }
        #endregion

        #region 实现单例模式
        static NewsTopicRelService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new NewsTopicRelService();
                }
            }
        }

        public static NewsTopicRelService GetInstance()
        {
            return (NewsTopicRelService)instance;
        }
        #endregion

        public int Save(string NewsId, int[] ztArr)
        {
            try
            {
                DeleteModels(cmsNewsTopicRel._.NewsId == NewsId);

                foreach (int zt in ztArr)
                {
                    cmsNewsTopicRel r = new cmsNewsTopicRel();
                    r.NewsId = NewsId;
                    r.TopicId = zt;

                    AddModel(r);
                }

                return ztArr.Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
