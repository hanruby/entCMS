using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.HengyiLogisticsWeb.cn
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected WebPage webPage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page is WebPage)
            {
                webPage = (this.Page as WebPage);
            }
            else
            {
                webPage = new WebPage(1);
            }
            Page.Title = webPage.WebName;
            ltlKeyword.Text = "<meta name=\"keywords\" content=\"" + webPage.Keywords + "\"/>";
            ltlDescription.Text = "<meta name=\"description\" content=\"" + webPage.Description + "\"/>";
        }
    }
}