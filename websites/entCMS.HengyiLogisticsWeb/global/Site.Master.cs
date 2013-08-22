using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using entCMS.Models;

namespace entCMS.HengyiLogisticsWeb.global
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected WebPage webPage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page is WebPage)
            {
                webPage = (this.Page as WebPage);
            }
            else
            {
                webPage = new WebPage(1);
            }
            Page.Title = webPage.WebName;
            ltlKeyword.Text = "<meta name=\"keywords\" content=\"" + webPage.Keywords + "\"/>";
            ltlDescription.Text = "<meta name=\"description\" content=\"" + webPage.Description + "\"/>";
        }
        /*
        /// <summary>
        /// 
        /// </summary>
        protected string MainMenu
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<dl class='one'><dt><a href='{0}' title=''>{1}</a></dt></dl>", webPage.GetClientUrl(webPage.CurrentLanguage.HomeUrl), webPage.Home);
                var tops = webPage.NewsCatalogs.FindAll(x => x.ParentCode == "0000");
                foreach (cmsNewsCatalog item in tops)
                {
                    if (item.NavType == 0 || item.NavType == 2) continue;  // 不是头部导航
                    
                    sb.Append("<dl class='one'>");
                    sb.AppendFormat("<dt><a href='{0}' title=''>{1}</a></dt>", webPage.GetNodeUrl(item, false), item.NodeName);
                    
                    StringBuilder sbSub = new StringBuilder();
                    var subs = webPage.NewsCatalogs.FindAll(x => x.ParentCode == item.NodeCode);
                    if (subs.Count > 0)
                    {
                        sb.Append("<dd class='menudd'>");
                        sb.Append("<ul class='fixed'>");
                        getNodeTreeStr(sbSub, subs, item.NodeCode);
                        sb.Append("</ul>");
                    }
                    string url = webPage.GetNodeUrl(item, true);
                    sb.AppendFormat("<li>{0}{1}</li>" + sepStr, url, sbSub.ToString());

                    sb.Append("</dl>");
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="menus"></param>
        /// <param name="parentCode"></param>
        private void getNodeTreeStr(StringBuilder sb, List<cmsNewsCatalog> menus, string parentCode)
        {
            sb.Append("<ul>");
            foreach (cmsNewsCatalog item in menus)
            {
                if (item.NavType == 0 || item.NavType == 2) continue;  // 不是头部导航

                var subs = webPage.NewsCatalogs.FindAll(x => x.ParentCode == item.NodeCode);
                StringBuilder sbSub = new StringBuilder();
                if (subs.Count > 0)
                {
                    getNodeTreeStr(sbSub, subs, item.NodeCode);
                }
                string url = webPage.GetNodeUrl(item, true);

                sb.AppendFormat("<li>{0}{1}</li>", url, sbSub.ToString());
            }
            sb.Append("</ul>");
        }
        */
    }
}