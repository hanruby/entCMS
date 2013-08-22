using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class PurviewService : BaseService<cmsUserPurview>
    {
        #region 实现单例模式
        private PurviewService()
        {
        }
        static PurviewService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new PurviewService();
                }
            }
        }

        public static PurviewService GetInstance()
        {
            return (PurviewService)instance;
        }
        #endregion
        
    }
}
