using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage
{
    public partial class UserAdd : BasePage
    {
        MenuService ms = MenuService.GetInstance();
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        UserService rs = UserService.GetInstance();
        cmsUser user = null;

        string id = "";
        string action = "";

        public UserAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            user = rs.GetModel(id);
            if (user != null)
            {
                hidID.Value = user.Id.ToString();
                txtUser.Text = user.UName;
                txtUser.Attributes.Add("readonly", "true");
                txtName.Text = user.Name;
                txtDept.Text = user.DeptName;
                hidPwd.Value = "********";
                chkEnabled.Checked = user.IsEnabled.HasValue ? user.IsEnabled == 1 : false;
            }
        }


        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                hidPwd.Value = txtPwd.Text.Trim();
            }


            if (action.Equals("add"))
            {
                if (rs.CheckUser(txtUser.Text.Trim()))
                {
                    ScriptUtil.Alert("用户名[" + txtUser.Text.Trim() + "]不允许重复使用！");
                    return;
                }
                user = new cmsUser();
                user.CreateTime = DateTime.Now;
                user.LoginCount = 0;
            }
            else
            {
                user = rs.GetModel(id);
                if (user != null)
                {
                    user.Attach();
                }
            }

            user.UName = txtUser.Text.Trim();
            user.Name = txtName.Text.Trim();
            user.DeptId = 0;
            user.DeptName = txtDept.Text.Trim();
            user.UserType = 0;
            user.IsEnabled = chkEnabled.Checked ? 1 : 0;
            if (!string.IsNullOrEmpty(hidPwd.Value) && !hidPwd.Value.Equals("********"))
            {
                user.UPwd = Md5.Get32Md5(user.UName + txtPwd.Text.Trim(), true);
            }

            try
            {
                long r = rs.SaveModel(user);
                if (action.Equals("edit"))
                {
                    r = user.Id;
                }
                if (r > 0)
                {
                    hidID.Value = r.ToString();

                    if (action.Equals("add"))
                    {
                        ScriptUtil.ConfirmAndRedirect(@"用户添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "UserAdd.aspx?node=" + NodeCode, "UserList.aspx?node=" + NodeCode);
                    }
                    else
                    {
                        ScriptUtil.ConfirmAndRedirect(@"用户修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "UserAdd.aspx?node=" + NodeCode + "&id=" + id + "&action=" + action, "UserList.aspx?node=" + NodeCode);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }
    }
}