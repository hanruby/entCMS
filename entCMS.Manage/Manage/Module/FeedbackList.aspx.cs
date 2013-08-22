using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hxj.Data;
using entCMS.Models;
using entCMS.Services;
using System.Data;

namespace entCMS.Manage.Module
{
    public partial class FeedbackList : BasePage
    {
        public FeedbackList()
            : base(PagePurviewType.PPT_NEWS)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始化分页控件和数据绑定控件
            base.InitializePageControls(pager, gv);

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsFeedback._.LangId == CurrentLanguageId);
            if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                wcb.And(cmsFeedback._.Title.Contain(txtTitle.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                wcb.And(cmsFeedback._.Name.Contain(txtName.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                wcb.And(cmsFeedback._.Name.Contain(txtName.Text.Trim()));
            }
            if (ddlReply.SelectedIndex > 0)
            {
                wcb.And(cmsFeedback._.IsReplied == Convert.ToInt32(ddlReply.SelectedValue));
            }
            int recordCount = 0;
            List<cmsFeedback> ls = FeedbackService.GetInstance().GetList(wcb.ToWhereClip(), cmsFeedback._.PostTime.Desc, pager.CurrentPageIndex, pager.PageSize, ref recordCount);

            // 绑定数据到GridView
            base.BindGrid<cmsFeedback>(recordCount, ls);
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
            txtTitle.Text = "";
            txtName.Text = "";
            txtTitle.Text = "";
            ddlReply.SelectedValue = "0";

            BindGrid();
        }
    }
}