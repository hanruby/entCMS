using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using Hxj.Data;
using entCMS.Services;
using entCMS.Common;

namespace entCMS
{
    public class Global : System.Web.HttpApplication
    {
        private string counterFile = "~/App_Data/counter.txt";

        /// <summary>
        /// 系统初始化
        /// </summary>
        private void Initialize()
        {
            DbTrans trans = DBSession.CurrentSession.BeginTransaction();
            try
            {
                UserService.GetInstance().SetTransaction(trans);
                UserService.GetInstance().Initialize();

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                if (ConfigHelper.GetVal<int>("IsErrorLog") == 1)
                {
                    Logger.Error("Global.Initialize()执行错误！", ex);
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                UserService.GetInstance().CloseTransaction();

                trans.Close();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            Logger.SetConfigAndWatch(new System.IO.FileInfo(Server.MapPath(@"~\log4net.config")));
            // 初始用户信息
            Initialize();


            int count = 0;

            StreamReader srd;

            //取得文件的实际路径
            string file_path = Server.MapPath(counterFile);

            if (!File.Exists(file_path))
            {
                StreamWriter sw = File.CreateText(file_path);
                sw.Write("0");
                sw.Close();
            }

            //打开文件进行读取
            srd = File.OpenText(file_path);

            while (srd.Peek() != -1)
            {
                string str = srd.ReadLine();

                count = int.Parse(str);
            }

            srd.Close();

            object obj = count;
            //将从文件中读取的网站访问量存放在Application对象中
            Application["counter"] = obj;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //在新会话启动时运行的代码
            Application.Lock();

            //数据累加

            int Stat = 0;

            //获取Application对象中保存的网站总访问量

            Stat = (int)Application["counter"];

            Stat += 1;

            object obj = Stat;

            Application["counter"] = obj;

            //将数据记录写入文件

            string file_path = Server.MapPath(counterFile);

            StreamWriter srw = new StreamWriter(file_path, false);

            srw.WriteLine(Stat);

            srw.Close();

            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            /* Fix for the Flash Player Cookie bug in Non-IE browsers.
             * Since Flash Player always sends the IE cookies even in FireFox
             * we have to bypass the cookies by sending the values as part of the POST or GET
             * and overwrite the cookies with the passed in values.
             * 
             * The theory is that at this point (BeginRequest) the cookies have not been read by
             * the Session and Authentication logic and if we update the cookies here we'll get our
             * Session and Authentication restored correctly
             */

            try
            {
                string session_param_name = "ASPSESSID";
                string session_cookie_name = "ASP.NET_SESSIONID";

                if (HttpContext.Current.Request.Form[session_param_name] != null)
                {
                    UpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
                }
                else if (HttpContext.Current.Request.QueryString[session_param_name] != null)
                {
                    UpdateCookie(session_cookie_name, HttpContext.Current.Request.QueryString[session_param_name]);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                Response.Write("Error Initializing Session");
            }

            try
            {
                string auth_param_name = "AUTHID";
                string auth_cookie_name = FormsAuthentication.FormsCookieName;

                if (HttpContext.Current.Request.Form[auth_param_name] != null)
                {
                    UpdateCookie(auth_cookie_name, HttpContext.Current.Request.Form[auth_param_name]);
                }
                else if (HttpContext.Current.Request.QueryString[auth_param_name] != null)
                {
                    UpdateCookie(auth_cookie_name, HttpContext.Current.Request.QueryString[auth_param_name]);
                }

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                Response.Write("Error Initializing Forms Authentication");
            }
        }
        void UpdateCookie(string cookie_name, string cookie_value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
            if (cookie == null)
            {
                cookie = new HttpCookie(cookie_name);
                HttpContext.Current.Request.Cookies.Add(cookie);
            }
            cookie.Value = cookie_value;
            HttpContext.Current.Request.Cookies.Set(cookie);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //在出现未处理的错误时运行的代码
            Exception error = Server.GetLastError();
            Application["error"] = error;
            //清除前一个异常
            Server.ClearError();

            /*
            string err = "出错页面是：" + Request.Url.ToString() + "</br>";
            err += "异常信息：" + erroy.Message + "</br>";
            err += "Source:" + erroy.Source + "</br>";
            err += "StackTrace:" + erroy.StackTrace + "</br>";

            //清除前一个异常
            Server.ClearError();

            //此处理用Session["ProError"]出错。所以用 Application["ProError"]
            Application["erroy"] = err;

            //此处不是page中，不能用Response.Redirect("../frmSysError.aspx");
            System.Web.HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ApplicationPath + "/ApplicationErroy.aspx");
            */

            HttpContext.Current.Response.Redirect("~/Error.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式 
            //设置为 StateServer 或 SQLServer，则不会引发该事件。
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}