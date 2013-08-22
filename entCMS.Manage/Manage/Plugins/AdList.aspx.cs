using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Manage.Plugins
{
    public partial class AdList : BasePage
    {
        AdService ds = AdService.GetInstance();

        public AdList()
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
            int recordCount = 0;
            List<cmsAd> ls = ds.GetList(null, cmsAd._.OrderNo.Asc, pager.CurrentPageIndex, pager.PageSize, ref recordCount);

            // 绑定数据到GridView
            base.BindGrid<cmsAd>(recordCount, ls);
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void pager_PageChanged(object src, EventArgs e)
        {
            BindGrid();
        }

        protected string getType(object dataItem)
        {
            string[] types = { "飘窗", "对联", "左上角", "右上角", "左下角", "右下角" };
            if (dataItem != null)
            {
                cmsAd ad = dataItem as cmsAd;

                return types[ad.Type.Value];
            }
            return "";
        }
    }
}