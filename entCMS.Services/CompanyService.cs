using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using System.Data;
using Hxj.Data;

namespace entCMS.Services
{
    public class CompanyService : BaseService<cmsCompany>
    {
        #region 私有构造函数，防止实例化
        private CompanyService()
        {
        }
        #endregion

        #region 实现单例模式
        static CompanyService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new CompanyService();
                }
            }
        }

        public static CompanyService GetInstance()
        {
            return (CompanyService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lngId"></param>
        /// <returns></returns>
        public cmsCompany GetByLangId(long lngId)
        {
            return GetModelWithWhere(cmsCompany._.LangId == lngId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lngId"></param>
        /// <returns></returns>
        public bool Exists(long lngId)
        {
            return Exists(cmsCompany._.LangId == lngId);
        }

        public DataTable GetDataTableWithLang()
        {
            FromSection<cmsCompany> fs = GetFromSection(null, null);

            DataTable dt = fs
                .InnerJoin<cmsLanguage>(cmsLanguage._.Id == cmsCompany._.LangId)
                .Select(cmsCompany._.All, cmsLanguage._.Name.As("LangName"))
                .ToDataTable();

            return dt;
        }
    }
}
