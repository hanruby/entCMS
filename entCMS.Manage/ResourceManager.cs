using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using entCMS.Common;

namespace entCMS
{
    public class ResourceManager
    {
        private string _configFile = string.Empty;
        private string _sectionName = string.Empty;

        public ResourceManager(string configFile, string sectionName)
        {
            this._configFile = configFile;
            this._sectionName = sectionName;
        }

        /// <summary>
        /// 通过key获取value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                KeyValueConfigurationElement ele = Settings[key];

                if (ele != null)
                {
                    return Settings[key].Value;
                }
                else
                {
                    key = "_" + key;
                    ele = Settings[key];
                    if (ele != null) return Settings[key].Value;
                    else return string.Empty;
                }
            }
        }

        /// <summary>
        /// 资源集合，可以直接用Resources[key]调用
        /// </summary>
        private KeyValueConfigurationCollection Settings
        {
            get
            {
                AppSettingsSection appSec = (AppSettingsSection)ConfigHelper.GetSection(_configFile, _sectionName);
                if (appSec == null)
                {
                    appSec = new AppSettingsSection();
                }
                return appSec.Settings;
            }
        }
    }
}