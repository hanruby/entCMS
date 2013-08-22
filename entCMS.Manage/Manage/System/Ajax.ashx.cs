using System;
using System.Collections.Generic;
using System.Web;
using entCMS.Services;
using entCMS.Models;
using System.Data;
using System.Collections;
using entCMS.Common;
using System.Text;

namespace entCMS.Manage
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
    {
        HttpContext Context = null;
        HttpRequest Request = null;
        HttpResponse Response = null;

        string json = "";

        //MessageService mss = new MessageService();
        public void ProcessRequest(HttpContext context)
        {
            Context = context;
            Request = context.Request;
            Response = context.Response;

            Response.ContentType = "Application/json";

            string method = Request.HttpMethod.ToLower();
            string action = Request["Action"];
            if (method.Equals("post"))
            {
                /* 系统栏目操作 */ 
                if (action.StartsWith("Menu"))
                {
                    DoMenuActions(action);
                }
                /* 内容栏目操作 */ 
                else if (action.StartsWith("Catalog"))
                {
                    DoCatalogActions(action);
                }
                /* 语言操作 */
                else if (action.StartsWith("Lang"))
                {
                    DoLanguageActions(action);
                }
                /* 角色操作 */
                else if (action.StartsWith("Role"))
                {
                    DoRoleActions(action);
                }
                /* 文章操作 */
                else if (action.StartsWith("News"))
                {
                    DoNewsActions(action);
                }
                /* 链接类别操作 */
                else if (action.StartsWith("LinkGroup"))
                {
                    DoLinkTypeActions(action);
                }
                /* 链接操作 */
                else if (action.StartsWith("Link"))
                {
                    DoLinkActions(action);
                }
                /* 广告操作 */
                else if (action.Equals("Ad"))
                {
                    DoAdActions(action);
                }
                /* 用户操作 */
                else if (action.StartsWith("User"))
                {
                    DoUserActions(action);
                }
                /* 公司信息 */
                else if (action.StartsWith("Company"))
                {
                    DoCompanyActions(action);
                }
                /* 发送邮件测试 */
                else if (action.StartsWith("Email"))
                {
                    DoEmailActions(action);
                }
                /* 在线客服操作 */
                else if (action.StartsWith("Servicer"))
                {
                    DoServicerActions(action);
                }
                /* 招聘模块操作 */
                else if (action.StartsWith("Job")) 
                {
                    DoJobActions(action);
                }
            }
            if (string.IsNullOrEmpty(json))
            {
                json = "{\"result\":0, \"msg\":\"未知错误！\"}";
            }
            Response.Write(json);
            Response.End();
        }

        #region 具体操作方法
        private void DoNewsActions(string action)
        {
            NewsService ns = NewsService.GetInstance();
            if (action.Equals("NewsDeleteImage")) //删除缩略图
            {
                string fileName = Request["FileName"];
                string file = Context.Server.MapPath(fileName);
                if (!System.IO.File.Exists(file))
                {
                    json = "{\"result\":0, \"msg\":\"文件不存在！\"}";
                }
                else
                {
                    try
                    {
                        System.IO.File.Delete(file);
                        json = "{\"result\":1}";
                    }
                    catch (Exception ex)
                    {
                        json = "{\"result\":0, \"msg\":\"" + ex.Message + "\"}";
                    }
                }
            }
            else if (action.Equals("NewsDelete")) //删除文章
            {
                string id = Request["Id"];
                string t = Request["Type"];
                try
                {
                    if (t == "0")
                        ns.UpdateModels(cmsNews._.IsAudit, 3, cmsNews._.Id == id);
                    else if (t == "1")
                        ns.DeleteModel(id);

                    json = "{\"result\":1}";
                }
                catch (Exception ex)
                {
                    json = "{\"result\":0, \"msg\":\"" + ex.Message + "\"}";
                }
            }
            else if (action.Equals("NewsEnableIndex")) //推荐到显示
            {
                string id = Request["Id"];
                try
                {
                    ns.EnableIndex(id);

                    json = "{\"result\":1}";
                }
                catch (Exception ex)
                {
                    json = "{\"result\":0, \"msg\":\"" + ex.Message + "\"}";
                }
            }
            else if (action.Equals("NewsEnableTop")) //置顶
            {
                string id = Request["Id"];
                try
                {
                    ns.EnableTop(id);

                    json = "{\"result\":1}";
                }
                catch (Exception ex)
                {
                    json = "{\"result\":0, \"msg\":\"" + ex.Message + "\"}";
                }
            }
        }
        private void DoAdActions(string action)
        {
            AdService ads = AdService.GetInstance();
            if (action.Equals("AdEnable"))
            {
                string id = Request["Id"];
                int r = ads.Enable(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("AdDelete"))
            {
                string id = Request["Id"];
                try
                {
                    ads.DeleteModel(id);

                    json = "{\"result\":1}";
                }
                catch (Exception ex)
                {
                    json = "{\"result\":0, \"msg\":\"" + ex.Message + "\"}";
                }
            }
        }
        private void DoMenuActions(string action)
        {
            MenuService ms = MenuService.GetInstance();
            if (action.Equals("MenuOrder"))
            {
                string code = Request["Code"];
                string order = Request["Order"];

                int r = ms.ChangeOrder(code, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("MenuEnable"))
            {
                string code = Request["Code"];

                int r = ms.Enable(code);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("MenuDelete"))
            {
                string code = Request["Code"];

                List<cmsMenu> ls = ms.GetChildList(code);
                if (ls.Count > 0)
                {
                    json = "{\"result\":0, \"msg\":\"本栏目下有子栏目，不能被删除！\"}";
                }
                else
                {
                    int r = ms.Delete(code);
                    if (r > 0)
                    {
                        json = "{\"result\":1}";
                    }
                    else
                    {
                        json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                    }
                }
            }
        }
        private void DoCatalogActions(string action)
        {
            NewsCatalogService ncs = NewsCatalogService.GetInstance();
            if (action.Equals("CatalogOrder"))
            {
                string code = Request["Code"];
                string order = Request["Order"];

                int r = ncs.ChangeOrder(code, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("CatalogNavigate"))
            {
                string code = Request["Code"];

                int r = ncs.Nav(code);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("CatalogEnable"))
            {
                string code = Request["Code"];

                int r = ncs.Enable(code);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("CatalogDelete"))
            {
                string code = Request["Code"];

                List<cmsNewsCatalog> ls = ncs.GetChildList(code, null);
                if (ls.Count > 0)
                {
                    json = "{\"result\":0, \"msg\":\"本栏目下有子栏目，不能被删除！\"}";
                }
                else
                {
                    int r = ncs.Delete(code);
                    if (r > 0)
                    {
                        json = "{\"result\":1}";
                    }
                    else
                    {
                        json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                    }
                }
            }
        }
        private void DoLanguageActions(string action)
        {
            LanguageService lgs = LanguageService.GetInstance();
            if (action.Equals("LangOrder"))
            {
                string id = Request["Id"];
                string order = Request["Order"];

                int r = lgs.ChangeOrder(id, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("LangSetDefault"))
            {
                string id = Request["Id"];

                int r = lgs.SetDefault(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("LangEnable"))
            {
                string id = Request["Id"];

                int r = lgs.Enable(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("LangDelete"))
            {
                string id = Request["Id"];
                if (id == "1")
                {
                    json = "{\"result\":0, \"msg\":\"不允许删除系统保留的第一种语言！\"}";
                }
                else if (lgs.Count(null) == 1)
                {
                    json = "{\"result\":0, \"msg\":\"不允许删除，系统必须保留一种语言！\"}";
                }
                else
                {
                    int r = lgs.Delete(id);
                    if (r > 0)
                    {
                        json = "{\"result\":1}";
                    }
                    else
                    {
                        json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                    }
                }
            }
        }
        private void DoLinkTypeActions(string action)
        {
            LinkGroupService lts = LinkGroupService.GetInstance();
            if (action.Equals("LinkGroupOrder"))
            {
                string id = Request["Id"];
                string order = Request["Order"];

                int r = lts.ChangeOrder(id, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("LinkGroupEnable"))
            {
                string id = Request["Id"];

                int r = lts.Enable(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("LinkGroupDelete"))
            {
                string id = Request["Id"];
                int r = lts.Delete(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                }
            }
        }
        private void DoLinkActions(string action)
        {
            LinkService ls = LinkService.GetInstance();
            if (action.Equals("LinkOrder"))
            {
                string id = Request["Id"];
                string order = Request["Order"];

                int r = ls.ChangeOrder(id, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("LinkDelete"))
            {
                string id = Request["Id"];
                int r = ls.Delete(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                }
            }
        }
        private void DoRoleActions(string action)
        {
            RoleService rs = RoleService.GetInstance();
            if (action.Equals("RoleOrder"))
            {
                string id = Request["Id"];
                string order = Request["Order"];

                int r = rs.ChangeOrder(id, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("RoleEnable"))
            {
                string id = Request["Id"];

                int r = rs.Enable(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("RoleDelete"))
            {
                string id = Request["Id"];
                if (Convert.ToInt32(id) == 1)
                {
                    json = "{\"result\":0, \"msg\":\"角色（超级管理员）不允许删除！\"}";
                }
                else
                {
                    int r = rs.DeleteRoleAndPurviews(id);
                    if (r > 0)
                    {
                        json = "{\"result\":1}";
                    }
                    else
                    {
                        json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                    }
                }
            }
        }
        private void DoUserActions(string action)
        {
            UserService us = UserService.GetInstance();
            if (action.Equals("UserDelete"))
            {
                string id = Request["Id"];
                if (Convert.ToInt32(id) == 1)
                {
                    json = "{\"result\":0, \"msg\":\"用户（admin）不允许被删除！\"}";
                }
                else
                {
                    int r = us.DeleteModel(id);
                    if (r > 0)
                    {
                        json = "{\"result\":1}";
                    }
                    else
                    {
                        json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                    }
                }
            }
        }
        private void DoCompanyActions(string action)
        {
            if (action.Equals("CompanyDelete"))
            {
                string id = Request["Id"];
                int r = CompanyService.GetInstance().DeleteModel(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                }
            }
        }
        private void DoEmailActions(string action)
        {
            if (action.Equals("EmailTest"))
            {
                string sender = Request["sender"];
                string email = Request["email"];
                string pwd = Request["password"];
                string smtp = Request["smtp"];
                string to = Request["to"];

                try
                {
                    bool succ = entCMS.Common.MailHelper.TestSendMail(smtp, email, pwd, sender, to);
                    if (succ)
                        json = "{\"result\":1}";
                    else
                        json = "{\"result\":0}";
                }
                catch (Exception ex)
                {
                    json = "{\"result\":0, \"msg\":\"" + ex.Message.Replace("\"", "'") + "\"}";
                }
            }
        }

        private void DoServicerActions(string action)
        {
            ServicerService ss = ServicerService.GetInstance();
            if (action.Equals("ServicerOrder"))
            {
                string id = Request["Id"];
                string order = Request["Order"];

                int r = ss.ChangeOrder(id, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("ServicerEnable"))
            {
                string id = Request["Id"];

                int r = ss.Enable(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("ServicerDelete"))
            {
                string id = Request["Id"];

                int r = ss.DeleteModel(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                }
            }
            else if (action.Equals("ServicerCode"))
            {
                string langid = Request["lang"];
                string navurl = Request["navurl"];
                string formatOnline_1_2 = @"
<div id='onlinebox' class='onlinebox onlinebox_{0} onlinebox_{0}_{1}' style='display: none;'>
    <div class='onlinebox-showbox' title='点击可显示'><span>在线交流</span></div>
    <div class='onlinebox-conbox' style='display: none;'>
        <div class='onlinebox-top' title='点击可隐藏'>
            <a href='javascript:;' onclick='return onlineclose();' class='onlinebox-close' title='关闭'></a>
            <span>在线交流</span>
        </div>
        <div class='onlinebox-center'>
            <div class='onlinebox-center-box'>
                {2}
            </div>
        </div>
        <div class='onlinebox-bottom'>
            <div class='onlinebox-bottom-box'>
                <div class='online-tbox'>
                    {3}
                </div>
            </div>
        </div>
        <div class='onlinebox-bottom-bg'></div>
    </div>
    <div class='clear'></div>
</div>"; 
                string formatOnline_3_4 = @"
<div id='onlinebox' class='onlinebox onlinebox_{0} onlinebox_{0}_{1}' style='display: none;'>
    <div class='onlinebox-top'>
        <a href='javascript:;' onclick='return onlineclose();' class='onlinebox-close' title='关闭'></a>
        <span>在线交流</span>
    </div>
    <div class='onlinebox-center'>
        <div class='onlinebox-center-box'>
            {2}
        </div>
    </div>
    <div class='onlinebox-bottom'>
        <div class='onlinebox-bottom-box'>
            <div class='online-tbox'>
                {3}
            </div>
        </div>
    </div>
    <div class='onlinebox-bottom-bg'></div>
    <div class='clear'></div>
</div>";
                StringBuilder sbOnline = new StringBuilder();
                string formatServicer = @"<dl><dt>{0}</dt><dd>{1}</dd></dl><div class='clear'></div>";
                StringBuilder sbServicers = new StringBuilder();
                StringBuilder sbSkype = new StringBuilder();
                StringBuilder sbAli = new StringBuilder();
                string formatQQ = "<span class='qq'><a href='tencent://message/?uin={0}&Site=&Menu=yes' title='{1}'><img border='0' src='http://wpa.qq.com/pa?p=1:{0}:{2}'></a></span>";
                string formatMSN = "<span class='msn'><a href='msnim:chat?contact={0}' title='{1}'><img border='0' alt='{1}' src='{2}.gif' /></a></span>";
                string formatTb = "<span class='taobao'><a target='_blank' href='http://amos.im.alisoft.com/msg.aw?v=2&uid={0}&site=cntaobao&s=2&charset=utf-8' title='{1}'><img border='0' src='http://amos.im.alisoft.com/online.aw?v=2&uid={0}&site=cntaobao&s={2}&charset=utf-8' alt='{1}' /></a></span>";
                string formatAli = "<div class='ali'><a target='_blank' href='http://amos1.sh1.china.alibaba.com/msg.atc?v=1&amp;uid={0}' title='{1}'><img src='http://amos1.sh1.china.alibaba.com/online.atc?v=1&amp;uid={0}&amp;s={2}' alt='{1}' border='0'></a></div>";
                string formatSkype = "<div class='skype'><a href='callto://{0}' title='{1}'><img src='{2}.gif' border='0' alt='{1}'/></a></div>";
                
                cmsLanguage lang = LanguageService.GetInstance().GetModel(langid);
                string configFile = "";
                if (lang != null)
                {
                    configFile = Context.Server.MapPath(string.Format("~/Manage/Config/{0}.config", lang.Code));
                }
                string type = ConfigHelper.GetVal(configFile, "OnlineType");
                string x = ConfigHelper.GetVal(configFile, "OnlineX");
                string y = ConfigHelper.GetVal(configFile, "OnlineY");
                string style = ConfigHelper.GetVal(configFile, "OnlineStyle");
                string format = "";
                if (style.Equals("1") || style.Equals("2"))
                    format = formatOnline_1_2;
                else
                    format = formatOnline_3_4;

                string color = ConfigHelper.GetVal(configFile, "OnlineStyleColor");
                string qq = ConfigHelper.GetVal(configFile, "OnlineIconQQ");
                string msn = ConfigHelper.GetVal(configFile, "OnlineIconMSN");
                string tb = ConfigHelper.GetVal(configFile, "OnlineIconTaobao");
                string ali = ConfigHelper.GetVal(configFile, "OnlineIconAli");
                string skype = ConfigHelper.GetVal(configFile, "OnlineIconSkype");
                string onname = ConfigHelper.GetVal(configFile, "OnlineOnName");
                string info = ConfigHelper.GetVal(configFile, "OnlineOtherInfo");

                
                List<cmsServicer> ls = ss.GetListByLang(long.Parse(langid));
                foreach (var item in ls)
                {
                    string name = (onname == "1") ? item.Name : "";
                    string servicers = "";
                    if (!string.IsNullOrEmpty(item.QQ))
                    {
                        servicers += string.Format(formatQQ, item.QQ, item.Name, qq);
                    }
                    if (!string.IsNullOrEmpty(item.MSN))
                    {
                        servicers += string.Format(formatMSN, item.MSN, item.Name, Request.ApplicationPath + "manage/images/msn/msn_" + msn);
                    }
                    if (!string.IsNullOrEmpty(item.TaobaoWW))
                    {
                        servicers += string.Format(formatTb, item.TaobaoWW, item.Name, tb);
                    }
                    sbServicers.AppendLine(string.Format(formatServicer, name, servicers));
                    if (!string.IsNullOrEmpty(item.SKYPE))
                    {
                        sbSkype.AppendLine(string.Format(formatSkype, item.SKYPE, item.Name, Request.ApplicationPath + "manage/images/skype/skype_" +skype));
                    }
                    if (!string.IsNullOrEmpty(item.AliWW))
                    {
                        sbAli.AppendLine(string.Format(formatAli, item.AliWW, item.Name, ali));
                    }
                }
                sbServicers.AppendLine(sbSkype.ToString());
                sbServicers.AppendLine(sbAli.ToString());

                sbOnline.AppendLine(string.Format(format, style, color, sbServicers.ToString(), info));

                json = sbOnline.ToString();//.Replace("\"", "&quot;").Replace("\r","").Replace("\n","");

                Response.ContentType = "text/html";
            }
        }

        private void DoJobActions(string action)
        {
            JobService js = JobService.GetInstance();
            if (action.Equals("JobOrder"))
            {
                string id = Request["Id"];
                string order = Request["Order"];

                int r = js.ChangeOrder(id, int.Parse(order));
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，排序失败！\"}";
                }
            }
            else if (action.Equals("JobEnable"))
            {
                string id = Request["Id"];

                int r = js.Enable(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，状态改变失败！\"}";
                }
            }
            else if (action.Equals("JobDelete"))
            {
                string id = Request["Id"];

                int r = js.DeleteModel(id);
                if (r > 0)
                {
                    json = "{\"result\":1}";
                }
                else
                {
                    json = "{\"result\":0, \"msg\":\"服务器发生错误，删除失败！\"}";
                }
            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}