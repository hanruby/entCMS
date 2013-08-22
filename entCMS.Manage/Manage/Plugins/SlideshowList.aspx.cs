using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage.Plugins
{
    public partial class SlideshowList : BasePage
    {
        SlideshowService ss = SlideshowService.GetInstance();

        public SlideshowList()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始化分页控件和数据绑定控件
            base.InitializePageControls(null, gv);
            
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<cmsSlideshow> ls = ss.GetListByLangId(CurrentLanguageId, null);
            // 绑定数据到GridView
            base.BindGrid<cmsSlideshow>( ls);
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