using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Manage.Module
{
    public partial class FeedbackShow : BasePage
    {
        cmsFeedback fb = null;

        string id = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];

            if (!IsPostBack)
            {
                fb = FeedbackService.GetInstance().GetModel(id);
                if (fb != null)
                {
                    ltlTitle.Text = fb.Title;
                    ltlContent.Text = fb.Content;
                    ltlName.Text = fb.Name;
                    ltlEmail.Text = fb.Email;
                    ltlPhone.Text = fb.Phone;
                    ltlFax.Text = fb.Fax;
                    ltlCompany.Text = fb.Company;
                    ltlAddress.Text = fb.Address;
                    chkReply.Checked = fb.IsReplied.HasValue && fb.IsReplied == 1 ? true : false;
                    txtReply.Text = fb.ReplyContent;
                }
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            fb = FeedbackService.GetInstance().GetModel(id);
            if (fb != null)
            {
                fb.Attach();

                fb.IsReplied = chkReply.Checked ? 1 : 0;
                fb.ReplyContent = txtReply.Text;
                fb.ReplyTime = DateTime.Now;
                fb.ReplyUser = LoginUser.Id;

                FeedbackService.GetInstance().UpdateModel(fb);

                ScriptUtil.RefreshFrame("MainFrame");
                ScriptUtil.AlertAndCloseDialog("保存成功！");
            }
            else
            {
                ScriptUtil.Alert("信息无效");
            }
        }

    }
}