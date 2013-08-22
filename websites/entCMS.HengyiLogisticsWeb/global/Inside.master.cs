using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using entCMS.Models;

namespace entCMS.HengyiLogisticsWeb.global
{
    public partial class Inside : System.Web.UI.MasterPage
    {
        private WebPage webPage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webPage = this.Page as WebPage;

            if (!IsPostBack)
            {
                ltlMenu.Text = webPage.SideMenus;
            }
        }

    }
}