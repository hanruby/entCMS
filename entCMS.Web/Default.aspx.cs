using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.Web
{
    public partial class Default : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(CurrentLanguage.HomeUrl, false);
        }
    }
}