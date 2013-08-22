using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;

namespace entCMS.Services
{
    public class MessageService : BaseService<cmsMessage>
    {
        #region 私有构造函数，防止实例化
        private MessageService()
        {
        }
        #endregion

        #region 实现单例模式
        static MessageService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new MessageService();
                }
            }
        }

        public static MessageService GetInstance()
        {
            return (MessageService)instance;
        }
        #endregion
    }
}
