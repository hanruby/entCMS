using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public enum LogType
    {
        登录 = 1,
        退出 = 2,
        增加 = 3,
        修改 = 4,
        删除 = 5,
        申请 = 6,
        审核 = 7,
        归档 = 8,
    }

    public class LogService : BaseService<cmsLog>
    {
        #region 私有构造函数，防止实例化
        private LogService()
        {
        }
        #endregion

        #region 实现单例模式
        static LogService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new LogService();
                }
            }
        }

        public static LogService GetInstance()
        {
            return (LogService)instance;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="resid"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="ip"></param>
        public void Add(cmsUser user, string resid, string message, LogType type, string ip)
        {
            if (user == null) return;

            long uid = user.Id;

            cmsLog log = new cmsLog()
            {
                UserId = uid,
                ResId = resid,
                Message = message,
                LogType = type.GetHashCode(),
                LogIp = ip,
                AddTime = DateTime.Now,
            };

            AddModel(log);
        }
    }
}
