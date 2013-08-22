using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage.Module
{
    public partial class JobList : BasePage
    {
        JobService js = JobService.GetInstance();

        public JobList() : base(PagePurviewType.PPT_NEWS) { }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始化分页控件和数据绑定控件
            base.InitializePageControls(pager, gv);

            if (!IsPostBack)
            {
                InitControls();

                BindGrid();
            }
        }

        private void InitControls()
        {
            lblPosition.Text = NewsCatalogService.GetInstance().GetNavStr(NodeCode, " >> ");
        }

        private void BindGrid()
        {
            int count = 0;

            var data = js.GetValidList(CurrentLanguageId, pager.CurrentPageIndex, pager.PageSize, ref count);

            BindGrid<cmsJob>(count, data);
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
        }
    }
}