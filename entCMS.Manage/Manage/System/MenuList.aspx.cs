using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using System.Web.UI.HtmlControls;

namespace entCMS.Manage
{
    public partial class MenuList : BasePage
    {
        MenuService ms = MenuService.GetInstance();

        public MenuList()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenusBind();
            }
        }

        private void MenusBind()
        {
            List<cmsMenu> menus = ms.GetList(null, cmsMenu._.OrderNo.Asc);

            buildMenuTree(tblMenus, menus, "0000", "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="menus"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildMenuTree(Table tbl, List<cmsMenu> menus, string parentCode, string prefix)
        {
            string pf = "";
            List<cmsMenu> childs = menus.FindAll(delegate(cmsMenu m) { return m.ParentCode == parentCode; });
            for (int i = 0; i < childs.Count; i++)
            {
                cmsMenu item = childs[i];

                TableRow tr = new TableRow();
                tr.CssClass = "Row";
                TableCell td = null;

                td = new TableCell();
                HtmlInputText inp = new HtmlInputText();
                inp.ID = item.MenuCode;
                inp.Size = 6;
                inp.Style.Add("text-align", "center");
                inp.Attributes.Add("onblur", "changeOrder('" + inp.ID + "'," + item.OrderNo + ",this.value);");
                inp.Value = item.OrderNo.ToString();
                //td.Text = item.OrderNo.ToString();
                td.Controls.Add(inp);
                tr.Cells.Add(td);

                td = new TableCell();
                td.Style.Add("text-align", "left");
                td.Style.Add("padding-left", "10px");
                if (i < childs.Count - 1)
                {
                    td.Text = prefix + "├" + item.MenuName;
                    pf = prefix + "│";
                }
                else
                {
                    td.Text = prefix + "└" + item.MenuName;
                    pf = prefix + "　"; // 全角空格[　]制表符[│][├][└]
                }
                tr.Cells.Add(td);

                td = new TableCell();
                td.Style.Add("text-align", "left");
                td.Text = item.MenuUrl;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = item.MenuType.Value == 0 ? "系统" : "应用";
                tr.Cells.Add(td);

                td = new TableCell();
                HtmlAnchor enable = new HtmlAnchor();
                enable.InnerText = (item.IsEnabled.HasValue ? item.IsEnabled.Value == 1 : false) ? "是" : "否";
                enable.HRef = "javascript:void(0);";
                enable.Attributes.Add("onclick", "enable(this, '" + item.MenuCode + "'); return false;");
                td.Controls.Add(enable);
                tr.Cells.Add(td);

                td = new TableCell();
                HtmlAnchor add = new HtmlAnchor();
                add.InnerText = "添加";
                add.HRef = "MenuAdd.aspx?node=" + NodeCode + "&code=" + item.MenuCode + "&action=add";
                td.Controls.Add(add);
                HtmlGenericControl blank = new HtmlGenericControl();
                blank.InnerText = " ";
                td.Controls.Add(blank);
                HtmlAnchor edit = new HtmlAnchor();
                edit.InnerText = "编辑";
                edit.HRef = "MenuAdd.aspx?node=" + NodeCode + "&code=" + item.MenuCode + "&action=edit";
                td.Controls.Add(edit);
                blank = new HtmlGenericControl();
                blank.InnerText = " ";
                td.Controls.Add(blank);
                HtmlAnchor del = new HtmlAnchor();
                del.InnerText = "删除";
                del.HRef = "javascript:void(0);";
                del.Attributes.Add("onclick", "del('" + item.MenuCode + "'); return false;");
                td.Controls.Add(del);
                tr.Cells.Add(td);

                tbl.Rows.Add(tr);

                buildMenuTree(tbl, menus, item.MenuCode, pf);
            }
        }

    }
}