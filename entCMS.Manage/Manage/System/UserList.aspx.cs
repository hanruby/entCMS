using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Manage
{
    public partial class UserList : BasePage
    {
        UserService us = UserService.GetInstance();
        RoleService rs = RoleService.GetInstance();

        int roleId = 0;

        public UserList()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            roleId = Convert.ToInt32(Request["roleId"]);

            // 初始化分页控件和数据绑定控件
            base.InitializePageControls(pager, gv);

            if (!IsPostBack)
            {
                RoleBind();

                BindGrid();
            }
        }

        private void RoleBind()
        {
            List<cmsRole> ls = rs.GetRoles();

            ddlRole.DataValueField = "Id";
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataSource = ls;
            ddlRole.DataBind();

            ddlRole.Items.Insert(0, new ListItem("- 请选择 -", "0"));

            ddlRole.SelectedValue = roleId.ToString();
        }

        private void BindGrid()
        {
            int recordCount = 0;
            List<cmsUser> ls = us.GetUsersByFilter(
                txtLogin.Text, 
                txtName.Text, 
                txtDept.Text,
                Convert.ToInt32(ddlRole.SelectedValue),
                pager.CurrentPageIndex, 
                pager.PageSize, 
                ref recordCount);

            // 绑定数据到GridView
            base.BindGrid<cmsUser>(recordCount, ls);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtName.Text = "";
            txtDept.Text = "";
            ddlRole.SelectedIndex = 0;
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void pager_PageChanged(object src, EventArgs e)
        {
            BindGrid();
        }
    }
}