using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateValidateCode();
        }

        #region 验证码
        public void CreateValidateCode()
        {
            ValidateCoder vc = new ValidateCoder();
            string code = vc.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = vc.CreateValidateGraphic(code);

            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        #endregion
    }
}