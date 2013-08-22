using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;


namespace entCMS.Manage
{
    public partial class LanguageList : BasePage
    {
        LanguageService lgs = LanguageService.GetInstance();

        public LanguageList()
            : base(PagePurviewType.PPT_SYSTEM)
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
            int recordCount = 0;
            List<cmsLanguage> ls = lgs.GetList(pager.CurrentPageIndex, pager.PageSize, ref recordCount);

            // 绑定数据到GridView
            base.BindGrid<cmsLanguage>(recordCount, ls);
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