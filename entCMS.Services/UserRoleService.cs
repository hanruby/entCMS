using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class UserRoleService : BaseService<cmsUserRole>
    {
        #region 实现单例模式
        private UserRoleService()
        {
        }
        static UserRoleService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new UserRoleService();
                }
            }
        }

        public static UserRoleService GetInstance()
        {
            return (UserRoleService)instance;
        }
        #endregion

        public List<cmsUserRole> GetRolesByUserId(long userId)
        {
            return GetList(cmsUserRole._.UserId == userId, cmsUserRole._.Id.Asc);
        }

        public int Add(long userId, List<cmsUserRole> list)
        {
            try
            {
                BeginTransaction();

                Del(userId); // 先清除

                foreach (cmsUserRole item in list)
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
            finally
            {
                CloseTransaction();
            }
        }

        public int Del(long userId)
        {
            return DeleteModels(cmsUserRole._.UserId == userId);
        }
    }
}
