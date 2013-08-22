using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class ModuleService : BaseService<cmsModule>
    {
        #region 私有构造函数，防止实例化
        private ModuleService()
        {
        }
        #endregion

        #region 实现单例模式
        static ModuleService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new ModuleService();
                }
            }
        }

        public static ModuleService GetInstance()
        {
            return (ModuleService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public List<cmsModule> GetList(bool? isEnabled)
        {
            if (isEnabled.HasValue)
            {
                return GetList(cmsModule._.IsEnabled == (isEnabled.Value ? 1 : 0), cmsModule._.OrderNo.Asc);
            }
            else
            {
                return GetList(null, null);
            }
        }
    }
}
