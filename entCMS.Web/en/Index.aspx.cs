using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.Web.en
{
    public partial class Index : WebPage
    {
        protected string onlineType = "0";
        protected string onlineX = "0";
        protected string onlineY = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            onlineType = GetConfigVal("OnlineType");
            onlineX = GetConfigVal("OnlineX");
            onlineY = GetConfigVal("OnlineY");
        }
    }
}