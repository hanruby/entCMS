using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.Web.cn
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected string WebName = string.Empty;
        protected string WebLogo = string.Empty;
        protected string Keywords = string.Empty;
        protected string Description = string.Empty;
        protected WebPage webPage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page is WebPage)
            {
                webPage = (this.Page as WebPage);
                WebName = webPage.WebName;
                WebLogo = webPage.WebLogo;
                Keywords = webPage.Keywords;
                Description = webPage.Description;
            }
            else
            {
                webPage = new WebPage(1);
            }
            Page.Title = WebName;
            ltlKeyword.Text = "<meta name=\"keywords\" content=\"" + Keywords + "\"/>";
            ltlDescription.Text = "<meta name=\"description\" content=\"" + Description + "\"/>";
        }
    }
}