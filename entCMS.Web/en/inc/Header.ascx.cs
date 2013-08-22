using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;

namespace entCMS.Web.en.inc
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected WebPage webpage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webpage = (WebPage)(this.Page);
        }
    }
}