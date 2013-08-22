using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.Web.cn
{
    public partial class NestedSite : System.Web.UI.MasterPage
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
        }
    }
}