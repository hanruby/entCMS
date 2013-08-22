using System;
using System.Collections.Generic;
using System.Web;
using entCMS.Models;
using entCMS.Common;
using entCMS.Services;
using System.Text;
using System.Data;
using System.IO;
using System.Configuration;

namespace entCMS
{
    public class WebPage : System.Web.UI.Page
    {
        #region 公用属性
        /// <summary>
        /// 在线客服代码
        /// </summary>
        public string OnlineInfo
        {
            get
            {
                string onlineType = GetConfigVal("OnlineType");
                string onlineX = GetConfigVal("OnlineX");
                string onlineY = GetConfigVal("OnlineY");
                return 
                    string.Format("<a id='online_param' href='?t={0}&u=/&x={1}&y={2}&lang={3}'></a><script type='text/javascript' src='{4}'></script>",
                    onlineType,
                    onlineX,
                    onlineY,
                    CurrentLanguage.Id,
                    GetClientUrl("~/Manage/scripts/online.js"));
            }
        }
        /// <summary>
        /// 语言列表
        /// </summary>
        public List<cmsLanguage> Languages
        {
            get
            {
                return LanguageService.GetInstance().GetLanguages();
            }
        }
        private cmsLanguage currentLanguage = null;
        /// <summary>
        /// 当前语言
        /// </summary>
        public cmsLanguage CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
        private string currentConfigFile = string.Empty;
        /// <summary>
        /// 当前配置文件
        /// </summary>
        public string CurrentConfigFile
        {
            get { return currentConfigFile; }
            set { currentConfigFile = value; }
        }
        private string _nodeCode = "";
        /// <summary>
        /// 当前节点代码
        /// </summary>
        public string NodeCode
        {
            get
            {
                if (string.IsNullOrEmpty(_nodeCode))
                {
                    _nodeCode = Request["node"];
                }
                return _nodeCode;
            }
            set { _nodeCode = value; }
        }
        /// <summary>
        /// 当前节点
        /// </summary>
        public cmsNewsCatalog Node
        {
            get
            {
                cmsNewsCatalog c = NewsCatalogService.GetInstance().Get(NodeCode);
                return c != null ? c : new cmsNewsCatalog();
            }
        }
        private string _topCode = "";
        /// <summary>
        /// 当前节点的顶级节点代码
        /// </summary>
        public string TopCode
        {
            get
            {
                if (!string.IsNullOrEmpty(NodeCode))
                {
                    if (NodeCode.Length >= 4)
                    {
                        _topCode = NodeCode.Substring(0, 4);
                    }
                    else
                    {
                        _topCode = "";
                    }
                }
                return _topCode;
            }
            set { _topCode = value; }
        }
        /// <summary>
        /// 当前节点的顶级节点
        /// </summary>
        public cmsNewsCatalog TopNode
        {
            get
            {
                cmsNewsCatalog c = NewsCatalogService.GetInstance().Get(TopCode);
                return c != null ? c : new cmsNewsCatalog();
            }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurPage
        {
            get
            {
                string p = Request["page"];
                int page = 0;
                if (!int.TryParse(p, out page))
                    return 1;
                return page;
            }
        }
        /// <summary>
        /// 网站名字
        /// </summary>
        public string WebName
        {
            get
            {
                return ConfigHelper.GetVal(CurrentConfigFile, "WebName");
            }
        }
        /// <summary>
        /// 网站图标
        /// </summary>
        public string WebLogo
        {
            get
            {
                return ConfigHelper.GetVal(CurrentConfigFile, "WebLogo");
            }
        }
        /// <summary>
        /// 网站地址
        /// </summary>
        public string WebUrl
        {
            get
            {
                return ConfigHelper.GetVal(CurrentConfigFile, "WebUrl");
            }
        }
        /// <summary>
        /// 网站关键字
        /// </summary>
        public string Keywords
        {
            get
            {
                return ConfigHelper.GetVal(CurrentConfigFile, "Keywords");
            }
        }
        /// <summary>
        /// 网站描述
        /// </summary>
        public string Description
        {
            get
            {
                return ConfigHelper.GetVal(CurrentConfigFile, "Description");
            }
        }
        /// <summary>
        /// 是否使用伪静态
        /// </summary>
        public bool IsUrlRewrite
        {
            get
            {
                return ConfigHelper.GetVal<bool>(CurrentConfigFile, "UrlRewrite");
            }
        }
        /// <summary>
        /// 公司信息
        /// </summary>
        public cmsCompany Company
        {
            get
            {
                cmsCompany com = CompanyService.GetInstance().GetByLangId(CurrentLanguage.Id);

                return com != null ? com : new cmsCompany();
            }
        }
        /// <summary>
        /// 节点列表
        /// </summary>
        public List<cmsNewsCatalog> NewsCatalogs
        {
            get
            {
                return NewsCatalogService.GetInstance().GetCatalogs(CurrentLanguage.Id);
            }
        }
        /// <summary>
        /// 头部菜单
        /// </summary>
        public string TopMenus
        {
            get
            {
                return GetMenus("0000", "menu", "sf-menu", "", true, 1);
            }
        }
        /// <summary>
        /// 侧边菜单
        /// </summary>
        public string SideMenus
        {
            get
            {
                return GetMenus(TopCode, "sidemenu", "", "", true, 1);
            }
        }
        /// <summary>
        /// 底部菜单
        /// </summary>
        public string BottomMenus
        {
            get
            {
                return GetMenus("0000", "buttommenu", "", "", true, 2);
            }
        }
        /// <summary>
        /// 幻灯片列表
        /// </summary>
        public List<cmsSlideshow> Slideshows
        {
            get
            {
                return SlideshowService.GetInstance().GetListByLangId(CurrentLanguage.Id, true);
            }
        }

        #region 网站资源
        private ResourceManager resources = null;
        /// <summary>
        /// 资源集合
        /// </summary>
        public ResourceManager Resources
        {
            get
            {
                if (resources == null) resources = new ResourceManager(currentConfigFile, "Resource");
                return resources;
            }
        }
        ///// <summary>
        ///// 资源集合，可以直接用Resources[key]调用
        ///// </summary>
        //public KeyValueConfigurationCollection Resources
        //{
        //    get
        //    {
        //        AppSettingsSection appSec = (AppSettingsSection)ConfigHelper.GetSection(currentConfigFile, "Resource");
        //        if (appSec == null)
        //        {
        //            appSec = new AppSettingsSection();
        //        }
        //        return appSec.Settings;
        //    }
        //}
        /// <summary>
        /// 首页名称
        /// </summary>
        public string Home
        {
            get
            {
                return Resources["Home"];
            }
        }
        #endregion        
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public WebPage()
        {
            long langId = 0;
            // 1. 从当前配置文件中读取
            //if (currentLanguage == null)
            //{
            //    string path = HttpContext.Current.Request.PhysicalPath;
            //    path = path.Substring(0, path.LastIndexOf('\\'));
            //    string langfile = path + "\\lang.config";
            //    if (File.Exists(langfile))
            //    {
            //        langId = ConfigHelper.GetVal<long>(langfile, "langId");

            //        currentLanguage = LanguageService.GetInstance().GetModel(langId);
            //    }
            //}
            // 1. 从请求参数中获取
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["lng"]))
            {
                string code = HttpContext.Current.Request["lng"];
                currentLanguage = LanguageService.GetInstance().GetModelWithWhere(cmsLanguage._.Code == code);
            }
            // 2. 先从cookie读取
            if (currentLanguage ==  null && !string.IsNullOrEmpty(CookieHelper.GetCookieValue("__Language__")))
            {
                if (!string.IsNullOrEmpty(CookieHelper.GetCookieValue("__Language__", "Object")))
                {
                    currentLanguage = SerializeHelper.Desrialize<cmsLanguage>(CookieHelper.GetCookieValue("__Language__", "Object"));
                }
                else
                {
                    langId = long.Parse(CookieHelper.GetCookieValue("__Language__"));

                    currentLanguage = LanguageService.GetInstance().GetModel(langId);
                }
                if (!string.IsNullOrEmpty(CookieHelper.GetCookieValue("__Language__", "ConfigFile")))
                {
                    currentConfigFile = CookieHelper.GetCookieValue("__Language__", "ConfigFile");
                }
            }
            // 3. 从语言列表中取默认语言
            if (currentLanguage == null)
            {
                currentLanguage = Languages.Find(x => x.IsDefault == 1);
                //CookieHelper.SetCookie("__Lanugage__", "Object", SerializeHelper.Serialize<cmsLanguage>(currentLanguage));
            }
            // 4. 抛出异常
            if (currentLanguage == null)
            {
                throw new Exception("网站语言未设置或者默认语言未指定，请到系统管理->系统设置->语言设置中进行设置。");
            }
            else
            {
                CookieHelper.SetCookie("__Language__", currentLanguage.Id.ToString());
                CookieHelper.SetCookie("__Lanugage__", "Object", SerializeHelper.Serialize<cmsLanguage>(currentLanguage));
            }
            if (string.IsNullOrEmpty(currentConfigFile))
            {
                currentConfigFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", currentLanguage.Code));
                CookieHelper.SetCookie("__Lanugage__", "ConfigFile", string.Format("~/Manage/Config/{0}.config", currentLanguage.Code));
            }
        }
        /// <summary>
        /// 指定语言
        /// </summary>
        /// <param name="langId"></param>
        public WebPage(long langId)
        {
            currentLanguage = LanguageService.GetInstance().GetModel(langId);
            CookieHelper.SetCookie("__Language__", langId.ToString());
            CookieHelper.SetCookie("__Lanugage__", "Object", SerializeHelper.Serialize<cmsLanguage>(currentLanguage));
            currentConfigFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", currentLanguage.Code));
            CookieHelper.SetCookie("__Lanugage__", "ConfigFile", string.Format("~/Manage/Config/{0}.config", currentLanguage.Code));

        } 
        #endregion

        #region 获取当前语言的根目录
        public string GetCurrentPath()
        {
            return entCMS.Common.WebUtil.GetClientUrl(this, currentLanguage.HomeUrl).TrimEnd('/');
        }
        #endregion

        #region 取得当前网站的路径
        public string GetAppPath()
        {
            string path = "http://" + HttpContext.Current.Request.ServerVariables["Http_Host"] + HttpContext.Current.Request.ApplicationPath;
            if (path.LastIndexOf('/') == path.Length - 1)
                return path;
            else
                return path + "/";
        }
        #endregion

        #region 获取客户端可访问的url
        public string GetClientUrl(string url)
        {
            return entCMS.Common.WebUtil.GetClientUrl(this, url);
        }
        #endregion

        #region 读取配置文件的值
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigVal(string key)
        {
            return ConfigHelper.GetVal(CurrentConfigFile, key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetConfigVal<T>(string key)
        {
            return ConfigHelper.GetVal<T>(CurrentConfigFile, key);
        }
        #endregion

        #region 内容相关
        /// <summary>
        /// 根据栏目编号获取推荐到首页的列表
        /// </summary>
        /// <param name="node"></param>
        /// <param name="top"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public DataTable GetIndexNews(string node, int top, bool isLike)
        {
            return NewsService.GetInstance().GetIndexList(CurrentLanguage.Id, node, top, isLike);
        }
        /// <summary>
        /// 根据栏目类型获取推荐到首页的列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataTable GetIndexNews(int type, int top)
        {
            return NewsService.GetInstance().GetIndexList(CurrentLanguage.Id, type, top);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public int GetNewsCount(string node, bool isLike)
        {
            return NewsService.GetInstance().GetListCount(CurrentLanguage.Id, node, isLike);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="top"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public DataTable GetNews(string node, bool isLike, int pageIndex, int pageSize, ref int recordCount)
        {
            return NewsService.GetInstance().GetList(CurrentLanguage.Id, node, isLike, pageIndex, pageSize, ref recordCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNewsUrl(string url, object id)
        {
            int idx = url.LastIndexOf('.');
            string u = url.Substring(0, idx);
            string e = url.Substring(idx + 1);

            string prodShowFormat = IsUrlRewrite ? "/{0}/{1}.html" : "/{0}.aspx?id={1}";
            url = GetCurrentPath() + string.Format(prodShowFormat, u, id);
            return url;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">分页：0:first,1:prev,2:next,3:last</param>
        /// <param name="count">记录总数</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public string GetPageStr(string[] name, int count, int pageSize)
        {
            int pages = (count % pageSize == 0) ? count / pageSize : count / pageSize + 1;

            int page = Convert.ToInt32(Request["page"]);
            if (page <= 0) page = 1;
            if (page > pages) page = pages;

            string href = Request.RawUrl;

            return href;
        }
        #endregion

        #region 栏目相关
        /// <summary>
        /// 获取某栏目下的第一个子栏目
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        private cmsNewsCatalog getFirstNode(string parentCode)
        {
            return NewsCatalogService.GetInstance().GetFirstChildNode(parentCode);
        }
        /// <summary>
        /// 获取某栏目的子栏目集合
        /// </summary>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetChildNodes(string nodeCode, bool isLike)
        {
            return NewsCatalogService.GetInstance().GetChildList(nodeCode, isLike, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCode">最上层栏目代码</param>
        /// <param name="idPrefix">菜单id的前缀</param>
        /// <param name="className">顶层ul的class</param>
        /// <param name="sepStr">第一级各菜单直接的分隔样式</param>
        /// <param name="isShowHome">是否显示主页菜单</param>
        /// <param name="navType">导航类别：0-全不显示，1-头部显示，2-底部显示，3-全显示</param>
        /// <returns></returns>
        public string GetMenus(string nodeCode, string idPrefix, string className, string sepStr, bool isShowHome, int navType)
        {
            bool hasFirstClass = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul id='{0}' class='{1} level{2:D2}'>", idPrefix, className, 1);
            if (nodeCode == "0000" && isShowHome)
            {
                hasFirstClass = true;
                sb.AppendFormat("<li class='first'><a href='{0}' title=''>{1}</a></li>" + sepStr, GetClientUrl(CurrentLanguage.HomeUrl), Home);
            }
            var tops = GetChildNodes(nodeCode, true);
            int i = 0;
            string cls = "";
            foreach (cmsNewsCatalog item in tops)
            {
                if (i == 0 && !hasFirstClass) cls = "first";
                else if (i == tops.Count - 1) cls = "last";

                if ((item.NavType & 3) == navType)
                {
                    StringBuilder sbSub = new StringBuilder();
                    var subs = NewsCatalogs.FindAll(x => x.ParentCode == item.NodeCode);
                    if (subs.Count > 0)
                    {
                        getNodeTreeStr(sbSub, subs, idPrefix, item.NodeCode, navType, 1);
                    }
                    string url = getNodeUrl(item, true);

                    sb.AppendFormat("<li class='{0}'>{1}{2}</li>" + sepStr, cls, url, sbSub.ToString());
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="children"></param>
        /// <param name="parentCode"></param>
        private void getNodeTreeStr(StringBuilder sb, List<cmsNewsCatalog> children, string parentCode, string idPrefix, int navType, int level)
        {
            sb.AppendFormat("<ul id='{0}' class='level{1:D2}'>", idPrefix + parentCode, level + 1);
            foreach (cmsNewsCatalog item in children)
            {
                if ((item.NavType & 3) == navType)
                {
                    var subs = NewsCatalogs.FindAll(x => x.ParentCode == item.NodeCode);
                    StringBuilder sbSub = new StringBuilder();
                    if (subs.Count > 0)
                    {
                        getNodeTreeStr(sbSub, subs, item.NodeCode, idPrefix, navType, level + 1);
                    }
                    string url = getNodeUrl(item, true);

                    sb.AppendFormat("<li>{0}{1}</li>", url, sbSub.ToString());
                }
            }
            sb.Append("</ul>");
        }        
        /// <summary>
        /// 获取当前栏目的路径（当前位置）
        /// </summary>
        /// <returns></returns>
        public string GetNavStr(string delimiter = " &gt ")
        {
            if (string.IsNullOrEmpty(NodeCode))
            {
                throw new ArgumentNullException("栏目无效！");
            }
            if (string.IsNullOrEmpty(delimiter)) delimiter = " &gt ";
            return NewsCatalogService.GetInstance().GetNavStr(NodeCode, delimiter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="addTags"></param>
        /// <returns></returns>
        public string GetNodeUrl(string node, bool addTags)
        {
            cmsNewsCatalog c = NewsCatalogService.GetInstance().Get(node);
            return getNodeUrl(c, addTags);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="addTags"></param>
        /// <returns></returns>
        public string GetNodeUrl(cmsNewsCatalog node, bool addTags)
        {
            return getNodeUrl(node, addTags);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string getNodeUrl(cmsNewsCatalog node, bool addTags)
        {
            string url = "", target = "";
            string aformat = "<a href='{0}' title='{1}' target='{2}'>{1}</a>";
            if (node == null) return addTags ? string.Format(aformat, "", "", "") : url;
            string nodename = node.NodeName;
            int t = node.NodeType;
            if (t == 0)
            {
                cmsNewsCatalog nc = getFirstNode(node.NodeCode);
                if (nc != null)
                {
                    node = nc;
                    t = node.NodeType;
                }
            }
            cmsModule mdl = ModuleService.GetInstance().GetModel(t);
            string frontUrl = mdl == null ? "NewsList.aspx" : mdl.FrontUrl;
            string u1 = string.Empty;
            string u2 = string.Empty;
            if (frontUrl.Length > 1)
            {
                string[] u = frontUrl.Split('.');
                u1 = "/" + u[0] + "/{0}.html";  // 如 "/Page/0001.html"
                u2 = "/" + frontUrl + "?node={0}";    // 如 "/Page.aspx"
            }
            if (t != 20) // 不是外链模块
            {
                url = CurrentLanguage.HomeUrl.TrimEnd('/') + string.Format((IsUrlRewrite ? u1 : u2), node.NodeCode);
                url = GetClientUrl(url);
            }
            else
            {
                url = node.LinkUrl;
                target = "_blank";
            }
            return addTags ? string.Format(aformat, url, nodename, target) : url;
        }
        #endregion

        #region 错误处理
        protected override void OnError(EventArgs e)
        {
            base.OnError(e);

            Exception error = Server.GetLastError();
            Application["error"] = error;
            //清除前一个异常
            Server.ClearError();
            Response.Redirect("~/Error.aspx");

        } 
        #endregion
    }
}