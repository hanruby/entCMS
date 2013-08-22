using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using entCMS.Common;
using System.Data;
using Hxj.Data;

namespace entCMS.Services
{
    public enum LoginState
    {
        LOGIN_UNKNOWN = 0,
        LOGIN_SUCCESS,
        LOGIN_FAIL_USER_ERROR,
        LOGIN_FAIL_USER_FORBIDDED,
        LOGIN_FAIL_PASSWORD_ERROR,
        LOGIN_UNKNOWN_ERROR
    }

    public class UserService : BaseService<cmsUser>
    {
        #region 私有构造函数，防止实例化
        private UserService()
        {
        }
        static UserService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new UserService();
                }
            }
        }

        public static UserService GetInstance()
        {
            return (UserService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            cmsUser user = GetModel(1);
            string userName = "admin";
            if (user == null)
            {
                user = new cmsUser()
                {
                    UName = userName,
                    UPwd = Md5.Get32Md5(userName + ConfigHelper.GetVal("DefaultPassword"), true),
                    UserType = 1,
                    IsEnabled = 1,
                    LoginCount = 0,
                    LastIp = "",
                    LastTime = DateTime.Now,
                    Name = "管理员",
                    DeptId = 0,
                    DeptName = "",
                    CreateTime = DateTime.Now,
                };

                SaveModel(user);
            }
        }
        /// <summary>
        /// 根据用户名获取用户对象
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <returns>用户对象</returns>
        public cmsUser GetByUid(string uid)
        {
            return GetModelWithWhere(cmsUser._.UName == uid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        protected override void GetRelations(ref cmsUser u)
        {
            if (u != null)
            {
                
            }
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="old">原始密码</param>
        /// <param name="password">新密码</param>
        public void ModifyPassword(string uid, string old, string password)
        {
            cmsUser user = GetModelWithWhere(cmsUser._.UName == uid);
            if (user == null) throw new Exception("用户信息不正确");
            else if (user.UPwd != Md5.Get32Md5(uid + old)) throw new Exception("原始密码不正确");
            else
            {
                user.Attach();
                user.UPwd = Md5.Get32Md5(uid + password);
                UpdateModel(user);
            }
        }
        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public LoginState CheckLogin(string uid, string pwd, string ip, out cmsUser user)
        {
            user = null;
            try
            {
                user = GetModelWithWhere(cmsUser._.UName == uid);
                if (user == null)
                {
                    return LoginState.LOGIN_FAIL_USER_ERROR;
                }
                else
                {
                    if (user.IsEnabled != 1)
                    {
                        return LoginState.LOGIN_FAIL_USER_FORBIDDED;
                    }
                    else if (user.UPwd == Md5.Get32Md5(uid+pwd))
                    {
                        user.Attach();
                        user.LoginCount += 1;
                        user.LastIp = ip;
                        user.LastTime = DateTime.Now;
                        UpdateModel(user);

                        LogService.GetInstance().Add(user, "", "登录系统", LogType.登录, ip);

                        return LoginState.LOGIN_SUCCESS;
                    }
                    else
                    {
                        return LoginState.LOGIN_FAIL_PASSWORD_ERROR;
                    }
                }
            }
            catch(Exception)
            {
                return LoginState.LOGIN_UNKNOWN_ERROR;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="trueName"></param>
        /// <param name="deptName"></param>
        /// <param name="roleId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<cmsUser> GetUsersByFilter(string loginName, string trueName, string deptName, int roleId, int pageIndex, int pageSize, ref int recordCount)
        {
            UserRoleService urs = UserRoleService.GetInstance();

            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(loginName))
            {
                wcb.And(cmsUser._.UName.Contain(loginName.Trim()));
            }
            if (!string.IsNullOrEmpty(trueName))
            {
                wcb.And(cmsUser._.Name.Contain(trueName.Trim()));
            }
            if (!string.IsNullOrEmpty(deptName.Trim()))
            {
                wcb.And(cmsUser._.DeptName.Contain(deptName.Trim()));
            }
            if (roleId > 0)
            {
                FromSection fs = DBSession.CurrentSession.From<cmsUserRole>()
                    .Select(cmsUserRole._.UserId)
                    .Where(cmsUserRole._.RoleId == roleId);

                wcb.And(cmsUser._.Id.SubQueryIn(fs));
            }
            return GetList(wcb.ToWhereClip(), cmsUser._.UName.Asc, pageIndex, pageSize, ref recordCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUser(string user)
        {
            return Exists(cmsUser._.UName == user);
        }
    }
}
