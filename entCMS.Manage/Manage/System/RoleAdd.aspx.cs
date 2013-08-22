using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage
{
    public partial class RoleAdd : BasePage
    {
        MenuService ms = MenuService.GetInstance();
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        RoleService rs = RoleService.GetInstance();
        RolePurviewService rps = RolePurviewService.GetInstance();

        cmsRole role = null;

        string id = "";
        string action = "";

        public RoleAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            if (!IsPostBack)
            {
                CatalogsBind();

                MenusBind();

                InitData();
            }
        }

        private void InitData()
        {
            role = rs.GetModel(id);
            if (role != null)
            {
                hidID.Value = role.Id.ToString();
                txtName.Text = role.RoleName;
                txtOrder.Text = role.OrderNo.ToString();
                chkEnabled.Checked = role.IsEnabled.HasValue ? role.IsEnabled.Value == 1 : false;

                // 取权限
                List<cmsRolePurview> purviews = rps.GetList(Convert.ToInt32(id));
                List<cmsRolePurview> c_purviews = purviews.FindAll(delegate(cmsRolePurview r) { return r.Type == 0; });
                List<cmsRolePurview> s_purviews = purviews.FindAll(delegate(cmsRolePurview r) { return r.Type == 1; });
                
                StringBuilder sb = new StringBuilder();
                foreach (cmsRolePurview item in c_purviews)
                {
                    sb.Append("," + item.NodeCode + ",");
                }
                hidCatalog.Value = sb.ToString();
                sb.Remove(0, sb.Length);
                foreach (cmsRolePurview item in s_purviews)
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
            if (string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";

            if (action.Equals("add"))
            {
                role = new cmsRole();
            }
            else
            {
                role = rs.GetModel(id);
                if (role != null)
                {
                    role.Attach();
                }
                else
                {
                    role = new cmsRole();
                }
            }

            role.RoleName = txtName.Text.Trim();
            role.OrderNo = Convert.ToInt32(txtOrder.Text.Trim());
            role.IsEnabled = chkEnabled.Checked ? 1 : 0;

            try
            {
                long r = rs.Save(role);
                if (action.Equals("edit"))
                {
                    r = role.Id;
                }
                if (r > 0)
                {
                    hidID.Value = r.ToString();

                    List<cmsRolePurview> ls = new List<cmsRolePurview>();
                    string[] c_vals = hidCatalog.Value.Replace(",,", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] s_vals = hidMenu.Value.Replace(",,", ",").Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < c_vals.Length; i++)
                    {
                        cmsRolePurview rp = new cmsRolePurview();
                        rp.RoleId = r;
                        rp.NodeCode = c_vals[i];
                        rp.Type = 0;
                        ls.Add(rp);
                    }
                    for (int i = 0; i < s_vals.Length; i++)
                    {
                        cmsRolePurview rp = new cmsRolePurview();
                        rp.RoleId = r;
                        rp.NodeCode = s_vals[i];
                        rp.Type = 1;
                        ls.Add(rp);
                    }

                    r = rps.Add(r, ls);

                    if (action.Equals("add"))
                    {
                        ScriptUtil.ConfirmAndRedirect(@"角色添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "RoleAdd.aspx?node=" + NodeCode, "RoleList.aspx?node=" + NodeCode);
                    }
                    else
                    {
                        ScriptUtil.ConfirmAndRedirect(@"角色修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "RoleAdd.aspx?node=" + NodeCode + "&id=" + id + "&action=" + action, "RoleList.aspx?node=" + NodeCode);
                    }
                }
                //else
                //{
                //    if (action.Equals("add"))
                //    {
                //        ScriptUtil.Alert("服务器发生未知错误！");
                //    }
                //    else
                //    {
                //        ScriptUtil.ConfirmAndRedirect(@"角色修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "", "RoleList.aspx");
                //    }
                //}
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }
    }
}