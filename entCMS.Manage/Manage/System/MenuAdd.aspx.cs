using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class MenuAdd : BasePage
    {
        MenuService ms = MenuService.GetInstance();
        cmsMenu menu = null;

        string code = "";
        string action = "";

        public MenuAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            code = Request["code"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            if (!IsPostBack)
            {
                DDLBind();

                InitData();
            }
        }

        private void DDLBind()
        {
            ddlParentNode.Items.Add(new ListItem("顶级菜单", "0000"));

            List<cmsMenu> menus = ms.GetList(cmsMenu._.IsEnabled == true, cmsMenu._.OrderNo.Asc);

            buildMenuTree(ddlParentNode, menus, "0000", "");
        }

        private void InitData()
        {
            if (!string.IsNullOrEmpty(code))
            {
                if (action.Equals("add"))
                {
                    ddlParentNode.SelectedValue = code;
                }
                else if (action.Equals("edit"))
                {
                    menu = ms.Get(code);
                    if (menu != null)
                    {
                        hidCode.Value = menu.MenuCode;
                        ddlParentNode.SelectedValue = menu.ParentCode;
                        txtName.Text = menu.MenuName;
                        ddlType.SelectedIndex = menu.MenuType.Value;
                        txtUrl.Text = menu.MenuUrl;
                        txtOrder.Text = menu.OrderNo.ToString();
                        chkEnabled.Checked = menu.IsEnabled.HasValue ? menu.IsEnabled.Value == 1 : false;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="menus"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildMenuTree(DropDownList ddl, List<cmsMenu> menus, string parentCode, string prefix)
        {
            string pf = "";
            List<cmsMenu> childs = menus.FindAll(delegate(cmsMenu m) { return m.ParentCode == parentCode; });
            for (int i = 0; i < childs.Count; i++)
            {
                cmsMenu item = childs[i];

                ListItem itm = new ListItem();
                itm.Value = item.MenuCode;
                if (i < childs.Count - 1)
                {
                    itm.Text = prefix + "├" + item.MenuName;
                    pf = prefix + "│";
                }
                else
                {
                    itm.Text = prefix + "└" + item.MenuName;
                    pf = prefix + "　"; // 全角空格[　]制表符[│][├][└]
                }
                ddl.Items.Add(itm);

                buildMenuTree(ddl, menus, item.MenuCode, pf);
            }
        }


        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";
            
            if (action.Equals("add"))
            {
                menu = new cmsMenu();
            }
            else if(action.Equals("edit"))
            {
                if (ddlParentNode.SelectedValue.StartsWith(hidCode.Value))
                {
                    ScriptUtil.Alert("上级菜单不能设为自身或其子级！");
                    return;
                }
                menu = ms.Get(code);
                if (menu != null)
                {
                    menu.Attach();
                }
                else
                {
                    menu = new cmsMenu();
                }
            }
            if (menu.ParentCode != ddlParentNode.SelectedValue)
            {
                menu.MenuCode = ms.GetNextChildCode(ddlParentNode.SelectedValue);
            }
            menu.ParentCode = ddlParentNode.SelectedValue;
            menu.MenuName = txtName.Text.Trim();
            menu.MenuUrl = txtUrl.Text.Trim();
            menu.MenuType = ddlType.SelectedIndex;
            menu.OrderNo = Convert.ToInt32(txtOrder.Text.Trim());
            menu.IsEnabled = chkEnabled.Checked ? 1 : 0;

            try
            {
                int r = ms.Save(menu);
                //if (r > 0)
                {
                    hidCode.Value = menu.MenuCode;

                    if (action.Equals("add"))
                    {
                        ScriptUtil.ConfirmAndRedirect(@"菜单添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "MenuAdd.aspx?node=" + NodeCode, "MenuList.aspx?node=" + NodeCode);
                    }
                    else
                    {
                        ScriptUtil.ConfirmAndRedirect(@"菜单修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "MenuAdd.aspx?node=" + NodeCode + "&code=" + code + "&action=" + action, "MenuList.aspx?node=" + NodeCode);
                        //ScriptUtil.Alert("菜单修改成功！");
                    }
                }
            }
            catch(Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }

    }
}