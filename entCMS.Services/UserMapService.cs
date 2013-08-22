using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class UserMapService : BaseService<cmsUserMap>
    {
        #region 实现单例模式
        private UserMapService()
        {
        }
        static UserMapService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new UserMapService();
                }
            }
        }

        public static UserMapService GetInstance()
        {
            return (UserMapService)instance;
        }
        #endregion
    }
}
