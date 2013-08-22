using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class RolePurviewService : BaseService<cmsRolePurview>
    {
        #region 实现单例模式
        private RolePurviewService()
        {
        }
        static RolePurviewService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new RolePurviewService();
                }
            }
        }

        public static RolePurviewService GetInstance()
        {
            return (RolePurviewService)instance;
        }
        #endregion

        public List<cmsRolePurview> GetList(long roleId)
        {
            return GetList(cmsRolePurview._.RoleId == roleId, cmsRolePurview._.Type.Asc);
        }

        public List<cmsRolePurview> GetList(long roleId, int type)
        {
            return GetList(cmsRolePurview._.RoleId == roleId && cmsRolePurview._.Type == type, cmsRolePurview._.NodeCode.Asc);
        }

        public int Add(cmsRolePurview rp)
        {
            return AddModel(rp);
        }

        public int Add(long roleId, List<cmsRolePurview> list)
        {
            try
            {
                BeginTransaction();
                
                Del(roleId); // 先清除

                foreach (cmsRolePurview item in list)
                {
                    AddModel(item);
                }
                Commit();

                return 1;
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally{
                CloseTransaction();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int Del(long roleId)
        {
            return DeleteModels(cmsRolePurview._.RoleId == roleId);
        }
    }
}
