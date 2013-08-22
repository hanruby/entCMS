using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class EditPwd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //(Master as MasterPage).ShowTitleBar(false);
            (Master as MasterPage).ShowPositionBar(false);
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            string pwd = Md5.Get32Md5(LoginUser.UName + txtOldPwd.Text);
            if (pwd != LoginUser.UPwd)
            {
                rfvOldPwd.ErrorMessage = "原始密码 不正确";
                rfvOldPwd.IsValid = false;
                return;
            }
            else
            {
                rfvOldPwd.ErrorMessage = "原始密码 不能为空";
            }
        }
    }
}