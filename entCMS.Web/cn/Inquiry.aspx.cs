using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Web.cn
{
    public partial class Inquiry : WebPage
    {
        string pid = string.Empty;
        protected cmsNews news = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            pid = Request["pid"];
            news = NewsService.GetInstance().GetModel(pid);
            if (news != null)
            {
                NodeCode = news.NodeCode;
            }
            else
            {
                news = new cmsNews();
            }

            if (IsPostBack)
            {
                pid = Request["pid"];
                long productId = 0;
                if (!long.TryParse(pid, out productId)) productId = 0;

                string name = Request["Name"];
                string company = Request["Company"];
                string address = Request["Address"];
                string zipcode = Request["Zipcode"];
                string email = Request["Email"];
                string phone = Request["Phone"];
                string fax = Request["Fax"];
                string title = Request["Title"];
                string content = Request["Content"];

                if (string.IsNullOrEmpty(name.Trim()))
                {
                    ScriptUtil.Alert("请输入姓名。");
                    return;
                }
                if (string.IsNullOrEmpty(email.Trim()))
                {
                    ScriptUtil.Alert("请输入电子邮箱。");
                    return;
                }
                if (string.IsNullOrEmpty(title.Trim()))
                {
                    ScriptUtil.Alert("请输入标题。");
                    return;
                }
                if (string.IsNullOrEmpty(content.Trim()))
                {
                    ScriptUtil.Alert("请输入内容。");
                    return;
                }
                cmsFeedback fb = new cmsFeedback()
                {
                    LangId = CurrentLanguage.Id,
                    ProductId = productId,
                    Name = name,
                    Company = company,
                    Address = address,
                    Phone = phone,
                    Fax = fax,
                    Email = email,
                    Title = title,
                    Content = content,
                    PostTime = DateTime.Now,
                    IsReplied = 0,
                };
                FeedbackService.GetInstance().AddModel(fb);

                ScriptUtil.AlertAndExecute("提交成功！", "location.href=location.href;");
            }
        }
    }
}