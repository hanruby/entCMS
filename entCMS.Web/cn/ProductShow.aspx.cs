using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Web.cn
{
    public partial class ProductShow : WebPage
    {
        private string id = "";
        protected cmsNews news = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            news = NewsService.GetInstance().GetModel(id);
            if (news != null)
            {
                NodeCode = news.NodeCode;
            }
            else
            {
                news = new cmsNews();
            }
        }
    }
}