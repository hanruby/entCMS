using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace entCMS.Common
{
    public static class ConfigHelper
    {
        #region 读取默认配置文件的数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetVal(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        /// <summary>
        /// 通过key获取value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetVal<T>(string key)
        {
            string val = GetVal(key);
            return ConverterHelper.ConverterValue<T>(val);
        }
        #endregion

        #region 读取或保存指定配置文件的数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetVal(string configFile, string key)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            // 读取指定key的值value必须使用appConfig.AppSettings.Settings["APPLICATION_NAME"].Value方式;
            // 不能使用appConfig.AppSettings["APPLICATION_NAME"]方式, 否则编译器会提示
            // "错误“System.Configuration.ConfigurationElement.this[System.Configuration.ConfigurationProperty]”不可访问，因为它受保护级别限制"
            if (config.AppSettings.Settings[key] == null) return null;
            else return config.AppSettings.Settings[key].Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetVal(string configFile, string key, string defaultVal)
        {
            string val = GetVal(configFile, key);
            if (string.IsNullOrEmpty(val)) val = defaultVal;
            return val;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configFile"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetVal<T>(string configFile, string key)
        {
            string val = GetVal(configFile, key);
            return ConverterHelper.ConverterValue<T>(val);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public static void SetVal(string configFile, string key, string val)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, val);
            }
            else
            {
                config.AppSettings.Settings[key].Value = val;
            }
            config.Save(ConfigurationSaveMode.Modified);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="list"></param>
        public static void SetVal(string configFile, Dictionary<string, string> dic)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            foreach (var item in dic)
            {
                if (config.AppSettings.Settings[item.Key] == null)
                {
                    config.AppSettings.Settings.Add(item.Key, item.Value);
                }
                else
                {
                    config.AppSettings.Settings[item.Key].Value = item.Value;
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
        }
        #endregion

        #region 读取或保存指定配置文件的自定义Section中数据
        /// <summary>
        /// 获取键值集合
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public static KeyValueConfigurationCollection GetSettingsInSection(string configFile, string section)
        {
            AppSettingsSection appSec = (AppSettingsSection)GetSection(configFile, section);
            if (appSec == null) return null;
            else return appSec.Settings;
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValInSection(string configFile, string section, string key)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            // 读取指定key的值value必须使用appConfig.AppSettings.Settings["APPLICATION_NAME"].Value方式;
            // 不能使用appConfig.AppSettings["APPLICATION_NAME"]方式, 否则编译器会提示
            // "错误“System.Configuration.ConfigurationElement.this[System.Configuration.ConfigurationProperty]”不可访问，因为它受保护级别限制"
            AppSettingsSection appSec = (AppSettingsSection)config.GetSection(section);
            if (appSec != null)
            {
                if (appSec.Settings[key] == null) return null;
                else return appSec.Settings[key].Value;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string GetValInSection(string configFile, string section, string key, string defaultVal)
        {
            string val = GetValInSection(configFile, section, key);
            if (string.IsNullOrEmpty(val)) val = defaultVal;
            return val;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configFile"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValInSection<T>(string configFile, string section, string key)
        {
            string val = GetValInSection(configFile, section, key);
            return ConverterHelper.ConverterValue<T>(val);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public static void SetValInSection(string configFile, string section, string key, string val)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            AppSettingsSection appSec = (AppSettingsSection)config.GetSection(section);
            if (appSec == null)
            {
                appSec = new AppSettingsSection();
                config.Sections.Add("Resource", appSec);
            }
            if (appSec.Settings[key] == null)
            {
                appSec.Settings.Add(key, val);
            }
            else
            {
                appSec.Settings[key].Value = val;
            }
            config.Save(ConfigurationSaveMode.Modified);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="list"></param>
        public static void SetValInSection(string configFile, string section,Dictionary<string, string> dic)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            AppSettingsSection appSec = (AppSettingsSection)config.GetSection(section);
            if (appSec == null)
            {
                appSec = new AppSettingsSection();
                config.Sections.Add("Resource", appSec);
            }
            foreach (var item in dic)
            {
                if (appSec.Settings[item.Key] == null)
                {
                    appSec.Settings.Add(item.Key, item.Value);
                }
                else
                {
                    appSec.Settings[item.Key].Value = item.Value;
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
        }
        #endregion

        #region 从配置文件中获取配置组
        /// <summary>
        /// 从配置文件中获取配置组
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="section"></param>
        public static ConfigurationSection GetSection(string configFile, string section)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            AppSettingsSection appSec = (AppSettingsSection)config.GetSection(section);            
            return appSec;
        } 
        #endregion
    }
}
