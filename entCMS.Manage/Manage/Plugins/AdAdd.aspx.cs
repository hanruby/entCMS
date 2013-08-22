using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;
using System.Configuration;

namespace entCMS.Manage.Plugins
{
    public partial class AdAdd : BasePage
    {
        AdService ds = AdService.GetInstance();
        cmsAd ad = null;

        string id = "";
        string action = "";
        public AdAdd()
            : base(PagePurviewType.PPT_NEWS)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            if (!IsPostBack)
            {
                InitControls();

                InitData();
            }
        }


        private void InitControls()
        {
        }

        private void InitData()
        {
            ad = ds.GetModel(id);
            if (null != ad)
            {
                ddlType.SelectedValue = ad.Type.ToString();
                txtTitle.Text = ad.Title;
                string[] pics = ad.Pics.Split('|');
                txtPic1.Text = (pics.Length > 0) ? pics[0] : "";
                txtPic2.Text = (pics.Length > 1) ? pics[1] : "";
                string[] urls = ad.Urls.Split('|');
                txtUrl1.Text = (urls.Length > 0) ? urls[0] : "";
                txtUrl2.Text = (urls.Length > 1) ? urls[1] : "";
                txtMemo.Text = ad.Remark;
                chkEnabled.Enabled = (ad.IsEnabled.Value == 1) ? true : false;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (action.Equals("add"))
            {
                ad = new cmsAd();
            }
            else
            {
                ad = ds.GetModel(id);
                if (ad != null)
                {
                    ad.Attach();
                }
                else
                {
                    ad = new cmsAd();
                }
            }
            ad.Type = Convert.ToInt32(ddlType.SelectedValue);
            ad.Title = txtTitle.Text.Trim();

            if (hidPicType1.Value.Equals("1"))
            {
                string imgUrl = ""; int maxSize = 5; //5M
                string fileMaxSize = ConfigurationManager.AppSettings["FileMaxSize"];
                if (!string.IsNullOrEmpty(fileMaxSize))
                    maxSize = Convert.ToInt32(fileMaxSize);
                ImageHelper imgHelper = new ImageHelper();
                ImageHelper.UploadStatus status = imgHelper.UploadImage(fuPic1.PostedFile, maxSize, 0, 0, ImageHelper.CreateThumbnailMode.CTM_CUT, ref imgUrl);
                switch (status)
                {
                    case ImageHelper.UploadStatus.US_NOT_FOUND:
                        break;
                    case ImageHelper.UploadStatus.US_TOO_LONG:
                        ScriptUtil.Alert("上传文件大小超过限制。");
                        return;
                    case ImageHelper.UploadStatus.US_NOT_SUPPORT:
                        ScriptUtil.Alert("上传文件扩展名是不允许的扩展名。\n只允许gif,jpg,jpeg,png,bmp格式。");
                        return;
                    case ImageHelper.UploadStatus.US_FAILED:
                        ScriptUtil.Alert("上传文件时服务器发生错误。");
                        return;
                    case ImageHelper.UploadStatus.US_SUCCESSED:
                        break;
                }

                txtPic1.Text = imgUrl;
            }
            if (hidPicType2.Value.Equals("1"))
            {
                string imgUrl = "";
                int maxSize = 5; //5M
                string fileMaxSize = ConfigurationManager.AppSettings["FileMaxSize"];
                if (!string.IsNullOrEmpty(fileMaxSize))
                    maxSize = Convert.ToInt32(fileMaxSize);
                ImageHelper imgHelper = new ImageHelper();
                ImageHelper.UploadStatus status = imgHelper.UploadImage(fuPic2.PostedFile, maxSize, 0, 0, ImageHelper.CreateThumbnailMode.CTM_CUT, ref imgUrl);
                switch (status)
                {
                    case ImageHelper.UploadStatus.US_NOT_FOUND:
                        break;
                    case ImageHelper.UploadStatus.US_TOO_LONG:
                        ScriptUtil.Alert("上传文件大小超过限制。");
                        return;
                    case ImageHelper.UploadStatus.US_NOT_SUPPORT:
                        ScriptUtil.Alert("上传文件扩展名是不允许的扩展名。\n只允许gif,jpg,jpeg,png,bmp格式。");
                        return;
                    case ImageHelper.UploadStatus.US_FAILED:
                        ScriptUtil.Alert("上传文件时服务器发生错误。");
                        return;
                    case ImageHelper.UploadStatus.US_SUCCESSED:
                        break;
                }

                txtPic2.Text = imgUrl;
            }
            ad.Pics = txtPic1.Text + "|" + txtPic2.Text;
            ad.Urls = txtUrl1.Text + "|" + txtUrl2.Text;
            ad.Remark = txtMemo.Text;
            ad.IsEnabled = chkEnabled.Checked ? 1 : 0;
            try
            {
                int r = ds.SaveModel(ad);

                if (action.Equals("add"))
                {
                    ScriptUtil.ConfirmAndRedirect(@"广告添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "AdAdd.aspx?node=" + NodeCode, "AdList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"广告修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "", "AdList.aspx?node=" + NodeCode);
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