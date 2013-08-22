using System;
using System.Collections.Generic;
using System.Text;
using Hxj.Data;
using entCMS.Common;

namespace entCMS.Services
{
    public class DBSession
    {
        public static readonly DbSession CurrentSession = new DbSession("conn");
        static DBSession()
        {
            if (ConfigHelper.GetVal<int>("IsSqlLog") == 1)
            {
                CurrentSession.RegisterSqlLogger(delegate(string sql) { Logger.Info(sql); });
            }
        }
    }
}
