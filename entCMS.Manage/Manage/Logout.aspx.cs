using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.Manage
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthenticationService.SignOut();

            string act = Request.QueryString["act"];
            if (!string.IsNullOrEmpty(act) && act.Equals("1"))
            {
                lblMsg.Text = "您已安全退出本系统！";
            }

            // Get the last error from the server
            Exception ex = Server.GetLastError();

            if (ex != null)
            {
                // Log the exception and notify system operators
                ExceptionUtility.LogException("Generic Error Page", ex);
                ExceptionUtility.NotifySystemOps(ex);

                // Clear the error from the server
                Server.ClearError();
            }
        }
    }
}