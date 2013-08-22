using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using System.Web.UI.HtmlControls;
using entCMS.Common;
using System.Text;
using System.Data;

namespace entCMS.Manage
{
    public partial class UserPurview : BasePage
    {
        MenuService ms = MenuService.GetInstance();
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        UserPurviewService ups = UserPurviewService.GetInstance();
        UserService us = UserService.GetInstance();
        

        string id = "";

        public UserPurview()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];

            if (!IsPostBack)
            {
                CatalogsBind();

                MenusBind();

                InitData();
            }
        }

        private void InitData()
        {
            //SysUser u = us.Get2(id);
            cmsUser u = us.GetModel(id);

            if (u != null)
            {
                //lblUser.Text = u.cLoginName + " / " + u.cUserName;
                lblUser.Text = u.UName + " / " + u.Name;

                // 取权限
                List<cmsUserPurview> purviews = ups.GetList(Convert.ToInt32(id));
                List<cmsUserPurview> c_purviews = purviews.FindAll(r=>r.Type == 0);
                List<cmsUserPurview> s_purviews = purviews.FindAll(r=>r.Type == 1);

                StringBuilder sb = new StringBuilder();
                foreach (cmsUserPurview item in c_purviews)
                {
                    sb.Append("," + item.NodeCode + ",");
                }
                hidCatalog.Value = sb.ToString();
                sb.Remove(0, sb.Length);
                foreach (cmsUserPurview item in s_purviews)
                {
                    sb.Append("," + item.NodeCode + ",");
                }
                hidMenu.Value = sb.ToString();
            }
        }

        
        private void CatalogsBind()
        {
            List<cmsNewsCatalog> catalogs = ncs.GetList(cmsNewsCatalog._.IsEnabled == 1, cmsNewsCatalog._.LangId.Asc && cmsNewsCatalog._.OrderNo.Asc);

            buildCatalogTree(tblCatalogs, catalogs, "0000", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="menus"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildCatalogTree(Table tbl, List<cmsNewsCatalog> menus, string parentCode, string prefix)
        {
            string pf = "";
            List<cmsNewsCatalog> childs = menus.FindAll(delegate(cmsNewsCatalog m) { return m.ParentCode == parentCode; });
            for (int i = 0; i < childs.Count; i++)
            {
                cmsNewsCatalog item = childs[i];
                
                {
                    TableRow tr = new TableRow();
                    tr.CssClass = "Row";

                    // 复选框
                    TableCell td = new TableCell();
                    td.Width = Unit.Pixel(20);
                    HtmlInputCheckBox cb = new HtmlInputCheckBox();
                    cb.ID = "C" + item.NodeCode;
                    cb.Attributes.Add("class", "C");
                    cb.Value = item.NodeCode;
                    cb.Attributes.Add("onclick", "selectCatalog(this);");
                    td.Controls.Add(cb);
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

                    buildCatalogTree(tbl, menus, item.NodeCode, pf);
                }
            }
        }

        private void MenusBind()
        {
            List<cmsMenu> menus = ms.GetList(cmsMenu._.IsEnabled == 1, cmsMenu._.OrderNo.Asc);

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

                TableCell td = new TableCell();
                td.Width = Unit.Pixel(20);
                HtmlInputCheckBox cb = new HtmlInputCheckBox();
                cb.ID = "S" + item.MenuCode;
                cb.Attributes.Add("class", "S");
                cb.Value = item.MenuCode;
                cb.Attributes.Add("onclick", "selectMenu(this);");
                td.Controls.Add(cb);
                tr.Cells.Add(td);

                // 栏目名称
                td = new TableCell();
                td.Style.Add("text-align", "left");
                //td.Style.Add("padding-left", "10px");
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

                tbl.Rows.Add(tr);

                buildMenuTree(tbl, menus, item.MenuCode, pf);
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            long r = Convert.ToInt64(id);

            List<cmsUserPurview> ls = new List<cmsUserPurview>();
            string[] c_vals = hidCatalog.Value.Replace(",,", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] s_vals = hidMenu.Value.Replace(",,", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < c_vals.Length; i++)
            {
                cmsUserPurview rp = new cmsUserPurview();
                rp.UserId = r;
                rp.NodeCode = c_vals[i];
                rp.Type = 0;
                ls.Add(rp);
            }
            for (int i = 0; i < s_vals.Length; i++)
            {
                cmsUserPurview rp = new cmsUserPurview();
                rp.UserId = r;
                rp.NodeCode = s_vals[i];
                rp.Type = 1;
                ls.Add(rp);
            }

            try
            {
                r = ups.Add(r, ls);

                ScriptUtil.AlertAndCloseDialog("权限分配成功！");
            }
            catch(Exception ex)
            {
                ScriptUtil.Alert("服务器发生未知错误！");

                Logger.Error(ex.Message);
            }
        }

    }
}