using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace entCMS.Common
{
    public class CookieHelper
    {
        private const string defaultCookieName = "jtSoft";

        public static void ClearCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        public static void ClearDefaultCookie()
        {
            ClearCookie("jtSoft");
        }

        public static string GetCookieValue(string cookieName)
        {
            return GetCookieValue(null, cookieName);
        }

        public static string GetCookieValue(string fatherCookieName, string cookieName)
        {
            HttpCookie cookie;
            string str = string.Empty;
            if (string.IsNullOrEmpty(fatherCookieName))
            {
                cookie = HttpContext.Current.Request.Cookies[cookieName];
                if (cookie != null)
                {
                    str = HttpUtility.UrlDecode(cookie.Value);
                }
                return str;
            }
            cookie = HttpContext.Current.Request.Cookies[fatherCookieName];
            if (cookie != null)
            {
                str = HttpUtility.UrlDecode(cookie.Values[cookieName]);
            }
            return str;
        }

        public static string GetDefaultCookieValue(string cookieName)
        {
            return GetCookieValue("jtSoft", cookieName);
        }

        public static void SetCookie(string cookieName, string cookieValue)
        {
            SetCookie(cookieName, cookieValue, (int?)null);
        }

        public static void SetCookie(string cookieName, string cookieValue, int? expires)
        {
            SetCookie(cookieName, cookieValue, expires, null, null, null, null);
        }

        public static void SetCookie(string fatherCookieName, string cookieName, string cookieValue)
        {
            SetCookie(fatherCookieName, cookieName, cookieValue, null);
        }

        public static void SetCookie(string fatherCookieName, string cookieName, string cookieValue, int? expires)
        {
            SetCookie(fatherCookieName, cookieName, cookieValue, expires, null, null, null, null);
        }

        public static void SetCookie(string cookieName, string cookieValue, int? expires, string domain, bool? httpOnly, string path, bool? secure)
        {
            SetCookie(null, cookieName, cookieValue, expires, domain, httpOnly, path, secure);
        }

        public static void SetCookie(string fatherCookieName, string cookieName, string cookieValue, int? expires, string domain, bool? httpOnly, string path, bool? secure)
        {
            HttpCookie cookie;
            if (string.IsNullOrEmpty(fatherCookieName))
            {
                cookie = HttpContext.Current.Request.Cookies[cookieName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(cookieName);
                }
                cookie.Value = HttpUtility.UrlEncode(cookieValue);
            }
            else
            {
                cookie = HttpContext.Current.Request.Cookies[fatherCookieName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(fatherCookieName);
                }
                cookie.Values[cookieName] = HttpUtility.UrlEncode(cookieValue);
            }
            if (expires.HasValue)
            {
                cookie.Expires = DateTime.Now.AddSeconds((double)expires.Value);
            }
            if (!string.IsNullOrEmpty(domain))
            {
                cookie.Domain = domain;
            }
            if (httpOnly.HasValue)
            {
                cookie.HttpOnly = httpOnly.Value;
            }
            if (!string.IsNullOrEmpty(path))
            {
                cookie.Path = path;
            }
            if (secure.HasValue)
            {
                cookie.Secure = secure.Value;
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void SetDefaultCookie(string cookieName, string cookieValue)
        {
            SetDefaultCookie(cookieName, cookieValue, null);
        }

        public static void SetDefaultCookie(string cookieName, string cookieValue, int? expires)
        {
            SetDefaultCookie(cookieName, cookieValue, expires, null, null, null, null);
        }

        public static void SetDefaultCookie(string cookieName, string cookieValue, int? expires, string domain, bool? httpOnly, string path, bool? secure)
        {
            SetCookie("jtSoft", cookieName, cookieValue, expires, domain, httpOnly, path, secure);
        }
    }
}
