using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

/*
 * 使用时在引用的项目Web.config中增加以下配置内容
<configuration>
    <!--log4net配置 BEGIN-->
    <configSections>
        <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
    </configSections>
    <!--log4net配置 BEGIN-->
    <log4net debug="true">
        <!--定义输出到文件中-->
        <appender name="LogFileAppender" type="log4net.Appender.FileAppender">
            <!--定义文件存放位置-->
            <param name="File" value="SysLog/ErrorLog.txt"/>
            <!--输出格式-->
            <layout type="log4net.Layout.PatternLayout">
                <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n"/>
            </layout>
        </appender>

        <logger name="File">
            <level value="All" />
            <appender-ref ref="LogFileAppender" />
        </logger>
    </log4net>
    <!--log4net配置 END-->
    <!-- 其他配置 -->
 </configuration> 
*/
namespace entCMS.Common
{
    /// <summary>
    /// 类，事件日志类。
    /// 单态封装log4net
    /// </summary>
    public class Logger
    {
        private static log4net.ILog _log = null;
        private static object _lockHelper = new object();

        public static log4net.ILog Log
        {
            get
            {
                if (_log == null)
                    lock (_lockHelper)
                        if (_log == null)
                        {
                            _log = log4net.LogManager.GetLogger("File");
                        }
                return _log;
            }
        }

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public static void SetConfigAndWatch(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
        }

        public static void Debug(string message)
        {
            if (Logger.Log.IsDebugEnabled)
            {
                Logger.Log.Debug(message);
            }
        }

        public static void Error(string message)
        {
            if (Logger.Log.IsErrorEnabled)
            {
                Logger.Log.Error(message);
            }
        }

        public static void Error(string message, Exception ex)
        {
            if (Logger.Log.IsErrorEnabled)
            {
                Logger.Log.Error(message, ex);
            }
        }

        public static void Fatal(string message)
        {
            if (Logger.Log.IsFatalEnabled)
            {
                Logger.Log.Fatal(message);
            }
        }

        public static void Info(string message)
        {
            if (Logger.Log.IsInfoEnabled)
            {
                Logger.Log.Info(message);
            }
        }

        public static void Warn(string message)
        {
            if (Logger.Log.IsWarnEnabled)
            {
                Logger.Log.Warn(message);
            }
        }
    }
}