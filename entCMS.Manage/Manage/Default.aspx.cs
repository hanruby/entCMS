using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string configFile = Server.MapPath("~/manage/config/zh-cn.config");
            //string webname = ConfigHelper.GetVal(configFile, "WebName");
            //ConfigHelper.SetVal(configFile, "WebName", "测试网站");
            //this.Title = webname;
        }
    }
}