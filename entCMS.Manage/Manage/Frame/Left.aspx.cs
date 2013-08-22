using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Manage.Frame
{
    public partial class Left : BasePage
    {
        protected string TreeViewInfo0 = string.Empty;
        protected string TreeViewInfo1 = string.Empty;
        protected string TreeViewInfo2 = string.Empty;

        List<cmsMenu> menus = null;
        MenuService ms = MenuService.GetInstance();

        List<cmsNewsCatalog> catalogs = null;
        NewsCatalogService cs = NewsCatalogService.GetInstance();

        string treeNode = "{0}_Tree.add('{1}', '{2}', '{3}', '{4}', '{3}', 'MainFrame');\n";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            menus = ms.GetMenus();

            try
            {
                catalogs = cs.GetCatalogs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (!IsPostBack)
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="langId"></param>
        /// <returns></returns>
        private string GetNewsCatalogs(long langId)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(string.Format(treeNode, "C", "L" + langId, "C0000", "", ""));
            sb.Append(buildCatalogTree("0000", langId));

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCode"></param>
        /// <param name="langId"></param>
        /// <returns></returns>
        private string buildCatalogTree(string parentCode, long langId)
        {
            StringBuilder sb = new StringBuilder();

            List<cmsNewsCatalog> childs = catalogs.FindAll(c=>c.LangId == langId && c.ParentCode == parentCode);
            if (parentCode == "0000" && childs.Count == 0)
            {
                sb.Append(string.Format(treeNode, "C", "C0001", "C0000", "请先设置栏目", "../System/NewsCatalogList.aspx?lang=" + langId));
                return sb.ToString();
            }
            foreach (cmsNewsCatalog item in childs)
            {
                if (IsAdmin || PurviewExists(item.NodeCode, 0))
                {
                    string url = item.BackUrl;
                    url = GetClientUrl(url);
                    if (!string.IsNullOrEmpty(url))
                    {
                        url = (url.IndexOf('?') >= 0) ? url + "&node=" : url + "?node=";
                        url += item.NodeCode + "&lang=" + langId;
                    }
                    if (parentCode == "0000")
                    {
                        //sb.Append(string.Format(treeNode, "C", "C" + item.NodeCode, "L" + language, item.NodeName, url));
                        sb.Append(string.Format(treeNode, "C", "C" + item.NodeCode, "C0000", item.NodeName, url));
                    }
                    else
                    {
                        sb.Append(string.Format(treeNode, "C", "C" + item.NodeCode, "C" + item.ParentCode, item.NodeName, url));
                    }
                    sb.Append(buildCatalogTree(item.NodeCode, langId));
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        private string buildMenuTree(string parentCode, string prefixStr, int menuType)
        {
            StringBuilder sb = new StringBuilder();

            List<cmsMenu> childs = menus.FindAll(m => m.ParentCode == parentCode && m.MenuType == menuType);
            foreach (cmsMenu item in childs)
            {
                if (IsAdmin || PurviewExists(item.MenuCode, 1))
                {
                    string url = item.MenuUrl;
                    url = GetClientUrl(url);
                    if (!string.IsNullOrEmpty(url))
                    {
                        url = (url.IndexOf('?') >= 0) ? url + "&node=" : url + "?node=";
                        url += item.MenuCode;
                    }
                    sb.Append(string.Format(treeNode, prefixStr, prefixStr + item.MenuCode, prefixStr + parentCode, item.MenuName, url));
                    sb.Append(buildMenuTree(item.MenuCode, prefixStr, menuType));
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (CurrentLanguageId==0)
            {
                TreeViewInfo0 = string.Format(treeNode, "C", "C0001", "C0000", "请先选择语言", "");
            }
            else
            {
                TreeViewInfo0 = GetNewsCatalogs(CurrentLanguageId);
            }
            TreeViewInfo1 = buildMenuTree("0000", "A", 1);
            TreeViewInfo2 = buildMenuTree("0000", "S", 0);

            string ctree = "";
            ctree += "<script type='text/javascript'>\n";
            ctree += "var C_Tree = new dTree('C_Tree','../');\n";
            ctree += "C_Tree.add('C0000',-1,'内容管理');\n";
            ctree += TreeViewInfo0;
            ctree += "document.write(C_Tree);\n";
            ctree += "</script>\n";
            ltlCTree.Text = ctree;

            string atree = "";
            atree += "<script type='text/javascript'>\n";
            atree += "var A_Tree = new dTree('A_Tree','../');\n";
            atree += "A_Tree.add('A0000',-1,'其他管理');\n";
            atree += TreeViewInfo1;
            atree += "document.write(A_Tree);\n";
            atree += "</script>\n";
            ltlATree.Text = atree;

            string stree = "";
            stree += "<script type='text/javascript'>\n";
            stree += "var S_Tree = new dTree('S_Tree','../');\n";
            stree += "S_Tree.add('S0000',-1,'系统管理');\n";
            stree += TreeViewInfo2;
            stree += "document.write(S_Tree);\n";
            stree += "</script>\n";
            ltlSTree.Text = stree;
        }
    }
}