using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class ImageSet : BasePage
    {
        string configFile = string.Empty;
        cmsLanguage lang = null;

        public ImageSet()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = LanguageService.GetInstance().GetModel(CurrentLanguageId);
            if (lang != null)
            {
                configFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", lang.Code));
            }
            if (!IsPostBack && lang != null)
            {
                InitData();
            }
        }

        private void InitData()
        {
            // tab 0
            chkAutoDelImg.Checked = ConfigHelper.GetVal(configFile, "AutoDelImg")=="1";
            chkAutoRename.Checked = ConfigHelper.GetVal(configFile, "AutoRename") == "1";
            chkAutoCreateThumbnail.Checked = ConfigHelper.GetVal(configFile, "AutoCreateThumbnail") == "1";
            rblCreateThumbnailMode.SelectedValue = ConfigHelper.GetVal(configFile, "CreateThumbnailMode");
            txtProductThumbnailWidth.Text = ConfigHelper.GetVal(configFile, "ProductThumbnailWidth");
            txtProductThumbnailHeight.Text = ConfigHelper.GetVal(configFile, "ProductThumbnailHeight");
            txtNewsThumbnailWidth.Text = ConfigHelper.GetVal(configFile, "NewsThumbnailWidth");
            txtNewsThumbnailHeight.Text = ConfigHelper.GetVal(configFile, "NewsThumbnailHeight");
            txtImageThumbnailWidth.Text = ConfigHelper.GetVal(configFile, "ImageThumbnailWidth");
            txtImageThumbnailHeight.Text = ConfigHelper.GetVal(configFile, "ImageThumbnailHeight");
            // tab 1
            string v = ConfigHelper.GetVal(configFile, "AddWaterMark");
            if (!string.IsNullOrEmpty(v))
            {
                foreach (ListItem item in cblAddWaterMark.Items)
                {
                    if (v.Contains("|" + item.Value + "|")) item.Selected = true;
                }
            }
            rblWaterMarkType.SelectedValue = ConfigHelper.GetVal(configFile, "WaterMarkType");
            hidImages1.Value = ConfigHelper.GetVal(configFile, "WaterMarkImg");
            hidImages2.Value = ConfigHelper.GetVal(configFile, "ThumbnailWaterMarkImg");
            txtWaterMarkTextFontSize.Text = ConfigHelper.GetVal(configFile, "WaterMarkTextFontSize");
            txtThumbnailWaterMarkTextFontSize.Text = ConfigHelper.GetVal(configFile, "ThumbnailWaterMarkTextFontSize");
            txtWaterMarkTextFont.Text = ConfigHelper.GetVal(configFile, "WaterMarkTextFont");
            txtWaterMarkText.Text = ConfigHelper.GetVal(configFile, "WaterMarkText");
            txtWaterMarkTextColor.Text = ConfigHelper.GetVal(configFile, "WaterMarkTextColor");
            txtWaterMarkAngle.Text = ConfigHelper.GetVal(configFile, "WaterMarkAngle");
            txtWaterMarkAlpha.Text = ConfigHelper.GetVal(configFile, "WaterMarkAlpha");
            rblWaterMarkPosition.SelectedValue = ConfigHelper.GetVal(configFile, "WaterMarkPosition");

        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            string tab = hidTab.Value;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (tab == "0")
            {
                dic.Add("AutoDelImg", chkAutoDelImg.Checked ? "1" : "0");
                dic.Add("AutoRename", chkAutoRename.Checked ? "1" : "0");
                dic.Add("AutoCreateThumbnail", chkAutoCreateThumbnail.Checked ? "1" : "0");
                dic.Add("CreateThumbnailMode", rblCreateThumbnailMode.SelectedValue);
                dic.Add("ProductThumbnailWidth", txtProductThumbnailWidth.Text);
                dic.Add("ProductThumbnailHeight", txtProductThumbnailHeight.Text);
                dic.Add("NewsThumbnailWidth", txtNewsThumbnailWidth.Text);
                dic.Add("NewsThumbnailHeight", txtNewsThumbnailHeight.Text);
                dic.Add("ImageThumbnailWidth", txtImageThumbnailWidth.Text);
                dic.Add("ImageThumbnailHeight", txtImageThumbnailHeight.Text);
            }
            else if (tab == "1")
            {
                string v = "";
                foreach (ListItem item in cblAddWaterMark.Items)
                {
                    if (item.Selected) v += "|" + item.Value + "|";
                }
                dic.Add("AddWaterMark", v);
                dic.Add("WaterMarkType", rblWaterMarkType.SelectedValue);
                dic.Add("WaterMarkImg", hidImages1.Value);
                dic.Add("ThumbnailWaterMarkImg", hidImages2.Value);
                dic.Add("WaterMarkTextFontSize", txtWaterMarkTextFontSize.Text);
                dic.Add("ThumbnailWaterMarkTextFontSize", txtThumbnailWaterMarkTextFontSize.Text);
                dic.Add("WaterMarkTextFont", txtWaterMarkTextFont.Text);
                dic.Add("WaterMarkText", txtWaterMarkText.Text);
                dic.Add("WaterMarkTextColor", txtWaterMarkTextColor.Text);
                dic.Add("WaterMarkAngle", txtWaterMarkAngle.Text);
                dic.Add("WaterMarkAlpha", txtWaterMarkAlpha.Text);
                dic.Add("WaterMarkPosition", rblWaterMarkPosition.SelectedValue);
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