using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class RoleService : BaseService<cmsRole>
    {
        #region 实现单例模式
        private RoleService()
        {
        }
        static RoleService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new RoleService();
                }
            }
        }

        public static RoleService GetInstance()
        {
            return (RoleService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsRole> GetList()
        {
            return GetList(null, cmsRole._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsRole> GetRoles()
        {
            return GetList(cmsRole._.IsEnabled == 1, cmsRole._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsRole> GetList(int pageIndex, int pageSize, ref int recordCount)
        {
            return GetList(null, cmsRole._.OrderNo.Asc, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string id, int order)
        {
            cmsRole m = GetModel(id);
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
            cmsRole m = GetModel(id);
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
        public int DeleteRoleAndPurviews(string id)
        {
            try
            {
                BaseService<cmsRolePurview> rps = new BaseService<cmsRolePurview>();
                DbTrans trans = BeginTransaction();
                
                DeleteModel(id);
                
                rps.SetTransaction(trans);
                rps.DeleteModels(cmsRolePurview._.RoleId == id);

                Commit();
                CloseTransaction();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Save(cmsRole m)
        {
            return SaveModel(m);
        }
    }
}
