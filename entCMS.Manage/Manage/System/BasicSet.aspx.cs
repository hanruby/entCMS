using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Manage
{
    public partial class BasicSet : BasePage
    {
        string configFile = string.Empty;
        cmsLanguage lang = null;

        public BasicSet()
            : base(PagePurviewType.PPT_SYSTEM)
        {
            lang = LanguageService.GetInstance().GetModel(CurrentLanguageId);
            if (lang != null)
            {
                configFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", lang.Code));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && lang!=null)
            {
                InitData();
            }
        }

        private void InitData()
        {
            // tab 0
            txtWebName.Text = ConfigHelper.GetVal(configFile, "WebName");
            hidLogo.Value = ConfigHelper.GetVal(configFile, "WebLogo");
            txtWebUrl.Text = ConfigHelper.GetVal(configFile, "WebUrl");
            if (string.IsNullOrEmpty(txtWebUrl.Text)) txtWebUrl.Text = GetAppPath();
            txtKeywords.Text = ConfigHelper.GetVal(configFile, "Keywords");
            txtDescription.Text = ConfigHelper.GetVal(configFile, "Description");
            chkUrlRewrite.Checked = ConfigHelper.GetVal<bool>(configFile, "UrlRewrite");
            txtFootInfo.Text = ConfigHelper.GetVal(configFile, "FootInfo");
            txtThirdCode.Text = ConfigHelper.GetVal(configFile, "ThirdCode");
            // tab 1
            txtSender.Text = ConfigHelper.GetVal(configFile, "Sender");
            txtEmail.Text = ConfigHelper.GetVal(configFile, "Email");
            txtPassword.Text = ConfigHelper.GetVal(configFile, "Password");
            txtSMTP.Text = ConfigHelper.GetVal(configFile, "SMTP");

        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            string tab = hidTab.Value;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (tab == "0")
            {
                dic.Add("WebName", txtWebName.Text);
                dic.Add("WebLogo", hidLogo.Value);
                dic.Add("WebUrl", txtWebUrl.Text);
                dic.Add("Keywords", txtKeywords.Text);
                dic.Add("Description", txtDescription.Text);
                dic.Add("FootInfo", txtFootInfo.Text);
                dic.Add("ThirdCode", txtThirdCode.Text);
                dic.Add("UrlRewrite", chkUrlRewrite.Checked ? "true" : "false");
            }
            else if (tab == "1")
            {
                dic.Add("Sender", txtSender.Text);
                dic.Add("Email", txtEmail.Text);
                dic.Add("Password", txtPassword.Text);
                dic.Add("SMTP", txtSMTP.Text);
            }

            ConfigHelper.SetVal(configFile, dic);
            ScriptUtil.Alert("设置保存成功");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (lang == null)
            {
                (Master as MasterPage).SetPageInfo(GetPageInfo("当前语言未指定", "请在左边栏里选择当前语言。如果还未设置站点语言，请点击 <a href='LanguageList.aspx'>[语言设置]</a>"));
            }
        }
    }
}