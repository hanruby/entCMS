using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;

namespace entCMS.Common
{
    public class ScriptUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="addScriptTags"></param>
        public static void RegisterClientScriptBlock(string script, bool addScriptTags)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), Guid.NewGuid().ToString(), script, addScriptTags);
            }
            else
            {
                HttpContext.Current.Response.Write(script);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="addScriptTags"></param>
        public static void RegisterStartupScript(string script, bool addScriptTags)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                page.ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), script, addScriptTags);
            }
            else
            {
                HttpContext.Current.Response.Write(script);
            }
        }
        // Methods
        public static void Alert(string message)
        {
            message = StringUtil.DeleteUnVisibleChar(message);
            message = StringUtil.GetSafeString(message);
            string js = "<Script type='text/javascript'>alert('" + message + "');</Script>";
            RegisterStartupScript(js, false);
        }

        public static void AlertAndExecute(string message, string jsStr)
        {
            message = StringUtil.DeleteUnVisibleChar(message);
            message = StringUtil.GetSafeString(message);

            string js = "<Script type='text/javascript'>alert('" + message + "'); " + jsStr + "</Script>";

            RegisterStartupScript(js, false);
        }


        public static void AlertAndCloseDialog(string message, bool refreshMainFrame)
        {
            if (!refreshMainFrame)
            {
                AlertAndExecute(message, "top.Dialog.close();");
            }
            else
            {
                AlertAndExecute(message, "top.MainFrameReload();top.Dialog.close();");
            }
        }

        public static void AlertAndCloseDialog(string message)
        {
            AlertAndExecute(message, "top.Dialog.close();");
        }

        public static void AlertAndCloseWindow(string message)
        {
            AlertAndExecute(message, "window.close();");
        }

        public static void AlertAndRedirect(string message, string toURL)
        {
            message = StringUtil.DeleteUnVisibleChar(message);
            message = StringUtil.GetSafeString(message);
            string js = "<script type='text/javascript'>alert('{0}');window.location.href='{1}';</script>";
            js = string.Format(js, message, toURL);
            
            RegisterClientScriptBlock(js, false);
        }

        public static void ConfirmAndRedirect(string message, string yesURL, string noURL)
        {
            message = StringUtil.DeleteUnVisibleChar(message);
            message = StringUtil.GetSafeString(message);

            string js = "<script type='text/javascript'>if(confirm('{0}')){{window.location.href='{1}';}}else{{window.location.replace('{2}');}}</script>";
            js = string.Format(js, message, yesURL, noURL);

            RegisterClientScriptBlock(js, false);
        }

        public static void CloseWindow()
        {
            string js = "<script type='text/javascript'> window.close(); </Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void GoHistory(int value)
        {
            string js = "<script type='text/javascript'>history.go({0});</Script>";
            js = string.Format(js, value);

            RegisterClientScriptBlock(js, false);
        }

        public static void GoHistory(string msg, int value)
        {
            string js = "<script type='text/javascript'>alert('{0}');history.go({1});</Script>";
            js = string.Format(js, msg, value);

            RegisterClientScriptBlock(js, false);
        }

        public static void GotoParentWindow(string parentWindowUrl)
        {
            string js = "<script type='text/javascript'>this.parent.location.replace('" + parentWindowUrl + "');</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void JavaScriptFrameHref(string FrameName, string url)
        {
            string js = "<script type='text/javascript'>@obj.location.replace(\"{0}\");</Script>";
            js = string.Format(js.Replace("@obj", FrameName), url);

            RegisterClientScriptBlock(js, false);
        }

        public static void JavaScriptSetCookie(string strName, string strValue)
        {
            string js = "<script language=Javascript>var the_cookie = '" + strName + "=" + strValue + "';var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';document.cookie = the_cookie + '; expires='+dateexpire;</script>";

            RegisterClientScriptBlock(js, false);
        }

        public static string JSStringFormat(string s)
        {
            return s.Replace("\r", @"\r").Replace("\n", @"\n").Replace("'", @"\'").Replace("\"", "\\\"");
        }

        public static void OpenWebForm(string url)
        {
            string js = "<script type='text/javascript'>window.open('" + url + "','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string js = "<script type='text/javascript'>";
            if (isFullScreen)
            {
                js = (((js + "var iWidth = 0;") + "var iHeight = 0;" + "iWidth=window.screen.availWidth-10;") + "iHeight=window.screen.availHeight-50;" + "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=yes,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';") + "window.open('" + url + "','',szFeatures);";
            }
            else
            {
                js = js + "window.open('" + url + "','','height=0,width=0,top=0,left=0,location=no,menubar=yes,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            js = js + "</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void OpenWebForm(string url, string formName)
        {
            string js = "<script type='text/javascript'>window.open('" + url + "','" + formName + "','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void OpenWebForm(string url, int height, int width)
        {
            string str = (("<script type='text/javascript'>" + "var iTop = 0;" + "var iLeft = 0;") + "iLeft=(window.screen.availWidth-" + width.ToString() + ")/2;") + "iTop=(window.screen.availHeight-" + height.ToString() + ")/2;";
            string js = (string.Concat(new object[] { str, "var szFeatures ='width=", width, ",height=", height, ",top='+ iTop+ ',left='+ iLeft +',location=no,menubar=yes,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';" }) + "window.open('" + url + "','',szFeatures);") + "</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void OpenWebForm(string url, string name, string future)
        {
            string js = "<script type='text/javascript'>window.open('" + url + "','" + name + "','" + future + "')</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void Redirect(string url)
        {
            string js = "<script type='text/javascript'>window.location.href = '{0}';</Script>";
            js = string.Format(js, url);

            RegisterClientScriptBlock(js, false);
        }

        public static void RefreshOpener()
        {
            string js = "<script type='text/javascript'>opener.location.reload();</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void RefreshParent()
        {
            string js = "<script type='text/javascript'>parent.location.reload();</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void RefreshFrame(string frameName)
        {
            string js = "<script type='text/javascript'>top." + frameName + ".location.href=top." + frameName + ".location.href;</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void ReplaceOpenerParentFrame(string frameName, string frameWindowUrl)
        {
            string js = "<script type='text/javascript'>window.opener.parent." + frameName + ".location.replace('" + frameWindowUrl + "');</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
        {
            string js = "<script type='text/javascript'>window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void ReplaceOpenerWindow(string openerWindowUrl)
        {
            string js = "<script type='text/javascript'>window.opener.location.replace('" + openerWindowUrl + "');</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static void ReplaceParentWindow(string parentWindowUrl, string caption, string future)
        {
            string js = "";
            if ((future != null) && (future.Trim() != ""))
            {
                js = "<script language=javascript>this.parent.location.replace('" + parentWindowUrl + "','" + caption + "','" + future + "');</script>";
            }
            else
            {
                js = "<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('" + parentWindowUrl + "','" + caption + "',szFeatures);</script>";
            }

            RegisterClientScriptBlock(js, false);
        }

        public static void SetHtmlElementValue(string formName, string elementName, string elementValue)
        {
            string js = "<script type='text/javascript'>if(document." + formName + "." + elementName + "!=null){document." + formName + "." + elementName + ".value =" + elementValue + ";}</Script>";

            RegisterClientScriptBlock(js, false);
        }

        public static string GetShowModalDialogJavascript(string webFormUrl)
        {
            return ("<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';showModalDialog('" + webFormUrl + "','',szFeatures);</script>");
        }

        public static string GetShowModalDialogJavascript(string webFormUrl, string features)
        {
            return ("<script language=javascript>showModalDialog('" + webFormUrl + "','','" + features + "');</script>");
        }

        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string js = GetShowModalDialogJavascript(webFormUrl);

            RegisterClientScriptBlock(js, false);
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = GetShowModalDialogJavascript(webFormUrl, features);

            RegisterClientScriptBlock(js, false);
        }
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = string.Concat(new object[] { "dialogWidth:", width, "px;dialogHeight:", height, "px;dialogLeft:", left, "px;dialogTop:", top, "px;center:yes;help=no;resizable:no;status:no;scroll=no" });
            ShowModalDialogWindow(webFormUrl, features);
        }
    }
}
