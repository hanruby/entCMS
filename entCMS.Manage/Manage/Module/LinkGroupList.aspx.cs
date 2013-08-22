using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Manage.Module
{
    public partial class LinkGroupList : BasePage
    {
        LinkGroupService lts = LinkGroupService.GetInstance();

        public LinkGroupList()
            : base(PagePurviewType.PPT_NEWS)
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
            List<cmsLinkGroup> ls = lts.GetList(CurrentLanguageId, 1);

            // 绑定数据到GridView
            base.BindGrid<cmsLinkGroup>(ls);
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void pager_PageChanged(object src, EventArgs e)
        {
            BindGrid();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (CurrentLanguageId == 0)
            {
                (Master as MasterPage).SetPageInfo(GetPageInfo("当前语言未指定", "请在左边栏里选择当前语言。如果还未设置站点语言，请点击 <a href='LanguageList.aspx'>[语言设置]</a>"));
            }
        }
    }
}