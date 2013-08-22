using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Web.cn
{
    public partial class Page : WebPage
    {
        protected string HtmlContent = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            cmsNews news = NewsService.GetInstance().GetModel(cmsNews._.NodeCode == NodeCode, cmsNews._.EditTime.Desc);
            if (news != null)
            {
                HtmlContent = news.Content;
            }
        }
    }
}