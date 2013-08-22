using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;
using System.Configuration;

namespace entCMS.Manage
{
    public partial class LanguageSet : BasePage
    {
        long langId = 0;
        string configFile = string.Empty;
        cmsLanguage lang = null;

        public LanguageSet()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["id"]) || !long.TryParse(Request["id"], out langId))
            {
                throw new ArgumentException("参数不正确。");
            }
            lang = LanguageService.GetInstance().GetModel(langId);
            if (lang != null)
            {
                configFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", lang.Code));
            }
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            // tab 0
            txtAddr.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CompanyAddr");
            txtZipCode.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CompanyZipCode");
            txtTel.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CompanyTel");
            txtFax.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CompanyFax");
            txtEmail.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CompanyEmail");
            txtUrl.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CompanyUrl");

            txtHome.Text = ConfigHelper.GetValInSection(configFile, "Resource", "Home");
            txtMore.Text = ConfigHelper.GetValInSection(configFile, "Resource", "More");
            txtCurPos.Text = ConfigHelper.GetValInSection(configFile, "Resource", "CurPos");
            txtNoData.Text = ConfigHelper.GetValInSection(configFile, "Resource", "NoData");
            txtSearchButtonText.Text = ConfigHelper.GetValInSection(configFile, "Resource", "SearchButtonText");
            txtSearchEmptyKeyword.Text = ConfigHelper.GetValInSection(configFile, "Resource", "SearchEmptyKeyword");

            txtAboutUs.Text = ConfigHelper.GetValInSection(configFile, "Resource", "AboutUs");
            txtContactUs.Text = ConfigHelper.GetValInSection(configFile, "Resource", "ContactUs");
            txtLatestNews.Text = ConfigHelper.GetValInSection(configFile, "Resource", "LatestNews");
            txtNewsList.Text = ConfigHelper.GetValInSection(configFile, "Resource", "NewsList");
            txtNewProducts.Text = ConfigHelper.GetValInSection(configFile, "Resource", "NewProducts");
            txtProductList.Text = ConfigHelper.GetValInSection(configFile, "Resource", "ProductList");

            txtDate.Text = ConfigHelper.GetValInSection(configFile, "Resource", "Date");
            txtAuthor.Text = ConfigHelper.GetValInSection(configFile, "Resource", "Author");
            txtHits.Text = ConfigHelper.GetValInSection(configFile, "Resource", "Hits");
            txtSource.Text = ConfigHelper.GetValInSection(configFile, "Resource", "Source");
            
            txtFirstPage.Text = ConfigHelper.GetValInSection(configFile, "Resource", "FirstPage");
            txtPrevPage.Text = ConfigHelper.GetValInSection(configFile, "Resource", "PrevPage");
            txtNextPage.Text = ConfigHelper.GetValInSection(configFile, "Resource", "NextPage");
            txtLastPage.Text = ConfigHelper.GetValInSection(configFile, "Resource", "LastPage");
            txtGoPage.Text = ConfigHelper.GetValInSection(configFile, "Resource", "GoPage");

            // tab 1
            KeyValueConfigurationCollection kvcCollection = ConfigHelper.GetSettingsInSection(configFile, "Resource");
            if (kvcCollection != null)
            {
                string lines = string.Empty;
                foreach (var kv in kvcCollection.AllKeys)
                {
                    if (kv.StartsWith("_"))
                    {
                        lines += kv.TrimStart('_') + "=" + kvcCollection[kv].Value + "\r\n";
                    }
                }
                txtVars.Text = lines;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            string tab = hidTab.Value;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (tab == "0")
            {
                dic.Add("CompanyAddr", txtAddr.Text);
                dic.Add("CompanyZipCode", txtZipCode.Text);
                dic.Add("CompanyTel", txtTel.Text);
                dic.Add("CompanyFax", txtFax.Text);
                dic.Add("CompanyEmail", txtEmail.Text);
                dic.Add("CompanyUrl", txtUrl.Text);

                dic.Add("Home", txtHome.Text);
                dic.Add("More", txtMore.Text);
                dic.Add("CurPos", txtCurPos.Text);
                dic.Add("NoData", txtNoData.Text);
                dic.Add("SearchButtonText", txtSearchButtonText.Text);
                dic.Add("SearchEmptyKeyword", txtSearchEmptyKeyword.Text);

                dic.Add("AboutUs", txtAboutUs.Text);
                dic.Add("ContactUs", txtContactUs.Text);
                dic.Add("LatestNews", txtLatestNews.Text);
                dic.Add("NewsList", txtNewsList.Text);
                dic.Add("NewProducts", txtNewProducts.Text);
                dic.Add("ProductList", txtProductList.Text);

                dic.Add("Date", txtDate.Text);
                dic.Add("Author", txtAuthor.Text);
                dic.Add("Hits", txtHits.Text);
                dic.Add("Source", txtSource.Text);

                dic.Add("FirstPage", txtFirstPage.Text);
                dic.Add("PrevPage", txtPrevPage.Text);
                dic.Add("NextPage", txtNextPage.Text);
                dic.Add("LastPage", txtLastPage.Text);
                dic.Add("GoPage", txtGoPage.Text);
            }
            else if (tab == "1")
            {
                string[] lines = txtVars.Text.Trim().Replace("\n","").Split('\r');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (string.IsNullOrEmpty(lines[i])) continue;
                    if (lines[i].IndexOf('=') > 0)
                    {
                        string[] arr = lines[i].Split('=');
                        string key = "_" + arr[0];
                        string val = arr[1];
                        dic.Add(key, val);
                    }
                }
            }
            ConfigHelper.SetValInSection(configFile, "Resource", dic);

            ScriptUtil.Alert("设置保存成功");
        }
    }
}