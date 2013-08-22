using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web;

namespace entCMS.Manage
{
    /// <summary>
    /// http://tech.sina.com.cn/s/s/2008-06-15/0904693512.shtml
    /// </summary>
    public static class FormsAuthenticationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="createPersistentCookie"></param>
        public static void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("值不能为 null 或为空。", "userName");

            //设置用户的 cookie 的值
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);

            ////获取用户的 cookie 
            //HttpCookie cookie = FormsAuthentication.GetAuthCookie(userName, false);
            ////给用户的 cookie 的值加上 cookie 的域 和 过期日期
            ////向客户端重写同名的 用户 cookie
            //FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(cookie.Value);
            //FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(1,
            //oldTicket.Name,
            //oldTicket.IssueDate,
            //DateTime.Now.AddMinutes(30),
            //oldTicket.IsPersistent,
            //oldTicket.UserData,
            //FormsAuthentication.FormsCookiePath);
            //cookie.Domain = "";
            //cookie.Value = FormsAuthentication.Encrypt(newTicket);
            //HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        public static void SignOut()
        {
            //HttpCookie cookie = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];
            //cookie.Domain = "";
            //cookie.Value = null;
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //HttpContext.Current.Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
        }
    }
}
