using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Web.cn
{
    public partial class ImageShow : WebPage
    {
        private string id = "";
        cmsNews news = null;

        protected string title = string.Empty;
        protected string content = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            news = NewsService.GetInstance().GetModel(id);
            if (news != null)
            {
                NodeCode = news.NodeCode;
                title = news.Title;
                content = news.Content;
            }
        }
    }
}