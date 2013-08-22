using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class LanguageService : BaseService<cmsLanguage>
    {
        #region 私有构造函数，防止实例化
        private LanguageService()
        {
        }
        #endregion

        #region 实现单例模式
        static LanguageService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new LanguageService();
                }
            }
        }

        public static LanguageService GetInstance()
        {
            return (LanguageService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsLanguage> GetList()
        {
            return GetList(null, cmsLanguage._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsLanguage> GetLanguages()
        {
            return GetList(cmsLanguage._.IsEnabled == 1, cmsLanguage._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsLanguage> GetList(int pageIndex, int pageSize, ref int recordCount)
        {
            return GetList(null, cmsLanguage._.OrderNo.Asc, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsLanguage m = Get(id);
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
        public int SetDefault(string id)
        {
            cmsLanguage m = Get(id);
            if (m != null)
            {
                m.Attach();
                m.IsDefault = m.IsDefault.HasValue ? (m.IsDefault.Value == 0 ? 1 : 0) : 1;
                if (m.IsDefault.Value == 1)
                {
                    ClearDefault();
                }
                return UpdateModel(m);
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ClearDefault()
        {
            return UpdateModels(cmsLanguage._.IsDefault, 0, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Enable(string id)
        {
            cmsLanguage m = Get(id);
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
        public cmsLanguage Get(string id)
        {
            return GetModelWithWhere(cmsLanguage._.Id == id);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Save(cmsLanguage m)
        {
            if (m.IsDefault.Value == 1)
            {
                ClearDefault();
            }
            return SaveModel(m);
        }
    }
}
