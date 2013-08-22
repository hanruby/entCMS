using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using System.Data;

namespace entCMS.Manage
{
    public partial class CompanyList : BasePage
    {
        CompanyService cs = CompanyService.GetInstance();

        public CompanyList()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.InitializePageControls(null, gv);

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = cs.GetDataTableWithLang();

            // 绑定数据到GridView
            base.BindGrid(dt);
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}