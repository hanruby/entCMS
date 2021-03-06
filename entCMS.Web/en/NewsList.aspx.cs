﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace entCMS.Web.en
{
    public partial class NewsList : WebPage
    {
        protected DataTable newsDataTable = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (IsUrlRewrite)
                {
                    pager.EnableUrlRewriting = true;
                    pager.UrlRewritePattern = "ProductList/" + Node.NodeCode + "_{0}";
                }
                BindGrid();
            }
        }

        private void BindGrid()
        {
            int count = 0;
            newsDataTable = GetNews(NodeCode, true, pager.CurrentPageIndex, pager.PageSize, ref count);
            pager.RecordCount = count;
        }

        protected void pager_PageChanged(object src, EventArgs e)
        {
            BindGrid();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }
    }
}