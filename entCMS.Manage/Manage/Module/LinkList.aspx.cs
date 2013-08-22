using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using System.Data;
using Hxj.Data;


namespace entCMS.Manage.Module
{
    public partial class LinkList : BasePage
    {
        LinkService ls = LinkService.GetInstance();

        public LinkList()
            : base(PagePurviewType.PPT_NEWS)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始化分页控件和数据绑定控件
            base.InitializePageControls(pager, gv);

            if (!IsPostBack)
            {
                ddlType.DataTextField = "Name";
                ddlType.DataValueField = "Id";
                ddlType.DataSource = LinkGroupService.GetInstance().GetList(CurrentLanguageId, 1);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("默认", "0"));
                ddlType.Items.Insert(0, new ListItem("--请选择--", "-1"));

                BindGrid();
            }
        }

        private void BindGrid()
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsLink._.LangId == CurrentLanguageId);
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                wcb.And(cmsLink._.Name.Contain(txtName.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(txtUrl.Text.Trim()))
            {
                wcb.And(cmsLink._.Url.Contain(txtUrl.Text.Trim()));
            }
            if (ddlType.SelectedIndex > 0)
            {
                wcb.And(cmsLink._.GroupId == Convert.ToInt64(ddlType.SelectedValue));
            }
            int recordCount = 0;
            DataTable dt = ls.GetDataTable(wcb.ToWhereClip(), pager.CurrentPageIndex, pager.PageSize, ref recordCount);

            // 绑定数据到GridView
            base.BindGrid(recordCount, dt);
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void pager_PageChanged(object src, EventArgs e)
        {
            BindGrid();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtUrl.Text = "";
            ddlType.SelectedValue = "0";

            BindGrid();
        }
    }
}