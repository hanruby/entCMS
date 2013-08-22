using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class UserPurviewService : BaseService<cmsUserPurview>
    {
        #region 私有构造函数，防止实例化
        private UserPurviewService()
        {
        }
        static UserPurviewService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new UserPurviewService();
                }
            }
        }

        public static UserPurviewService GetInstance()
        {
            return (UserPurviewService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<cmsUserPurview> GetList(long userId)
        {
            return GetList(cmsUserPurview._.UserId == userId, cmsUserPurview._.NodeCode.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public int Add(long userId, List<cmsUserPurview> list)
        {
            try
            {
                BeginTransaction();

                Del(userId); // 先清除

                foreach (cmsUserPurview item in list)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int Del(long userId)
        {
            return DeleteModels(cmsUserPurview._.UserId == userId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<cmsUserPurview> GetUserAllPurview(long userId)
        {
            List<cmsUserPurview> all = new List<cmsUserPurview>();

            var ups = GetList(cmsUserPurview._.UserId == userId, null);
            all.AddRange(ups);

            // 获取用户所属的全部角色
            List<cmsUserRole> userroles = UserRoleService.GetInstance().GetList(cmsUserRole._.UserId == userId, null);
            if (userroles.Count > 0)
            {
                long[] roles = new long[userroles.Count];
                for (int i = 0; i < userroles.Count; i++)
                {
                    roles[i] = userroles[i].RoleId.Value;
                }
                // 获取全部角色所拥有的权限
                List<cmsRolePurview> rps = RolePurviewService.GetInstance().GetList(cmsRolePurview._.RoleId.SelectIn(roles), null);
                foreach (var p in rps)
                {
                    // 去重
                    if (all.Exists(x => x.Type == p.Type && x.NodeCode == p.NodeCode)) continue;

                    all.Add(new cmsUserPurview()
                    {
                        Id = 0,
                        UserId = userId,
                        NodeCode = p.NodeCode,
                        Type = p.Type
                    });
                }
            }
            return all;
        }
    }
}
