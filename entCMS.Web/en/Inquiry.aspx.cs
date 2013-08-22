using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Web.en
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

                string firstName = Request["FirstName"];
                string lastName = Request["LastName"];
                string name = firstName + " " + lastName;
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
                    ScriptUtil.Alert("Please enter name.");
                    return;
                }
                if (string.IsNullOrEmpty(email.Trim()))
                {
                    ScriptUtil.Alert("Please enter email.");
                    return;
                }
                if (string.IsNullOrEmpty(title.Trim()))
                {
                    ScriptUtil.Alert("Please enter subject.");
                    return;
                }
                if (string.IsNullOrEmpty(content.Trim()))
                {
                    ScriptUtil.Alert("Please enter content.");
                    return;
                }
                cmsFeedback fb = new cmsFeedback()
                {
                    LangId = CurrentLanguage.Id,
                    ProductId = productId,
                    Name=name,
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

                ScriptUtil.AlertAndExecute("submit ok!", "location.href=location.href;");
            }
        }
    }
}