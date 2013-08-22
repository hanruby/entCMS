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
    public partial class UserRole : BasePage
    {
        UserRoleService urs = UserRoleService.GetInstance();
        RoleService rs = RoleService.GetInstance();
        UserService us = UserService.GetInstance();

        string id = "";

        public UserRole()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];

            if (!IsPostBack)
            {
                BindRoles();

                InitData();
            }
        }

        private void BindRoles()
        {
            List<cmsRole> ls = rs.GetRoles();

            cblRoles.DataTextField = "RoleName";
            cblRoles.DataValueField = "Id";
            cblRoles.DataSource = ls;
            cblRoles.DataBind();
        }

        private void InitData()
        {
            //SysUser u = us.Get2(id);
            cmsUser u = us.GetModel(id);

            if (u != null)
            {
                //lblUser.Text = u.cLoginName + " / " + u.cUserName;
                lblUser.Text = u.UName + " / " + u.Name;

                //List<cmsUserRole> ls = urs.GetRolesById(u.iId);
                List<cmsUserRole> ls = urs.GetRolesByUserId(u.Id);

                foreach (ListItem item in cblRoles.Items)
                {
                    if (ls.Exists(delegate(cmsUserRole ur){ return ur.RoleId == Convert.ToInt64(item.Value);}))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            List<cmsUserRole> ls = new List<cmsUserRole>();

            foreach (ListItem item in cblRoles.Items)
            {
                if (item.Selected)
                {
                    cmsUserRole ur = new cmsUserRole();
                    ur.UserId = Convert.ToInt64(id);
                    ur.RoleId = Convert.ToInt64(item.Value);

                    ls.Add(ur);
                }
            }

            int r = 0;
            try
            {
                r = urs.Add(Convert.ToInt64(id), ls);

                ScriptUtil.AlertAndCloseDialog("角色分配成功！");
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert("服务器发生未知错误！");

                Logger.Error(ex.Message);
            }
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool b = chkAll.Checked;

            foreach (ListItem chk in cblRoles.Items)
            {
                chk.Selected = b;
            }
        }
    }
}