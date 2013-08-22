using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = (Exception)Application["error"];

            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    ltlMsg.Text = ex.InnerException.Message;
                    ltlStackTrace.Text = ex.InnerException.StackTrace;
                }
                else
                {
                    ltlMsg.Text = ex.Message;
                    ltlStackTrace.Text = ex.StackTrace;
                }
            }
        }
    }
}