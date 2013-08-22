using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using entCMS.Common;
using System.Data;

namespace entCMS.Manage.Module
{
    public partial class NewsMoveTo : BasePage
    {
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        string id = "";
        string type = "";
        public NewsMoveTo()
            : base(PagePurviewType.PPT_NEWS)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            type = Request["type"];

            if (!IsPostBack)
            {
                CatalogsBind();
            }
        }

        private void CatalogsBind()
        {
            if (string.IsNullOrEmpty(type)) return;
            string[] types = type.Split('|');

            List<cmsNewsCatalog> catalogs = ncs.GetList(cmsNewsCatalog._.IsEnabled == 1 && cmsNewsCatalog._.NodeType.SelectIn(types), cmsNewsCatalog._.LangId.Asc && cmsNewsCatalog._.OrderNo.Asc);
            List<cmsNewsCatalog> childs = catalogs.FindAll(m => m.ParentCode == "0000");

            buildCatalogTree(tblCatalogs, catalogs, childs, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="menus"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildCatalogTree(Table tbl, List<cmsNewsCatalog> catalogs, List<cmsNewsCatalog> childs, string prefix)
        {
            string pf = "";

            for (int i = 0; i < childs.Count; i++)
            {
                cmsNewsCatalog item = childs[i];
                List<cmsNewsCatalog> children = catalogs.FindAll(m => m.ParentCode == item.NodeCode);
                if (item.NodeType<8 && (IsAdmin || PurviewExists(item.NodeCode, 0)))
                {
                    TableRow tr = new TableRow();
                    tr.CssClass = "Row";

                    // 单选框
                    TableCell td = new TableCell();

                    td.Width = Unit.Pixel(20);
                    HtmlInputRadioButton rb = new HtmlInputRadioButton();
                    rb.ID = "C" + item.NodeCode;
                    rb.Attributes.Add("class", "C");
                    rb.Value = item.NodeCode;
                    rb.Attributes.Add("onclick", "selectCatalog(this);");
                    if (children.Count > 0) rb.Attributes.Add("disabled", "disabled");
                    td.Controls.Add(rb);
                    tr.Cells.Add(td);
                    // 栏目名称
                    td = new TableCell();
                    td.Style.Add("text-align", "left");
                    //td.Style.Add("padding-left", "10px");
                    if (i < childs.Count - 1)
                    {
                        td.Text = prefix + "├" + item.NodeName;
                        pf = prefix + "│";
                    }
                    else
                    {
                        td.Text = prefix + "└" + item.NodeName;
                        pf = prefix + "　"; // 全角空格[　]制表符[│][├][└]
                    }
                    tr.Cells.Add(td);

                    tbl.Rows.Add(tr);

                    
                    if (children.Count > 0)
                    {
                        buildCatalogTree(tbl, catalogs, children, pf);
                    }
                    else
                    {
                        if (item.NodeType == 0) tbl.Rows.Remove(tr);
                    }
                }
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            NewsService ns = NewsService.GetInstance();

            string[] c_vals = hidCatalog.Value.Replace(",,", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                int r = ns.MoveTo(id.Split(','), c_vals);

                ScriptUtil.RefreshFrame("MainFrame");
                ScriptUtil.AlertAndCloseDialog("移动操作成功！");
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert("服务器发生未知错误！");

                Logger.Error(ex.Message);
            }
        }
    }
}