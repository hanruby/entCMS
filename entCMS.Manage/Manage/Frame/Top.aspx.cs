using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Models;
using entCMS.Services;

namespace entCMS.Manage.Frame
{
    public partial class Top : BasePage
    {
        protected string TrueName = "";

        List<cmsLanguage> langs = null;
        LanguageService lgs = LanguageService.GetInstance();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser != null) TrueName = LoginUser.Name;

            langs = lgs.GetLanguages();

            if (!IsPostBack)
            {
                string title = ConfigHelper.GetVal("SysTitle");
                ltlTitle.Text = !string.IsNullOrEmpty(title) ? title : "企业网站后台管理系统";

                LangBind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LangBind()
        {
            ddlLanguage.DataTextField = "Name";
            ddlLanguage.DataValueField = "Id";
            ddlLanguage.DataSource = langs;
            ddlLanguage.DataBind();
            if (langs.Count == 0)
            {
                ddlLanguage.Items.Insert(0, new ListItem("- 请选择 -", "0"));
            }
            ddlLanguage.SelectedValue = CurrentLanguageId.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            entCMS.Common.ScriptUtil.RegisterStartupScript("gohome();", true);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            CookieHelper.SetCookie("__Language__", ddlLanguage.SelectedValue);
        }
    }
}